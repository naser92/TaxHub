using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
 
using PDN.TPS.Framework.Domain;
            
namespace KSN.TPS.InvoiceHub.Query.DataContext.DataModels
{
    public class InvoiceInboxModel: BaseReadModel<Guid>, IAuditableEntity
    {
      
        public Guid BatchId { get; set; }
      
        public Guid UserContainerId { get; set; }
      
        public string InvoiceNumber { get; set; }
      
        public DateTime InvoiceDate { get; set; }
      
        public string Payload { get; set; }
      
        public int Status { get; set; }
      
        public string ProcessResult { get; set; }
      
        public DateTime? ProcessedDate { get; set; }
      
        [ForeignKey("BatchId")]
        public virtual InvoiceBatchModel Batch { get; set; }
  
    }
}

