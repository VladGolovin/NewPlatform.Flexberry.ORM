﻿namespace ICSSoft.STORMNET.Business
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data.Common;
    using System.Linq;
    using System.Threading.Tasks;

    using ICSSoft.STORMNET.Business.Audit.HelpStructures;
    using ICSSoft.STORMNET.Business.Audit.Objects;

    using NewPlatform.Flexberry.ORM;

    /// <summary>
    /// Data service for SQL storage.
    /// </summary>
    public abstract partial class SQLDataService : System.ComponentModel.Component, IDataService, IAsyncDataService
    {
        /// <inheritdoc cref="IAsyncDataService.UpdateObjectsAsync(DataObject[], bool, DataObjectCache)"/>
        public virtual async Task UpdateObjectsAsync(DataObject[] objects, bool alwaysThrowException = false, DataObjectCache dataObjectCache = null)
        {
            if (objects == null)
            {
                throw new ArgumentNullException(nameof(objects));
            }

            if (!objects.Any())
            {
                return;
            }

            if (dataObjectCache == null)
            {
                dataObjectCache = new DataObjectCache();
            }

            RunChangeCustomizationString(objects);

            using (DbTransactionWrapperAsync dbTransactionWrapper = new DbTransactionWrapperAsync(this))
            {
                try
                {
                    await UpdateObjectsByExtConnAsync(objects, dataObjectCache, alwaysThrowException, dbTransactionWrapper)
                        .ConfigureAwait(false);
#if NETSTANDARD2_1
                    await dbTransactionWrapper.CommitTransaction()
                        .ConfigureAwait(false);
#else
                    dbTransactionWrapper.CommitTransaction();
#endif
                }
                catch (Exception)
                {
#if NETSTANDARD2_1
                    await dbTransactionWrapper.RollbackTransaction()
                        .ConfigureAwait(false);
#else
                    dbTransactionWrapper.RollbackTransaction();
#endif
                    throw;
                }
            }
        }

        /// <summary>
        /// Сохранение объектов данных.
        /// </summary>
        /// <remarks><i>Атрибуты loadingState и status у обрабатываемых объектов обновляются в процессе работы.</i></remarks>
        /// <param name="objects">Объекты данных, которые требуется обновить.</param>
        /// <param name="dataObjectCache">Кэш объектов (если null, будет использован временный кеш, созданный внутри метода).</param>
        /// <param name="alwaysThrowException">true - выбрасывать исключение при первой же ошибке. false - при ошибке в одном из запросов, остальные запросы всё равно будут выполнены; выбрасывается только последнее исключение в самом конце.</param>
        /// <param name="dbTransactionWrapperAsync">Используемые коннекция и транзакция.</param>
        /// <returns>Объект <see cref="Task"/>, представляющий асинхронную операцию.</returns>
        public virtual async Task UpdateObjectsByExtConnAsync(DataObject[] objects, DataObjectCache dataObjectCache, bool alwaysThrowException, DbTransactionWrapperAsync dbTransactionWrapperAsync)
        {
            if (objects == null)
            {
                throw new ArgumentNullException(nameof(objects));
            }

            if (!objects.Any())
            {
                return;
            }

            if (dbTransactionWrapperAsync == null)
            {
                throw new ArgumentNullException(nameof(dbTransactionWrapperAsync), "Не указан DbTransactionWrapperAsync. Обратитесь к разработчику.");
            }

            if (dataObjectCache == null)
            {
                dataObjectCache = new DataObjectCache();
            }

            object id = BusinessTaskMonitor.BeginTask("Update objects");

            var deleteQueries = new StringCollection();
            var updateQueries = new StringCollection();
            var updateFirstQueries = new StringCollection();
            var updateLastQueries = new StringCollection();
            var insertQueries = new StringCollection();

            var deleteTables = new StringCollection();
            var updateTables = new StringCollection();
            var insertTables = new StringCollection();
            var tableOperations = new SortedList();
            var queryOrder = new StringCollection();

            var allQueriedObjects = new ArrayList();

            var auditOperationInfoList = new List<AuditAdditionalInfo>();
            var extraProcessingList = new List<DataObject>();

            GenerateQueriesForUpdateObjects(deleteQueries, deleteTables, updateQueries, updateFirstQueries, updateLastQueries, updateTables, insertQueries, insertTables, tableOperations, queryOrder, true, allQueriedObjects, dataObjectCache, extraProcessingList, dbTransactionWrapperAsync, objects);

            extraProcessingList = await GenerateAuditForAggregatorsAsync(allQueriedObjects, dataObjectCache, dbTransactionWrapperAsync).ConfigureAwait(false);

            OnBeforeUpdateObjects(allQueriedObjects);

            // Сортируем объекты в порядке заданным графом связности.
            extraProcessingList.Sort((x, y) =>
            {
                int indexX = queryOrder.IndexOf(Information.GetClassStorageName(x.GetType()));
                int indexY = queryOrder.IndexOf(Information.GetClassStorageName(y.GetType()));
                return indexX.CompareTo(indexY);
            });

            AccessCheckBeforeUpdate(SecurityManager, allQueriedObjects);

            // Порядок выполнения запросов: delete, insert, update.
            if (deleteQueries.Count > 0 || updateQueries.Count > 0 || insertQueries.Count > 0)
            {
                Guid? operationUniqueId = null;

                if (NotifierUpdateObjects != null)
                {
                    operationUniqueId = Guid.NewGuid();
                    var transaction = await dbTransactionWrapperAsync.GetTransactionAsync().ConfigureAwait(false);
                    NotifierUpdateObjects.BeforeUpdateObjects(operationUniqueId.Value, this, transaction, objects);
                }

                if (AuditService.IsAuditEnabled)
                {
                    /* Аудит проводится именно здесь, поскольку на этот момент все бизнес-сервера на объектах уже выполнились,
                     * объекты находятся именно в том состоянии, в каком должны были пойти в базу + в будущем можно транзакцию передать на исполнение
                     */
                    var transaction = await dbTransactionWrapperAsync.GetTransactionAsync().ConfigureAwait(false);
                    AuditService.WriteCommonAuditOperationWithAutoFields(extraProcessingList, auditOperationInfoList, this, true, transaction); // TODO: подумать, как записывать аудит до OnBeforeUpdateObjects, но уже потенциально с транзакцией
                }

                string query = string.Empty;
                string prevQueries = string.Empty;
                object subTask = null;
                try
                {
                    Exception ex = null;
                    DbCommand command = await dbTransactionWrapperAsync.CreateCommandAsync()
                        .ConfigureAwait(false);

                    // прошли вглубь обрабатывая only Update||Insert
                    bool go = true;
                    do
                    {
                        string table = queryOrder[0];
                        if (!tableOperations.ContainsKey(table))
                        {
                            tableOperations.Add(table, OperationType.None);
                        }

                        var ops = (OperationType)tableOperations[table];

                        if ((ops & OperationType.Delete) != OperationType.Delete && updateLastQueries.Count == 0)
                        {
                            // Смотрим есть ли Инсерты
                            if ((ops & OperationType.Insert) == OperationType.Insert)
                            {
                                if ((ex = await RunCommandsAsync(insertQueries, insertTables, table, command, id, alwaysThrowException).ConfigureAwait(false)) == null)
                                {
                                    ops = Minus(ops, OperationType.Insert);
                                    tableOperations[table] = ops;
                                }
                                else
                                {
                                    go = false;
                                }
                            }

                            // Смотрим есть ли Update
                            if (go && ((ops & OperationType.Update) == OperationType.Update))
                            {
                                if ((ex = await RunCommandsAsync(updateQueries, updateTables, table, command, id, alwaysThrowException).ConfigureAwait(false)) == null)
                                {
                                    ops = Minus(ops, OperationType.Update);
                                    tableOperations[table] = ops;
                                }
                                else
                                {
                                    go = false;
                                }
                            }

                            if (go)
                            {
                                queryOrder.RemoveAt(0);
                                go = queryOrder.Count > 0;
                            }
                        }
                        else
                        {
                            go = false;
                        }
                    }
                    while (go);

                    if (ex != null)
                    {
                        throw ex;
                    }

                    if (queryOrder.Count > 0)
                    {
                        // сзади чистые Update
                        go = true;
                        int queryOrderIndex = queryOrder.Count - 1;
                        do
                        {
                            string table = queryOrder[queryOrderIndex];
                            if (tableOperations.ContainsKey(table))
                            {
                                var ops = (OperationType)tableOperations[table];

                                if (ops == OperationType.Update && updateLastQueries.Count == 0)
                                {
                                    if ((ex = await RunCommandsAsync(updateQueries, updateTables, table, command, id, alwaysThrowException).ConfigureAwait(false)) == null)
                                    {
                                        ops = Minus(ops, OperationType.Update);
                                        tableOperations[table] = ops;
                                    }
                                    else
                                    {
                                        go = false;
                                    }

                                    if (go)
                                    {
                                        queryOrderIndex--;
                                        go = queryOrderIndex >= 0;
                                    }
                                }
                                else
                                {
                                    go = false;
                                }
                            }
                            else
                            {
                                queryOrderIndex--;
                            }
                        }
                        while (go);
                    }

                    if (ex != null)
                    {
                        throw ex;
                    }

                    foreach (string table in queryOrder)
                    {
                        await RunCommandsAsync(updateFirstQueries, updateTables, table, command, id, alwaysThrowException).ConfigureAwait(false);
                    }

                    // Удаляем в обратном порядке.
                    for (int i = queryOrder.Count - 1; i >= 0; i--)
                    {
                        string table = queryOrder[i];
                        await RunCommandsAsync(deleteQueries, deleteTables, table, command, id, alwaysThrowException).ConfigureAwait(false);
                    }

                    // А теперь опять с начала
                    foreach (string table in queryOrder)
                    {
                        await RunCommandsAsync(insertQueries, insertTables, table, command, id, alwaysThrowException).ConfigureAwait(false);
                        await RunCommandsAsync(updateQueries, updateTables, table, command, id, alwaysThrowException).ConfigureAwait(false);
                    }

                    foreach (string table in queryOrder)
                    {
                        await RunCommandsAsync(updateLastQueries, updateTables, table, command, id, alwaysThrowException).ConfigureAwait(false);
                    }

                    if (AuditService.IsAuditEnabled && auditOperationInfoList.Count > 0)
                    {
                        // Нужно зафиксировать операции аудита (то есть сообщить, что всё было корректно выполнено и запомнить время)
                        var transaction = await dbTransactionWrapperAsync.GetTransactionAsync().ConfigureAwait(false);
                        AuditService.RatifyAuditOperationWithAutoFields(
                            tExecutionVariant.Executed,
                            AuditAdditionalInfo.SetNewFieldValuesForList(transaction, this, auditOperationInfoList),
                            this,
                            true);
                    }

                    if (NotifierUpdateObjects != null)
                    {
                        var transaction = await dbTransactionWrapperAsync.GetTransactionAsync().ConfigureAwait(false);
                        NotifierUpdateObjects.AfterSuccessSqlUpdateObjects(operationUniqueId.Value, this, transaction, objects);
                    }
                }
                catch (Exception excpt)
                {
                    if (AuditService.IsAuditEnabled && auditOperationInfoList.Count > 0)
                    {
                        // Нужно зафиксировать операции аудита (то есть сообщить, что всё было откачено).
                        AuditService.RatifyAuditOperationWithAutoFields(tExecutionVariant.Failed, auditOperationInfoList, this, false);
                    }

                    if (NotifierUpdateObjects != null)
                    {
                        NotifierUpdateObjects.AfterFailUpdateObjects(operationUniqueId.Value, this, objects);
                    }

                    BusinessTaskMonitor.EndSubTask(subTask);
                    throw new ExecutingQueryException(query, prevQueries, excpt);
                }

                var res = new ArrayList();
                foreach (DataObject changedObject in objects)
                {
                    changedObject.ClearPrototyping(true);

                    if (changedObject.GetStatus(false) != ObjectStatus.Deleted)
                    {
                        Utils.UpdateInternalDataInObjects(changedObject, true, dataObjectCache);
                        res.Add(changedObject);
                    }
                }

                foreach (DataObject dobj in allQueriedObjects)
                {
                    if (dobj.GetStatus(false) != ObjectStatus.Deleted
                        && dobj.GetStatus(false) != ObjectStatus.UnAltered)
                    {
                        Utils.UpdateInternalDataInObjects(dobj, true, dataObjectCache);
                    }
                }

                if (NotifierUpdateObjects != null)
                {
                    NotifierUpdateObjects.AfterSuccessUpdateObjects(operationUniqueId.Value, this, objects);
                }

                objects = new DataObject[res.Count];
                res.CopyTo(objects);

                BusinessTaskMonitor.EndTask(id);
            }

            if (AfterUpdateObjects != null)
            {
                AfterUpdateObjects(this, new DataObjectsEventArgs(objects));
            }
        }
    }
}
