using KSN.TPS.InvoiceHub.ApplicationService.Commands;
using KSN.TPS.InvoiceHub.Domain;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Persistence;
using PDN.TPS.Framework.Core.Results;


namespace PDN.TPS.Framework.ApplicationService.Handlers
{
    public class InvoiceBatchDeleteCommandHandler : CommandHandler, ICommandHandler<InvoiceBatchDeleteCommand>
    {
        private readonly IInvoiceBatchWriteRepository _repository;

        public InvoiceBatchDeleteCommandHandler(IInvoiceBatchWriteRepository repository, IUnitOfWork uow) : base(uow)
        {

            _repository = repository;

        }

        public async Task<IResult> Handle(InvoiceBatchDeleteCommand command)
        {
            var entity = await _repository.Get(command.Id);
            if (entity is null)
                return await Result.FailAsync("اطلاعات با این مشخصات پیدا نشد.");
            await _repository.Delete(entity);
            return await Result.SuccessAsync("اطلاعات با موفقیت حذف شد");
        }
    }
}

