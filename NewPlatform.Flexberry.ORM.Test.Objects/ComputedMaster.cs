﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
    /// ComputedMaster.
    /// </summary>
    // *** Start programmer edit section *** (ComputedMaster CustomAttributes)

    // *** End programmer edit section *** (ComputedMaster CustomAttributes)
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    [View("ComputedMasterL", new string[] {
            "MasterField1",
            "MasterField2",
            "MasterComputedField1"})]
    public class ComputedMaster : ICSSoft.STORMNET.DataObject
    {
        
        private string fMasterField1;
        
        private string fMasterField2;
        
        // *** Start programmer edit section *** (ComputedMaster CustomMembers)

        // *** End programmer edit section *** (ComputedMaster CustomMembers)

        
        /// <summary>
        /// MasterField1.
        /// </summary>
        // *** Start programmer edit section *** (ComputedMaster.MasterField1 CustomAttributes)

        // *** End programmer edit section *** (ComputedMaster.MasterField1 CustomAttributes)
        [StrLen(255)]
        public virtual string MasterField1
        {
            get
            {
                // *** Start programmer edit section *** (ComputedMaster.MasterField1 Get start)

                // *** End programmer edit section *** (ComputedMaster.MasterField1 Get start)
                string result = this.fMasterField1;
                // *** Start programmer edit section *** (ComputedMaster.MasterField1 Get end)

                // *** End programmer edit section *** (ComputedMaster.MasterField1 Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (ComputedMaster.MasterField1 Set start)

                // *** End programmer edit section *** (ComputedMaster.MasterField1 Set start)
                this.fMasterField1 = value;
                // *** Start programmer edit section *** (ComputedMaster.MasterField1 Set end)

                // *** End programmer edit section *** (ComputedMaster.MasterField1 Set end)
            }
        }
        
        /// <summary>
        /// MasterField2.
        /// </summary>
        // *** Start programmer edit section *** (ComputedMaster.MasterField2 CustomAttributes)

        // *** End programmer edit section *** (ComputedMaster.MasterField2 CustomAttributes)
        [StrLen(255)]
        public virtual string MasterField2
        {
            get
            {
                // *** Start programmer edit section *** (ComputedMaster.MasterField2 Get start)

                // *** End programmer edit section *** (ComputedMaster.MasterField2 Get start)
                string result = this.fMasterField2;
                // *** Start programmer edit section *** (ComputedMaster.MasterField2 Get end)

                // *** End programmer edit section *** (ComputedMaster.MasterField2 Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (ComputedMaster.MasterField2 Set start)

                // *** End programmer edit section *** (ComputedMaster.MasterField2 Set start)
                this.fMasterField2 = value;
                // *** Start programmer edit section *** (ComputedMaster.MasterField2 Set end)

                // *** End programmer edit section *** (ComputedMaster.MasterField2 Set end)
            }
        }
        
        /// <summary>
        /// MasterComputedField1.
        /// </summary>
        // *** Start programmer edit section *** (ComputedMaster.MasterComputedField1 CustomAttributes)

        // *** End programmer edit section *** (ComputedMaster.MasterComputedField1 CustomAttributes)
        [ICSSoft.STORMNET.NotStored()]
        [StrLen(255)]
        [DataServiceExpression(typeof(ICSSoft.STORMNET.Business.MSSQLDataService), "@MasterField1@ + \\\'  \\\' + @MasterField2@")]
        [DataServiceExpression(typeof(ICSSoft.STORMNET.Business.OracleDataService), "@MasterField1@ || \\\'  \\\' || @MasterField2@")]
        [DataServiceExpression(typeof(ICSSoft.STORMNET.Business.PostgresDataService), "@MasterField1@ || \\\' \\\' || @MasterField1@")]
        public virtual string MasterComputedField1
        {
            get
            {
                // *** Start programmer edit section *** (ComputedMaster.MasterComputedField1 Get)
                return null;
                // *** End programmer edit section *** (ComputedMaster.MasterComputedField1 Get)
            }
            set
            {
                // *** Start programmer edit section *** (ComputedMaster.MasterComputedField1 Set)

                // *** End programmer edit section *** (ComputedMaster.MasterComputedField1 Set)
            }
        }
        
        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {
            
            /// <summary>
            /// "ComputedMasterL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View ComputedMasterL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("ComputedMasterL", typeof(NewPlatform.Flexberry.ORM.Tests.ComputedMaster));
                }
            }
        }
    }
}
