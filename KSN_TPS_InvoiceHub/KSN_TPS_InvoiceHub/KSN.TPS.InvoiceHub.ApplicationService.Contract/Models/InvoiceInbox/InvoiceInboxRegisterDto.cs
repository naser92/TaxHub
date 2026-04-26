using System;
using System.ComponentModel.DataAnnotations;
using PDN.TPS.Framework.ViewModels;

namespace KSN.TPS.InvoiceHub.ApplicationService.Dto
{
    
    /// <summary>
    ///  
    /// </summary>
    [Display(Name="",Description="")]
    public class InvoiceInboxRegisterDto
    {


        /// <summary>
        ///  BatchId
        /// </summary>
        [Display(Name="BatchId")]
        public Guid BatchId { get; set; }


        /// <summary>
        ///  UserContainerId
        /// </summary>
        [Display(Name="UserContainerId")]
        public Guid UserContainerId { get; set; }


        /// <summary>
        ///  InvoiceNumber
        /// </summary>
        [Display(Name="InvoiceNumber")]
        public string InvoiceNumber { get; set; }


        /// <summary>
        ///  InvoiceDate
        /// </summary>
        [Display(Name="InvoiceDate")]
        public DateTime InvoiceDate { get; set; }


        /// <summary>
        ///  Payload
        /// </summary>
        [Display(Name="Payload")]
        public string Payload { get; set; }


        /// <summary>
        ///  Status
        /// </summary>
        [Display(Name="Status")]
        public int Status { get; set; }


        /// <summary>
        ///  ProcessResult
        /// </summary>
        [Display(Name="ProcessResult")]
        public string ProcessResult { get; set; }


        /// <summary>
        ///  ProcessedDate
        /// </summary>
        [Display(Name="ProcessedDate")]
        public DateTime? ProcessedDate { get; set; }

    }
}
