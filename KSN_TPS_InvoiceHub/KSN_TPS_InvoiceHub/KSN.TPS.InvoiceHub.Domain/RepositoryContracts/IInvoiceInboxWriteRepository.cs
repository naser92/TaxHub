using System;
using PDN.TPS.Framework.Data;

namespace KSN.TPS.InvoiceHub.Domain
{
    public interface IInvoiceInboxWriteRepository : IWriteRepository<InvoiceInbox,Guid>
    {

    }
}
