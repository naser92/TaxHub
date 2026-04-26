using System;
using System.ComponentModel.DataAnnotations; 
using PDN.TPS.Framework.ViewModels;

namespace KSN.TPS.InvoiceHub.QueryService.Contracts.Models
{

    /// <summary>
    ///  
    /// </summary>
    [Display(Name="",Description="")]
    public class InvoiceInboxSimpleDto:BaseDto<Guid>
    {
 
        /// <summary>
        ///  InvoiceNumber
        /// </summary>
        [Display(Name="InvoiceNumber")]
        public string InvoiceNumber { get; set; }
    }

}
