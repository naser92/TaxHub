using KSN.TPS.InvoiceHub.Common;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Commands;
using Microsoft.AspNetCore.Mvc;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Security;
using PDN.TPS.Framework.Web;
using System.ComponentModel.DataAnnotations;

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
    [Display(Name = "", Description = "")]
    [CustomAuthorize(AuthenticationSchemes = "Bearer")]
    [Permission("{ControllerName}", AppConsts.SystemBaseInformationName, "{ControllerTitle}")]
    [Menu(AppConsts.SystemBaseInformationName, AppConsts.SystemBaseInformationTitle)]
    public class InvoiceBatchController : BaseController
    {



        #region variables 


        public readonly IBus _busControl;
        public readonly IQueryBus _queryBus;

        #endregion

        #region Constructor 

        public InvoiceBatchController(IBus bus, IQueryBus queryBus)
        {
            _busControl = bus;
            _queryBus = queryBus;
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
        public virtual async Task<IActionResult> Get(Guid id)
        {
            var result = await _queryBus.Send<InvoiceBatchDetailCommand, object>(
                    new InvoiceBatchDetailCommand(id))
                .ApiResultAsync();
            return result;
        }

        #endregion


        //#region Get main list 

        ///// <summary>
        ///// لیست  
        ///// </summary>
        ///// <param name="parameters">
        ///// پارامتر های سفارشی سازی لیست
        ///// </param>
        //[HttpGet]
        //[Permission("List", "{ControllerName}", "{ ControllerTitle}")]
        //[Menu("{ControllerName}", "{ControllerTitle}", "List")]
        //public virtual async Task<IActionResult> Get([FromQuery] GridParameters parameters)
        //{
        //    var result = await _mediator.Send
        //            (new InvoiceBatchListCommand(parameters))
        //        .ApiResultAsync();
        //    return result;
        //}


        //#endregion


        //#region Get lookup list 

        ///// <summary>
        /////  لیست انتخاب  
        ///// </summary>
        ///// <param name="parameters">
        ///// پارامتر های سفارشی سازی لیست
        ///// </param>
        //[HttpGet]
        //[Route("Lookup")]
        ////[Permission("Lookup", "لیست انتخاب  ")]
        //public async Task<IActionResult> Lookup([FromQuery] GridParameters parameters)
        //{
        //    var result = await _mediator.Send
        //            (new InvoiceBatchLookupCommand(parameters))
        //        .ApiResultAsync();
        //    return result;
        //}



        //#endregion


        //#region Get select list 

        ///// <summary>
        ///// لیست تمام موارد  
        ///// </summary>
        //[HttpGet]
        //[Route("GetAllList")]
        ////[Permission("SelectList","لیست انتخاب")]
        //public virtual async Task<IActionResult> GetAllList()
        //{
        //    var result = await _mediator.Send(
        //            new InvoiceBatchSelectListCommand())
        //        .ApiResultAsync();
        //    return result;
        //}



        //#endregion


        //#region Register

        ///// <summary>
        ///// ثبت اطلاعات  
        ///// </summary>
        ///// <param name="command">
        ///// مشخصات  
        ///// </param>
        //[HttpPost]
        //[Permission("Create", "ایجاد")]
        //public virtual async Task<IActionResult> Post(InvoiceBatchRegisterCommand command)
        //{
        //    return await _mediator.Send(command).ApiResultAsync();
        //}



        //#endregion


        //#region Edit

        ///// <summary>
        ///// ویرایش  
        ///// </summary>
        ///// <param name="command">
        ///// مشخصات  
        ///// </param>
        //[HttpPut]
        //[Permission("Update", "ویرایش")]
        //public virtual async Task<IActionResult> Put(InvoiceBatchUpdateCommand command)
        //{
        //    return await _mediator.Send(command).ApiResultAsync();
        //}


        //#endregion


        //#region Delete

        ///// <summary>
        ///// حذف  
        ///// </summary>
        ///// <param name="id">
        ///// شناسه  
        ///// </param>
        //[HttpDelete]
        //[Route("{id}")]
        //[Permission("Delete", "حذف")]
        //public virtual async Task<IActionResult> Delete(int id)
        //{
        //    return await _mediator.Send(new InvoiceBatchDeleteCommand(id)).ApiResultAsync();
        //}


        //#endregion



    }
}
