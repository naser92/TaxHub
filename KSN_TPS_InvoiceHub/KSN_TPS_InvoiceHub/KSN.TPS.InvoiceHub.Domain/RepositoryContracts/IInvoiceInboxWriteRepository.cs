using PDN.TPS.Framework.Persistence.EF;


namespace KSN.TPS.InvoiceHub.Domain
{
    public interface IInvoiceInboxWriteRepository : IWriteRepository<InvoiceInbox, Guid>
    {

    }
}
