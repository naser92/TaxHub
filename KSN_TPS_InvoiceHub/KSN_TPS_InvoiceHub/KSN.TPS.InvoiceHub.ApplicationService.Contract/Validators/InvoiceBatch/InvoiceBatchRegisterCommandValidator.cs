using FluentValidation;
using KSN.TPS.InvoiceHub.ApplicationService.Commands;


namespace KSN.TPS.InvoiceHub.ApplicationService.Valisators
{
    public class InvoiceBatchRegisterCommandValidator : AbstractValidator<InvoiceBatchRegisterCommand>
    {
        public InvoiceBatchRegisterCommandValidator()
        {


            RuleFor(x => x.InsertBaseType).NotEmpty().WithName("InsertBaseType");
            RuleFor(x => x.UserContainerId).NotEmpty().WithName("UserContainerId");
            RuleFor(x => x.CreatedUserId).NotEmpty().WithName("CreatedUserId");
            RuleFor(x => x.FileName).NotEmpty().Length(2, 255).WithName("FileName");
            RuleFor(x => x.TotalInvoiceCount).NotEmpty().WithName("TotalInvoiceCount");

        }
    }
}

