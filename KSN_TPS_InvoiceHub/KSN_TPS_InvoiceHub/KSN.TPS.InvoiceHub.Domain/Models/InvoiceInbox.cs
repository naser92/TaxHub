using System;
using System.ComponentModel.DataAnnotations.Schema;

using PDN.TPS.Framework.Domain;

namespace KSN.TPS.InvoiceHub.Domain
{
  
    public class InvoiceInbox : AggregateGuid,IAuditableEntity
  {
      
        [ForeignKey("BatchId")]
        public virtual InvoiceBatch Batch { get; set; }
      
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

