using System;
using System.Collections.Generic;

using PDN.TPS.Framework.Domain;

namespace KSN.TPS.InvoiceHub.Domain
{
  
    public class InvoiceBatch : AggregateGuid,IAuditableEntity
  {
      
        public int InsertBaseType { get; set; }
      
        public Guid UserContainerId { get; set; }
      
        public Guid CreatedUserId { get; set; }
      
        public string FileName { get; set; }
      
        public int TotalInvoiceCount { get; set; }
        
        public virtual ICollection<InvoiceInbox> InvoiceInbox { get; set; }
  
    }
}

