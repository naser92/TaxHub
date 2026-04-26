using FluentValidation;
using KSN.TPS.InvoiceHub.ApplicationService.Contract.Models.Invoice;
using PDN.TPS.InvoiceHub.Common.Validators;

namespace KSN.TPS.InvoiceHub.ApplicationService.Contract.Validators.Invoice
{
    public class InvoicePaymentImportFromApiValidator : AbstractValidator<InvoicePaymentImportFromApiVM>
    {
        public InvoicePaymentImportFromApiValidator()
        {

            RuleFor(x => x.PaymentAmount).NotEmpty().WithName("مبلغ پرداختی");

            RuleFor(x => x.SwitchNumber).Length(9).IsNumeric().WithName("شماره سوییچ");
            RuleFor(x => x.AcceptanceNumber).Length(14, 15).IsNumeric().WithName("شماره پذیرنده");
            RuleFor(x => x.TerminalNumber).Length(8).IsNumeric().WithName("شماره ترمینال");
            RuleFor(x => x.TraceNumber).MaximumLength(36).IsNumeric().WithName("کد ره گیری");
            RuleFor(x => x.PayerCardNumber).Length(16).IsNumeric().WithName("شماره کارت پرداخت کننده");
            RuleFor(x => x.PayerNationalCode).Length(10, 11).IsEmptyOrValidNationalCode().WithName("شماره ملی پرداخت کننده");
            RuleFor(x => x.Description).HasDangerChar().MaximumLength(200).WithName("توضیحات");

            //RuleFor(x => x.VatPaymentId).IsNumeric().Length(6, 13).WithName("شناسه پرداخت");
            //RuleFor(x => x.VatBillId).IsNumeric().Length(6, 13).WithName("شناسه قبض پرداخت");
        }
    }
}
