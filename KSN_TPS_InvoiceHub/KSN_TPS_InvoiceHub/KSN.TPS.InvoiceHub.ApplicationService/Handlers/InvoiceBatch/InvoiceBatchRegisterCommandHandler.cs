using KSN.TPS.InvoiceHub.ApplicationService.Commands;
using KSN.TPS.InvoiceHub.Domain;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Mapper;
using PDN.TPS.Framework.Core.Persistence;
using PDN.TPS.Framework.Core.Results;

namespace KSN.TPS.InvoiceHub.ApplicationService.Handlers
{
    public class InvoiceBatchRegisterCommandHandler : CommandHandler, ICommandHandler<InvoiceBatchRegisterCommand>
    {
        private readonly IInvoiceBatchWriteRepository _repository;

        public InvoiceBatchRegisterCommandHandler(
            IInvoiceBatchWriteRepository repository, IUnitOfWork uow) : base(uow)
        {
            _repository = repository;
        }

        public async Task<IResult> Handle(InvoiceBatchRegisterCommand command)
        {
            var entiy = command.Map<InvoiceBatch>();
            await _repository.Insert(entiy);
            return await Result.SuccessAsync("اطلاعات با موفقیت ثبت شد");
        }
    }
}


