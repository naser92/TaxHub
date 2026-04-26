using FluentValidation;
using KSN.TPS.InvoiceHub.ApplicationService.Commands;


namespace KSN.TPS.InvoiceHub.ApplicationService.Valisators
{
    public class InvoiceInboxUpdateCommandValidator : AbstractValidator<InvoiceInboxUpdateCommand>
    {
        public InvoiceInboxUpdateCommandValidator()
        {


            RuleFor(x => x.Id).NotEmpty().WithName("شناسه");
            RuleFor(x => x.BatchId).NotEmpty().WithName("BatchId");
            RuleFor(x => x.UserContainerId).NotEmpty().WithName("UserContainerId");
            RuleFor(x => x.InvoiceNumber).Length(2, 50).WithName("InvoiceNumber");
            RuleFor(x => x.InvoiceDate).NotEmpty().WithName("InvoiceDate");
            RuleFor(x => x.Payload).Length(2, -1).WithName("Payload");
            RuleFor(x => x.Status).NotEmpty().WithName("Status");
            RuleFor(x => x.ProcessResult).NotEmpty().Length(2, -1).WithName("ProcessResult");
            // RuleFor(x => x.ProcessedDate).WithName("ProcessedDate");

        }
    }
}

