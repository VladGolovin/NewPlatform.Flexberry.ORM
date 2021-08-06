﻿namespace ICSSoft.STORMNET.Security
{
    /// <summary>
    /// Перечислимый тип для вывода результата операции.
    /// </summary>
    public enum OperationResult
    {
        /// <summary>
        /// Во время выполнения операции произошла ошибка.
        /// </summary>
        ОшибкаВыполненияОперации,

        /// <summary>
        /// Всё хорошо.
        /// </summary>
        Успешно,

        /// <summary>
        /// Указан неверный пароль.
        /// </summary>
        НеправильныйПароль,

        /// <summary>
        /// Неправильно указаны аргументы.
        /// </summary>
        ОшибочныеАргументы,

        /// <summary>
        /// В доступе отказать.
        /// </summary>
        ВДоступеОтказать,

        /// <summary>
        /// Данный пользователь в системе не найден.
        /// </summary>
        ПользовательНеНайден,

        /// <summary>
        /// Логин занят другим пользователем.
        /// </summary>
        ЛогинЗанят,

        /// <summary>
        /// Логин доступен для регистрации.
        /// </summary>
        ЛогинСвободен,
    }
}
