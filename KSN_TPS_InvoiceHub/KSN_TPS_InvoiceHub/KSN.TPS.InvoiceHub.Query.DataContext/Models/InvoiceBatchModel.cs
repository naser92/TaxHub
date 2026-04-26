using System;
using System.Collections.Generic;
 
using PDN.TPS.Framework.Domain;
            
namespace KSN.TPS.InvoiceHub.Query.DataContext.DataModels
{
    public class InvoiceBatchModel: BaseReadModel<Guid>, IAuditableEntity
    {
      
        public int InsertBaseType { get; set; }
      
        public Guid UserContainerId { get; set; }
      
        public Guid CreatedUserId { get; set; }
      
        public string FileName { get; set; }
      
        public int TotalInvoiceCount { get; set; }
        
        public virtual ICollection<InvoiceInboxModel> InvoiceInbox { get; set; }

  
    }
}

