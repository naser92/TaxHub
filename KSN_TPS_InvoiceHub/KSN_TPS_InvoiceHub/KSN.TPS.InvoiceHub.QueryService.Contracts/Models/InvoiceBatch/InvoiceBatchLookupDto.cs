using System;
using System.ComponentModel.DataAnnotations; 
using PDN.TPS.Framework.ViewModels;

namespace KSN.TPS.InvoiceHub.QueryService.Contracts.Models
{

    /// <summary>
    ///  
    /// </summary>
    [Display(Name="",Description="")]
    public class InvoiceBatchLookupDto:BaseDto < Guid > 
    {
      
        /// <summary>
        ///  InsertBaseType
        /// </summary>
        [Display(Name="InsertBaseType")]
        public int InsertBaseType { get; set; }
      
        /// <summary>
        ///  UserContainerId
        /// </summary>
        [Display(Name="UserContainerId")]
        public Guid UserContainerId { get; set; }
      
        /// <summary>
        ///  CreatedUserId
        /// </summary>
        [Display(Name="CreatedUserId")]
        public Guid CreatedUserId { get; set; }
      
        /// <summary>
        ///  FileName
        /// </summary>
        [Display(Name="FileName")]
        public string FileName { get; set; }
      
        /// <summary>
        ///  TotalInvoiceCount
        /// </summary>
        [Display(Name="TotalInvoiceCount")]
        public int TotalInvoiceCount { get; set; }
    
}

}
