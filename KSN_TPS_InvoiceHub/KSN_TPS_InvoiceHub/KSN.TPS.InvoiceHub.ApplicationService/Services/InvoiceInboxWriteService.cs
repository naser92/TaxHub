using KSN.TPS.InvoiceHub.ApplicationService.Commands;
using KSN.TPS.InvoiceHub.ApplicationService.Services;
using KSN.TPS.InvoiceHub.Domain;
using Mapster;
using PDN.TPS.Framework.Core.Mapper;
using PDN.TPS.Framework.Core.Results;

namespace KSN.TPS.InvoiceHub.ApplicationService
{
    public class InvoiceInboxWriteService : IInvoiceInboxWriteService
    {
        #region variables

        private readonly IInvoiceInboxWriteRepository _InvoiceInboxWriteRepository;


        #endregion

        #region constractor

        public InvoiceInboxWriteService(IInvoiceInboxWriteRepository InvoiceInboxWriteRepository)
        {

            _InvoiceInboxWriteRepository = InvoiceInboxWriteRepository;


        }

        #endregion

        #region Default methods

        public async Task<IResult> Register(InvoiceInboxRegisterCommand model)
        {

            var entiy = model.Map<InvoiceInbox>();

            await _InvoiceInboxWriteRepository.Insert(entiy);

            return await Result.SuccessAsync(" موفقیت ثبت شد");

        }

        public async Task<IResult> Update(InvoiceInboxUpdateCommand model)
        {

            var entity = await _InvoiceInboxWriteRepository.Get(model.Id);

            if (entity is null)
                return await Result.FailAsync(" با این مشخصات پیدا نشد.");

            model.Map(entity);

            await _InvoiceInboxWriteRepository.Update(entity);

            return await Result.SuccessAsync(" با موفقیت ویرایش شد");

        }

        public async Task<IResult> Delete(Guid id)
        {

            var entity = await _InvoiceInboxWriteRepository.Get(id);

            if (entity is null)
                return await Result.FailAsync(" با این مشخصات پیدا نشد.");

            await _InvoiceInboxWriteRepository.Delete(entity);

            return await Result.SuccessAsync(" با موفقیت حذف شد");

        }

        #endregion

    }
}

