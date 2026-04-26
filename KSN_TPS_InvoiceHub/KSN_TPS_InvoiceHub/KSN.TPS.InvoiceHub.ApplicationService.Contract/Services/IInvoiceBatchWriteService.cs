using KSN.TPS.InvoiceHub.ApplicationService.Commands;
using PDN.TPS.Framework.Core.Results;
using PDN.TPS.Framework.Core.Service;



namespace KSN.TPS.InvoiceHub.ApplicationService.Services
{
    public interface IInvoiceBatchWriteService : IBaseService
    {

        #region Default methods

        Task<IResult> Register(InvoiceBatchRegisterCommand model);

        Task<IResult> Update(InvoiceBatchUpdateCommand model);

        Task<IResult> Delete(Guid id);

        #endregion

    }
}

