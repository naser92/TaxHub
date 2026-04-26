using FluentValidation;
using KSN.TPS.InvoiceHub.ApplicationService.Contract.Models.Invoice;
using PDN.TPS.InvoiceHub.Common.Validators;

namespace KSN.TPS.InvoiceHub.ApplicationService.Contract.Validators.Invoice
{
    public class InvoiceShippedGoodsImportFromApiValidator : AbstractValidator<InvoiceShippedGoodsImportFromApiVM>
    {
        public InvoiceShippedGoodsImportFromApiValidator()
        {

            RuleFor(x => x.Stuffid).IsNumeric().IsValidStuffid().WithName("شناسه کالای حمل شده");
            RuleFor(x => x.StuffTitle).HasDangerChar().Length(2, 400).WithName("شرح کالای حمل شده");
            RuleFor(x => x.Description).HasDangerChar().Length(2, 200).WithName("توضیحات");
        }
    }
}
