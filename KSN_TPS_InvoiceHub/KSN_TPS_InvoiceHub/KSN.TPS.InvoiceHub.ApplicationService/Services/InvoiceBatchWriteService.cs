using KSN.TPS.InvoiceHub.ApplicationService.Commands;
using KSN.TPS.InvoiceHub.ApplicationService.Services;
using KSN.TPS.InvoiceHub.Domain;
using Mapster;
using PDN.TPS.Framework.Core.Mapper;
using PDN.TPS.Framework.Core.Results;

namespace KSN.TPS.InvoiceHub.ApplicationService
{
    public class InvoiceBatchWriteService : IInvoiceBatchWriteService
    {
        #region variables

        private readonly IInvoiceBatchWriteRepository _InvoiceBatchWriteRepository;


        #endregion

        #region constractor

        public InvoiceBatchWriteService(IInvoiceBatchWriteRepository InvoiceBatchWriteRepository)
        {

            _InvoiceBatchWriteRepository = InvoiceBatchWriteRepository;


        }

        #endregion

        #region Default methods

        public async Task<IResult> Register(InvoiceBatchRegisterCommand model)
        {

            var entiy = model.Map<InvoiceBatch>();

            await _InvoiceBatchWriteRepository.Insert(entiy);

            return await Result.SuccessAsync(" موفقیت ثبت شد");

        }

        public async Task<IResult> Update(InvoiceBatchUpdateCommand model)
        {

            var entity = await _InvoiceBatchWriteRepository.Get(model.Id);

            if (entity is null)
                return await Result.FailAsync(" با این مشخصات پیدا نشد.");

            model.Map(entity);

            await _InvoiceBatchWriteRepository.Update(entity);

            return await Result.SuccessAsync(" با موفقیت ویرایش شد");

        }

        public async Task<IResult> Delete(Guid id)
        {

            var entity = await _InvoiceBatchWriteRepository.Get(id);

            if (entity is null)
                return await Result.FailAsync(" با این مشخصات پیدا نشد.");

            await _InvoiceBatchWriteRepository.Delete(entity);

            return await Result.SuccessAsync(" با موفقیت حذف شد");

        }

        #endregion

    }
}

