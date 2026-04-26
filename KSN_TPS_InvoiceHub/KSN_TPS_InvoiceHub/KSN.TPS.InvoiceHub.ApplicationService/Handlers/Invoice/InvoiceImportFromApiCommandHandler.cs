using KSN.TPS.InvoiceHub.ApplicationService.Contract.Commands;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Persistence;
using PDN.TPS.Framework.Core.Results;

namespace KSN.TPS.InvoiceHub.ApplicationService.Handlers.Invoice
{
    internal class InvoiceImportFromApiCommandHandler : CommandHandler, ICommandHandler<InvoiceImportFromApiCommand>
    {
        public InvoiceImportFromApiCommandHandler(IUnitOfWork uow) : base(uow)
        {
        }

        public Task<IResult> Handle(InvoiceImportFromApiCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
