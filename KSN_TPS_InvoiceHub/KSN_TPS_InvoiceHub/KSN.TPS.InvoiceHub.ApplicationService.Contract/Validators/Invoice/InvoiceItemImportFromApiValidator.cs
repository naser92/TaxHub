using FluentValidation;
using KSN.TPS.InvoiceHub.ApplicationService.Contract.Models.Invoice;
using PDN.TPS.Framework.Validator;
using PDN.TPS.InvoiceHub.Common.Validators;

namespace KSN.TPS.InvoiceHub.ApplicationService.Contract.Validators.Invoice
{
    public class InvoiceItemImportFromApiValidator : AbstractValidator<InvoiceItemImportFromApiVM>
    {
        public InvoiceItemImportFromApiValidator()
        {

            RuleFor(x => x.CommodityCode).IsCorrectValueFormat().Length(1, 30).WithName("کد کالا/خدمات");
            RuleFor(x => x.TaxPercent).GreaterThanOrEqualTo(0).WithName("نرخ مالیات بر ارزش افزوده");
            RuleFor(x => x.ExchangeContractNumber).MaximumLength(13).WithName("شماره قرارداد بورس");
            RuleFor(x => x.Cutie).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1000).DecimalPointMaxLength(2).WithName("عیار");
            RuleFor(x => x.Discount).DecimalPointMaxLength(0).WithName("مبلغ تخفیف");
            RuleFor(x => x.ExtendStuffTitle).HasDangerChar().MaximumLength(200).IsNullOrValidCommodityServiceTitle().WithName("شرح اضافی کالا/خدمت");
            RuleFor(x => x.BrokerContractNumber).IsNumeric().IsNullOrValidSellerContractRegistrationNumber().WithName("شناسه یکتای ثبت قرارداد حق العمل کار");
            RuleFor(x => x.Stuffid).IsNumeric().IsNullOrValidStuffid().WithName("شناسه عمومی کالا/خدمت");
            RuleFor(x => x.StuffTitle).Length(2, 400).HasDangerChar().WithName("شرح کالا/خدمت");
            RuleFor(x => x.MoneyISOCode).IsNotNumeric().Length(3).WithName("نوع ارز");
            RuleFor(x => x.DutyTitle).HasDangerCharForNames().WithName("موضوع سایر مالیات و عوارض");
            RuleFor(x => x.OtherLegalFundsTitle).HasDangerCharForNames().WithName("موضوع سایر وجوه قانونی");
            //RuleFor(x => x.HSCode).Length(4, 10).WithName("کد HS قلم کالا");
            //RuleFor(x => x.VatBaseAmount).DecimalPointMaxLength(8).WithName("مبلغ پایه مالیات بر ارزش افزوده");

        }
    }
}
