using KSN.TPS.InvoiceHub.ApplicationService.Contract.Models.Invoice;
using KSN.TPS.InvoiceHub.Common;
using Microsoft.AspNetCore.Mvc;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Security;
using System.ComponentModel.DataAnnotations;

namespace KSN.TPS.InvoiceHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Display(Name = "فاکتور های مالیاتی", Description = "مدیریت فاکتور های مالیاتی")]
    [CustomAuthorize(AuthenticationSchemes = "Bearer")]
    [Permission("{ControllerName}", AppConsts.SystemBaseInformationName, "{ControllerTitle}")]
    public class InvoiceController : Controller
    {
        #region variables 


        public readonly IBus _busControl;
        public readonly IQueryBus _queryBus;

        #endregion

        #region Constructor 

        public InvoiceController(IBus bus, IQueryBus queryBus)
        {
            _busControl = bus;
            _queryBus = queryBus;
        }

        #endregion


        #region Register


        [HttpPost]
        [Permission("Create", "ایجاد")]
        public virtual async Task<IActionResult> Post(List<InvoiceImportFromApiVM> invoices)
        {
            return await _busControl.Send(command).ApiResultAsync();
        }

        #endregion

    }
}
