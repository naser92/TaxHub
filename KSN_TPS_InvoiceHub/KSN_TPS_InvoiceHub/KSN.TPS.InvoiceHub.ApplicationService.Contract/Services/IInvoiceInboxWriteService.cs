using KSN.TPS.InvoiceHub.ApplicationService.Commands;
using PDN.TPS.Framework.Core.Results;
using PDN.TPS.Framework.Core.Service;



namespace KSN.TPS.InvoiceHub.ApplicationService.Services
{
    public interface IInvoiceInboxWriteService : IBaseService
    {

        #region Default methods

        Task<IResult> Register(InvoiceInboxRegisterCommand model);

        Task<IResult> Update(InvoiceInboxUpdateCommand model);

        Task<IResult> Delete(Guid id);

        #endregion

    }
}

