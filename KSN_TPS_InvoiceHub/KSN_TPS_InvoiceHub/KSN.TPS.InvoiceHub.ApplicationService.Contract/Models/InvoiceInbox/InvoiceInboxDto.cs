using System;
using System.ComponentModel.DataAnnotations;
using PDN.TPS.Framework.ViewModels;

namespace KSN.TPS.InvoiceHub.ApplicationService.Dto
{

 
    public class InvoiceInboxDto : BaseDto<Guid>
    {

        public Guid BatchId { get; set; }

        public Guid UserContainerId { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string Payload { get; set; }

        public int Status { get; set; }

        public string ProcessResult { get; set; }

        public DateTime? ProcessedDate { get; set; }

    }
}
