﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewPlatform.Flexberry.ORM.Tests
{
    using System;
    using System.Xml;
    using ICSSoft.STORMNET;
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Медведь.
    /// </summary>
    // *** Start programmer edit section *** (Медведь CustomAttributes)

    // *** End programmer edit section *** (Медведь CustomAttributes)
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    [View("LoadTestView", new string[] {
            "ЛесОбитания",
            "ЛесОбитания.Заповедник",
            "Мама",
            "Мама.ЦветГлаз",
            "Вес"})]
    [AssociatedDetailViewAttribute("LoadTestView", "Берлога", "LoadTestView", true, "", "", true, new string[] {
            ""})]
    [View("OrderNumberTest", new string[] {
            "ПорядковыйНомер",
            "ЛесОбитания"})]
    [View("МедведьE", new string[] {
            "ПорядковыйНомер as \'Порядковый номер\'",
            "Вес as \'Вес\'",
            "ЦветГлаз as \'Цвет глаз\'",
            "Пол as \'Пол\'",
            "ДатаРождения as \'Дата рождения\'",
            "Мама as \'Мама\'",
            "Мама.ЦветГлаз as \'Цвет глаз\'",
            "Папа as \'Папа\'",
            "Папа.ЦветГлаз as \'Цвет глаз\'",
            "ЛесОбитания as \'Лес обитания\'",
            "ЛесОбитания.Название as \'Название\'"})]
    [AssociatedDetailViewAttribute("МедведьE", "Берлога", "БерлогаE", true, "", "Берлога", true, new string[] {
            ""})]
    [View("МедведьL", new string[] {
            "ПорядковыйНомер as \'Порядковый номер\'",
            "Вес as \'Вес\'",
            "ЦветГлаз as \'Цвет глаз\'",
            "Пол as \'Пол\'",
            "ДатаРождения as \'Дата рождения\'",
            "Мама.ЦветГлаз as \'Цвет глаз\'",
            "Папа.ЦветГлаз as \'Цвет глаз\'",
            "ЛесОбитания.Название as \'Название\'"})]
    [View("МедведьShort", new string[] {
            "ПорядковыйНомер as \'Порядковый номер\'"})]
    [View("МедведьСДелейломИВычислимымСвойством", new string[] {
            "ПорядковыйНомер as \'Порядковый номер\'",
            "Вес as \'Вес\'",
            "ЦветГлаз as \'Цвет глаз\'",
            "Пол as \'Пол\'",
            "ДатаРождения as \'Дата рождения\'",
            "Мама as \'Мама\'",
            "Мама.ЦветГлаз as \'Цвет глаз\'",
            "Папа as \'Папа\'",
            "Папа.ЦветГлаз as \'Цвет глаз\'",
            "ЛесОбитания as \'Лес обитания\'",
            "ЛесОбитания.Название as \'Название\'",
            "МедведьСтрокой"})]
    [AssociatedDetailViewAttribute("МедведьСДелейломИВычислимымСвойством", "Берлога", "БерлогаE", true, "", "Берлога", true, new string[] {
            ""})]
    public class Медведь : ICSSoft.STORMNET.DataObject
    {
        
        private int fПорядковыйНомер;
        
        private int fВес;
        
        private string fЦветГлаз;
        
        private NewPlatform.Flexberry.ORM.Tests.Пол fПол;
        
        private ICSSoft.STORMNET.UserDataTypes.NullableDateTime fДатаРождения;
        
        private NewPlatform.Flexberry.ORM.Tests.Медведь fМама;
        
        private NewPlatform.Flexberry.ORM.Tests.Медведь fПапа;
        
        private NewPlatform.Flexberry.ORM.Tests.Лес fЛесОбитания;
        
        private NewPlatform.Flexberry.ORM.Tests.Медведь fДруг;
        
        private NewPlatform.Flexberry.ORM.Tests.DetailArrayOfБерлога fБерлога;
        
        // *** Start programmer edit section *** (Медведь CustomMembers)

        // *** End programmer edit section *** (Медведь CustomMembers)

        
        /// <summary>
        /// ПорядковыйНомер.
        /// </summary>
        // *** Start programmer edit section *** (Медведь.ПорядковыйНомер CustomAttributes)

        // *** End programmer edit section *** (Медведь.ПорядковыйНомер CustomAttributes)
        public virtual int ПорядковыйНомер
        {
            get
            {
                // *** Start programmer edit section *** (Медведь.ПорядковыйНомер Get start)

                // *** End programmer edit section *** (Медведь.ПорядковыйНомер Get start)
                int result = this.fПорядковыйНомер;
                // *** Start programmer edit section *** (Медведь.ПорядковыйНомер Get end)

                // *** End programmer edit section *** (Медведь.ПорядковыйНомер Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Медведь.ПорядковыйНомер Set start)

                // *** End programmer edit section *** (Медведь.ПорядковыйНомер Set start)
                this.fПорядковыйНомер = value;
                // *** Start programmer edit section *** (Медведь.ПорядковыйНомер Set end)

                // *** End programmer edit section *** (Медведь.ПорядковыйНомер Set end)
            }
        }
        
        /// <summary>
        /// Вес.
        /// </summary>
        // *** Start programmer edit section *** (Медведь.Вес CustomAttributes)

        // *** End programmer edit section *** (Медведь.Вес CustomAttributes)
        public virtual int Вес
        {
            get
            {
                // *** Start programmer edit section *** (Медведь.Вес Get start)

                // *** End programmer edit section *** (Медведь.Вес Get start)
                int result = this.fВес;
                // *** Start programmer edit section *** (Медведь.Вес Get end)

                // *** End programmer edit section *** (Медведь.Вес Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Медведь.Вес Set start)

                // *** End programmer edit section *** (Медведь.Вес Set start)
                this.fВес = value;
                // *** Start programmer edit section *** (Медведь.Вес Set end)

                // *** End programmer edit section *** (Медведь.Вес Set end)
            }
        }
        
        /// <summary>
        /// ЦветГлаз.
        /// </summary>
        // *** Start programmer edit section *** (Медведь.ЦветГлаз CustomAttributes)

        // *** End programmer edit section *** (Медведь.ЦветГлаз CustomAttributes)
        [StrLen(255)]
        public virtual string ЦветГлаз
        {
            get
            {
                // *** Start programmer edit section *** (Медведь.ЦветГлаз Get start)

                // *** End programmer edit section *** (Медведь.ЦветГлаз Get start)
                string result = this.fЦветГлаз;
                // *** Start programmer edit section *** (Медведь.ЦветГлаз Get end)

                // *** End programmer edit section *** (Медведь.ЦветГлаз Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Медведь.ЦветГлаз Set start)

                // *** End programmer edit section *** (Медведь.ЦветГлаз Set start)
                this.fЦветГлаз = value;
                // *** Start programmer edit section *** (Медведь.ЦветГлаз Set end)

                // *** End programmer edit section *** (Медведь.ЦветГлаз Set end)
            }
        }
        
        /// <summary>
        /// Пол.
        /// </summary>
        // *** Start programmer edit section *** (Медведь.Пол CustomAttributes)

        // *** End programmer edit section *** (Медведь.Пол CustomAttributes)
        public virtual NewPlatform.Flexberry.ORM.Tests.Пол Пол
        {
            get
            {
                // *** Start programmer edit section *** (Медведь.Пол Get start)

                // *** End programmer edit section *** (Медведь.Пол Get start)
                NewPlatform.Flexberry.ORM.Tests.Пол result = this.fПол;
                // *** Start programmer edit section *** (Медведь.Пол Get end)

                // *** End programmer edit section *** (Медведь.Пол Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Медведь.Пол Set start)

                // *** End programmer edit section *** (Медведь.Пол Set start)
                this.fПол = value;
                // *** Start programmer edit section *** (Медведь.Пол Set end)

                // *** End programmer edit section *** (Медведь.Пол Set end)
            }
        }
        
        /// <summary>
        /// ДатаРождения.
        /// </summary>
        // *** Start programmer edit section *** (Медведь.ДатаРождения CustomAttributes)

        // *** End programmer edit section *** (Медведь.ДатаРождения CustomAttributes)
        public virtual ICSSoft.STORMNET.UserDataTypes.NullableDateTime ДатаРождения
        {
            get
            {
                // *** Start programmer edit section *** (Медведь.ДатаРождения Get start)

                // *** End programmer edit section *** (Медведь.ДатаРождения Get start)
                ICSSoft.STORMNET.UserDataTypes.NullableDateTime result = this.fДатаРождения;
                // *** Start programmer edit section *** (Медведь.ДатаРождения Get end)

                // *** End programmer edit section *** (Медведь.ДатаРождения Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Медведь.ДатаРождения Set start)

                // *** End programmer edit section *** (Медведь.ДатаРождения Set start)
                this.fДатаРождения = value;
                // *** Start programmer edit section *** (Медведь.ДатаРождения Set end)

                // *** End programmer edit section *** (Медведь.ДатаРождения Set end)
            }
        }
        
        /// <summary>
        /// МедведьСтрокой.
        /// </summary>
        // *** Start programmer edit section *** (Медведь.МедведьСтрокой CustomAttributes)

        // *** End programmer edit section *** (Медведь.МедведьСтрокой CustomAttributes)
        [ICSSoft.STORMNET.NotStored()]
        [StrLen(255)]
        [DataServiceExpression(typeof(ICSSoft.STORMNET.Business.MSSQLDataService), "\'ПорядковыйНомер:\' + @ПорядковыйНомер@ + \", Цвет глаз мамы:\" + isnull(@Мама.ЦветГ" +
            "лаз@,\'\')")]
        public virtual string МедведьСтрокой
        {
            get
            {
                // *** Start programmer edit section *** (Медведь.МедведьСтрокой Get)
                return null;
                // *** End programmer edit section *** (Медведь.МедведьСтрокой Get)
            }
            set
            {
                // *** Start programmer edit section *** (Медведь.МедведьСтрокой Set)

                // *** End programmer edit section *** (Медведь.МедведьСтрокой Set)
            }
        }
        
        /// <summary>
        /// ВычислимоеПоле.
        /// </summary>
        // *** Start programmer edit section *** (Медведь.ВычислимоеПоле CustomAttributes)

        // *** End programmer edit section *** (Медведь.ВычислимоеПоле CustomAttributes)
        [ICSSoft.STORMNET.NotStored()]
        [DataServiceExpression(typeof(ICSSoft.STORMNET.Business.MSSQLDataService), "@ПорядковыйНомер@ + @Вес@")]
        public virtual int ВычислимоеПоле
        {
            get
            {
                // *** Start programmer edit section *** (Медведь.ВычислимоеПоле Get)
                return 0;
                // *** End programmer edit section *** (Медведь.ВычислимоеПоле Get)
            }
            set
            {
                // *** Start programmer edit section *** (Медведь.ВычислимоеПоле Set)

                // *** End programmer edit section *** (Медведь.ВычислимоеПоле Set)
            }
        }
        
        /// <summary>
        /// Медведь.
        /// </summary>
        // *** Start programmer edit section *** (Медведь.Мама CustomAttributes)

        // *** End programmer edit section *** (Медведь.Мама CustomAttributes)
        [PropertyStorage(new string[] {
                "Мама"})]
        public virtual NewPlatform.Flexberry.ORM.Tests.Медведь Мама
        {
            get
            {
                // *** Start programmer edit section *** (Медведь.Мама Get start)

                // *** End programmer edit section *** (Медведь.Мама Get start)
                NewPlatform.Flexberry.ORM.Tests.Медведь result = this.fМама;
                // *** Start programmer edit section *** (Медведь.Мама Get end)

                // *** End programmer edit section *** (Медведь.Мама Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Медведь.Мама Set start)

                // *** End programmer edit section *** (Медведь.Мама Set start)
                this.fМама = value;
                // *** Start programmer edit section *** (Медведь.Мама Set end)

                // *** End programmer edit section *** (Медведь.Мама Set end)
            }
        }
        
        /// <summary>
        /// Медведь.
        /// </summary>
        // *** Start programmer edit section *** (Медведь.Папа CustomAttributes)

        // *** End programmer edit section *** (Медведь.Папа CustomAttributes)
        [PropertyStorage(new string[] {
                "Папа"})]
        public virtual NewPlatform.Flexberry.ORM.Tests.Медведь Папа
        {
            get
            {
                // *** Start programmer edit section *** (Медведь.Папа Get start)

                // *** End programmer edit section *** (Медведь.Папа Get start)
                NewPlatform.Flexberry.ORM.Tests.Медведь result = this.fПапа;
                // *** Start programmer edit section *** (Медведь.Папа Get end)

                // *** End programmer edit section *** (Медведь.Папа Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Медведь.Папа Set start)

                // *** End programmer edit section *** (Медведь.Папа Set start)
                this.fПапа = value;
                // *** Start programmer edit section *** (Медведь.Папа Set end)

                // *** End programmer edit section *** (Медведь.Папа Set end)
            }
        }
        
        /// <summary>
        /// Медведь.
        /// </summary>
        // *** Start programmer edit section *** (Медведь.ЛесОбитания CustomAttributes)

        // *** End programmer edit section *** (Медведь.ЛесОбитания CustomAttributes)
        [PropertyStorage(new string[] {
                "ЛесОбитания"})]
        public virtual NewPlatform.Flexberry.ORM.Tests.Лес ЛесОбитания
        {
            get
            {
                // *** Start programmer edit section *** (Медведь.ЛесОбитания Get start)

                // *** End programmer edit section *** (Медведь.ЛесОбитания Get start)
                NewPlatform.Flexberry.ORM.Tests.Лес result = this.fЛесОбитания;
                // *** Start programmer edit section *** (Медведь.ЛесОбитания Get end)

                // *** End programmer edit section *** (Медведь.ЛесОбитания Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Медведь.ЛесОбитания Set start)

                // *** End programmer edit section *** (Медведь.ЛесОбитания Set start)
                this.fЛесОбитания = value;
                // *** Start programmer edit section *** (Медведь.ЛесОбитания Set end)

                // *** End programmer edit section *** (Медведь.ЛесОбитания Set end)
            }
        }

        /// <summary>
        /// Медведь.
        /// </summary>
        // *** Start programmer edit section *** (Медведь.Друг CustomAttributes)

        // *** End programmer edit section *** (Медведь.Друг CustomAttributes)
        public virtual NewPlatform.Flexberry.ORM.Tests.Медведь Друг
        {
            get
            {
                // *** Start programmer edit section *** (Медведь.Друг Get start)

                // *** End programmer edit section *** (Медведь.Друг Get start)
                NewPlatform.Flexberry.ORM.Tests.Медведь result = this.fДруг;
                // *** Start programmer edit section *** (Медведь.Друг Get end)

                // *** End programmer edit section *** (Медведь.Друг Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Медведь.Друг Set start)

                // *** End programmer edit section *** (Медведь.Друг Set start)
                this.fДруг = value;
                // *** Start programmer edit section *** (Медведь.Друг Set end)

                // *** End programmer edit section *** (Медведь.Друг Set end)
            }
        }
        
        /// <summary>
        /// Медведь.
        /// </summary>
        // *** Start programmer edit section *** (Медведь.Берлога CustomAttributes)

        // *** End programmer edit section *** (Медведь.Берлога CustomAttributes)
        public virtual NewPlatform.Flexberry.ORM.Tests.DetailArrayOfБерлога Берлога
        {
            get
            {
                // *** Start programmer edit section *** (Медведь.Берлога Get start)

                // *** End programmer edit section *** (Медведь.Берлога Get start)
                if ((this.fБерлога == null))
                {
                    this.fБерлога = new NewPlatform.Flexberry.ORM.Tests.DetailArrayOfБерлога(this);
                }
                NewPlatform.Flexberry.ORM.Tests.DetailArrayOfБерлога result = this.fБерлога;
                // *** Start programmer edit section *** (Медведь.Берлога Get end)

                // *** End programmer edit section *** (Медведь.Берлога Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Медведь.Берлога Set start)

                // *** End programmer edit section *** (Медведь.Берлога Set start)
                this.fБерлога = value;
                // *** Start programmer edit section *** (Медведь.Берлога Set end)

                // *** End programmer edit section *** (Медведь.Берлога Set end)
            }
        }
        
        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {
            
            /// <summary>
            /// Представление для работы тестов на загрузку объектов.
            /// </summary>
            public static ICSSoft.STORMNET.View LoadTestView
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("LoadTestView", typeof(NewPlatform.Flexberry.ORM.Tests.Медведь));
                }
            }
            
            /// <summary>
            /// Представление для работы теста по использованию порядкового номера.
            /// </summary>
            public static ICSSoft.STORMNET.View OrderNumberTest
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("OrderNumberTest", typeof(NewPlatform.Flexberry.ORM.Tests.Медведь));
                }
            }
            
            /// <summary>
            /// "МедведьE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View МедведьE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("МедведьE", typeof(NewPlatform.Flexberry.ORM.Tests.Медведь));
                }
            }
            
            /// <summary>
            /// "МедведьL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View МедведьL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("МедведьL", typeof(NewPlatform.Flexberry.ORM.Tests.Медведь));
                }
            }
            
            /// <summary>
            /// "МедведьShort" view.
            /// </summary>
            public static ICSSoft.STORMNET.View МедведьShort
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("МедведьShort", typeof(NewPlatform.Flexberry.ORM.Tests.Медведь));
                }
            }
            
            /// <summary>
            /// "МедведьСДелейломИВычислимымСвойством" view.
            /// </summary>
            public static ICSSoft.STORMNET.View МедведьСДелейломИВычислимымСвойством
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("МедведьСДелейломИВычислимымСвойством", typeof(NewPlatform.Flexberry.ORM.Tests.Медведь));
                }
            }
        }
    }
}
