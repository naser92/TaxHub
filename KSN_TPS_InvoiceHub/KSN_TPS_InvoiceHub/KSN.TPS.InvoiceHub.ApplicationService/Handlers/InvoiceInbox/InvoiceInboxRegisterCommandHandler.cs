using KSN.TPS.InvoiceHub.ApplicationService.Commands;
using KSN.TPS.InvoiceHub.Domain;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Mapper;
using PDN.TPS.Framework.Core.Persistence;
using PDN.TPS.Framework.Core.Results;

namespace KSN.TPS.InvoiceHub.ApplicationService.Handlers
{
    public class InvoiceInboxRegisterCommandHandler : CommandHandler, ICommandHandler<InvoiceInboxRegisterCommand>
    {
        private readonly IInvoiceInboxWriteRepository _repository;

        public InvoiceInboxRegisterCommandHandler(
            IInvoiceInboxWriteRepository repository, IUnitOfWork uow) : base(uow)
        {
            _repository = repository;
        }

        public async Task<IResult> Handle(InvoiceInboxRegisterCommand command)
        {
            var entiy = command.Map<InvoiceInbox>();
            await _repository.Insert(entiy);
            return await Result.SuccessAsync("اطلاعات با موفقیت ثبت شد");
        }
    }
}


