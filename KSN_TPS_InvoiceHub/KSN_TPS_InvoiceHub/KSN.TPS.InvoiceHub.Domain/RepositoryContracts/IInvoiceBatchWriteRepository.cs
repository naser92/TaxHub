using System;
using PDN.TPS.Framework.Data;

namespace KSN.TPS.InvoiceHub.Domain
{
    public interface IInvoiceBatchWriteRepository : IWriteRepository<InvoiceBatch,Guid>
    {

    }
}
