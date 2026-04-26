
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using PDN.TPS.Framework.Core.Security;
using PDN.TPS.Framework.ViewModels;
using PDN.TPS.Framework.Web;
using KSN.TPS.InvoiceHub.ApplicationService.Contract.Commands;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Commands;

namespace KSN.TPS.InvoiceHub.Api.Controllers
{
            
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    [Display(Name = "",Description ="")]
    [CustomAuthorize(AuthenticationSchemes = "Bearer")]
    [Permission("{ControllerName}", AppConsts.SystemBaseInformationName, "{ControllerTitle}")]
    [Menu(AppConsts.SystemBaseInformationName, AppConsts.SystemBaseInformationTitle)]
    public class InvoiceInboxController : BaseController
    {
  


        #region variables 

        private readonly IMediator _mediator;

        #endregion

        #region Constructor 

        public InvoiceInboxController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Get by Id
        
        /// <summary>
        /// دریافت جزئیات  
        /// </summary>
        /// <param name="id">
        /// شناسه  
        /// </param>
        [HttpGet]
        [Route("{id}")]
        [Permission("Detail", "جزئیات")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(
                    new InvoiceInboxDetailCommand(id))
                .ApiResultAsync();
            return result;
        }

        #endregion


        #region Get main list 

        /// <summary>
        /// لیست  
        /// </summary>
        /// <param name="parameters">
        /// پارامتر های سفارشی سازی لیست
        /// </param>
        [HttpGet]
        [Permission("List", "{ControllerName}", "{ ControllerTitle}")]
        [Menu("{ControllerName}", "{ControllerTitle}", "List")]
        public virtual async Task<IActionResult> Get([FromQuery] GridParameters parameters)
        {
            var result = await _mediator.Send
                    (new InvoiceInboxGridCommand(parameters))
                .ApiResultAsync();
            return result;
        }


        #endregion


        #region Get lookup list 

        /// <summary>
        ///  لیست انتخاب  
        /// </summary>
        /// <param name="parameters">
        /// پارامتر های سفارشی سازی لیست
        /// </param>
        [HttpGet]
        [Route("Lookup")]
        //[Permission("Lookup", "لیست انتخاب  ")]
        public async Task<IActionResult> Lookup([FromQuery] GridParameters parameters)
        {
            var result = await _mediator.Send
                    (new InvoiceInboxLookupCommand(parameters))
                .ApiResultAsync();
            return result;
        }



        #endregion


        #region Get select list 

        /// <summary>
        /// لیست تمام موارد  
        /// </summary>
        [HttpGet]
        [Route("GetAllList")]
        //[Permission("SelectList","لیست انتخاب")]
        public virtual async Task<IActionResult> GetAllList()
        {
            var result = await _mediator.Send(
                    new InvoiceInboxSelectListCommand())
                .ApiResultAsync();
            return result;
        }



        #endregion


        #region Register

        /// <summary>
        /// ثبت اطلاعات  
        /// </summary>
        /// <param name="command">
        /// مشخصات  
        /// </param>
        [HttpPost]
        [Permission("Create", "ایجاد")]
        public virtual async Task<IActionResult> Post(InvoiceInboxRegisterCommand command)
        {
            return await _mediator.Send(command).ApiResultAsync();
        }



        #endregion


        #region Edit

        /// <summary>
        /// ویرایش  
        /// </summary>
        /// <param name="command">
        /// مشخصات  
        /// </param>
        [HttpPut]
        [Permission("Update", "ویرایش")]
        public virtual async Task<IActionResult> Put(InvoiceInboxUpdateCommand command)
        {
            return await _mediator.Send(command).ApiResultAsync();
        }


        #endregion


        #region Delete

        /// <summary>
        /// حذف  
        /// </summary>
        /// <param name="id">
        /// شناسه  
        /// </param>
        [HttpDelete]
        [Route("{id}")]
        [Permission("Delete", "حذف")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            return await _mediator.Send(new InvoiceInboxDeleteCommand(id)).ApiResultAsync();
        }


        #endregion

            

    }
}
