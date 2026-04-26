using FluentValidation;
using KSN.TPS.InvoiceHub.ApplicationService.Contract.Models.Invoice;
using PDN.TPS.InvoiceHub.Common.Validators;

namespace KSN.TPS.InvoiceHub.ApplicationService.Contract.Validators.Invoice
{
    public class InvoiceImportFromApiValidator : AbstractValidator<InvoiceImportFromApiVM>
    {
        public InvoiceImportFromApiValidator()
        {
            RuleFor(x => x.InvoiceNumber).NotEmpty().Length(1, 50).IsValidInvoiceNumber().WithName("شماره صورتحساب");
            RuleFor(x => x.InvoiceDate).IsDateBigerThanToday().WithName("تاریخ صورتحساب");
            RuleFor(x => x.TaxSerialNumber).IsNullOrValidTaxSerialNumber().WithName("شماره منحصر به فرد مالیاتی ");


            RuleFor(x => x.BuyerNationalCode).IsEmptyOrValidNationalCode().WithName("شناسه ملی خریدار");
            RuleFor(x => x.BuyerEconomicCode).IsEmptyOrValidEconomicCode().WithName("کد اقتصادی خریدار");
            RuleFor(x => x.BuyerPostalCode).IsEmptyOrValidPostalcode().WithName("کد پستی خریدار");
            RuleFor(x => x.BuyerBranch).IsNumeric().Length(4).WithName("کد شعبه خریدار");
            RuleFor(x => x.BillId).IsNumeric().IsNullOrValidBillid().WithName("شماره اشتراک /شناسه قبض بهره بردار");

            RuleFor(x => x.SellerBranch).IsNumeric().Length(4).WithName("کد شعبه فروشنده");


            RuleFor(x => x.CustomsDeclarationCottageNumber).Length(4, 10).IsNumeric().WithName("شماره کوتاژ اظهارنامه گمرکی");

            RuleFor(x => x.PassengerPassportNumber).IsEmptyOrValidPassportNumber().WithName("شماره گذرنامه مسافر");
            RuleFor(x => x.PassengerNationalCode).IsEmptyOrValidNationalCode().WithName("شماره ملی و یا کد فراگیر مسافر");

            RuleFor(x => x.BuyerPassportNumber).IsEmptyOrValidPassportNumber().WithName("شماره گذرنامه خریدار");

            RuleFor(x => x.AgencyEconomicCode).IsEmptyOrValidEconomicCode().WithName("شماره اقتصادی آژانس");
            RuleFor(x => x.SellerCustomsLicenseNumber).IsNumeric().MaximumLength(14).WithName("شماره پروانه گمرکی فروشنده");
            RuleFor(x => x.SellerCustomsDeclarationNumber).IsNumeric().Length(5).WithName("کد گمرک محل اظهار فروشنده");
            RuleFor(x => x.SellerContractRegistrationNumber).IsNumeric().IsNullOrValidSellerContractRegistrationNumber().WithName("شناسه یکتای ثبت قرارداد فروشنده");


            RuleFor(x => x.SalesAnnouncementNumber).IsNullOrValidSalesAnnouncementNumber().IsNumeric().IsValidInvoiceNumber().WithName("شماره اعلامیه فروش بورس");
            //RuleFor(x => x.SalesAnnouncementDate).IsDateBigerThanToday().WithName("تاریخ اعلامیه فروش بورس");
            //RuleFor(x => x.SellerEconomicCode).Length(11, 14).IsNumeric().WithName("شماره اقتصادی فروشنده");
            RuleFor(x => x.SellerFiscalid).IsValidFiscalid().WithName("شناسه حافظه");
            RuleFor(x => x.ReferenceTaxSerialNumber).IsNullOrValidTaxSerialNumber().WithName("شماره منحصر به فرد مالیاتی صورتحساب مرجع");



            RuleFor(t => t.LadingNumber).IsNumeric().MinimumLength(3).MaximumLength(18).WithName("شماره بارنامه");
            RuleFor(t => t.CarrierNumber).MinimumLength(3).MaximumLength(20).WithName("شماره ناوگان");
            RuleFor(t => t.ReferenceLadingNumber).IsNumeric().MinimumLength(3).MaximumLength(18).WithName("شماره بارنامه مرجع");
            RuleFor(x => x.TransmitterNationalCode).IsEmptyOrValidNationalCode().WithName("شناسه ملی/ شماره ملی/ شناسه مشارکت مدنی/ کد فراگیر اتباع غیر ایرانی فرستنده");
            RuleFor(x => x.ReceiverNationalCode).IsEmptyOrValidNationalCode().WithName("شناسه ملی/ شماره ملی/ شناسه مشارکت مدنی/ کد فراگیر اتباع غیر ایرانی گیرنده");
            RuleFor(x => x.DriverNationalCode).IsEmptyOrValidNationalCode().WithName("کد ملی / کد فراگیر اتباع غیر ایرانی راننده ( در حمل ونقل جاده ای)");
            RuleFor(x => x.OriginCountryCode).IsNullOrValidCountryCode().WithName("کشور مبدا");
            RuleFor(x => x.DestinationCountryCode).IsNullOrValidCountryCode().WithName("کشور مقصد");
            RuleFor(x => x.OriginCityCode).IsNullOrValidCityCode().WithName("شهر مبدا");
            RuleFor(x => x.DestinationCityCode).IsNullOrValidCityCode().WithName("شهر مقصد");

            RuleFor(x => x.InsurancePolicyNumber).IsNumeric().HasDangerChar().IsNullOrValidInsurancePolicyNumber().WithName("شناسه یکتای بیمه نامه");
            RuleFor(x => x.InsuranceAttachmentNumber).IsNumeric().HasDangerChar().IsNullOrValidInsuranceAttachmentNumber().WithName("شناسه یکتای الحاقیه");
            RuleFor(x => x.Description).HasDangerChar().MaximumLength(500).WithName("توضیحات");
            RuleFor(x => x.BuyerBusinessName).HasDangerCharForNames().WithName("نام و نام خانوادگی/عنوان کسب و کار خریدار");
            RuleFor(x => x.BuyerCompanyName).HasDangerCharForNames().WithName("نام شرکت");
            RuleFor(x => x.BuyerFirstName).HasDangerCharForNames().WithName("نام خریدار");
            RuleFor(x => x.BuyerLastName).HasDangerCharForNames().WithName("نام خانوادگی خریدار");

            RuleForEach(x => x.InvoiceItems).SetValidator(new InvoiceItemImportFromApiValidator());
            RuleForEach(x => x.InvoicePayments).SetValidator(new InvoicePaymentImportFromApiValidator());
            RuleForEach(x => x.InvoiceShippedGoods).SetValidator(new InvoiceShippedGoodsImportFromApiValidator());
        }
    }
}
