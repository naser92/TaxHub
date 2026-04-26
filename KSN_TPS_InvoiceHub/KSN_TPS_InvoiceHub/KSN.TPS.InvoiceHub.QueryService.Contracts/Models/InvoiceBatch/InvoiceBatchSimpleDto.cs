using System;
using System.ComponentModel.DataAnnotations; 
using PDN.TPS.Framework.ViewModels;

namespace KSN.TPS.InvoiceHub.QueryService.Contracts.Models
{

    /// <summary>
    ///  
    /// </summary>
    [Display(Name="",Description="")]
    public class InvoiceBatchSimpleDto:BaseDto<Guid>
    {
 
        /// <summary>
        ///  FileName
        /// </summary>
        [Display(Name="FileName")]
        public string FileName { get; set; }
    }

}
