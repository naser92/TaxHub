using KSN.TPS.InvoiceHub.ApplicationService.Commands;
using KSN.TPS.InvoiceHub.Domain;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Mapper;
using PDN.TPS.Framework.Core.Persistence;
using PDN.TPS.Framework.Core.Results;

namespace KSN.TPS.InvoiceHub.ApplicationService.Handlers
{
    public class InvoiceInboxUpdateCommandHandler : CommandHandler,
        ICommandHandler<InvoiceInboxUpdateCommand>
    {
        private readonly IInvoiceInboxWriteRepository _repository;

        public InvoiceInboxUpdateCommandHandler(
            IInvoiceInboxWriteRepository repository, IUnitOfWork uow) : base(uow)
        {
            _repository = repository;
        }

        public async Task<IResult> Handle(InvoiceInboxUpdateCommand command)
        {
            var entity = await _repository.Get(command.Id);
            if (entity is null)
                return await Result.FailAsync("اطلاعات با این مشخصات پیدا نشد.");
            command.Map(entity);
            await _repository.Update(entity);
            return await Result.SuccessAsync("اطلاعات با موفقیت ویرایش شد");
        }
    }
}

