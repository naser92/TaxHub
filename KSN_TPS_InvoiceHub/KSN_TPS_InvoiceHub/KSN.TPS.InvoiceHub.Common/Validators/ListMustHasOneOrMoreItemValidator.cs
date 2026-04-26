using FluentValidation;
using FluentValidation.Validators;

namespace PDN.TPS.InvoiceHub.Common.Validators
{
    public class
        ListMustHasOneOrMoreItemValidator<T, TCollectionElement> : PropertyValidator<T, IList<TCollectionElement>>
    {
        public override bool IsValid(ValidationContext<T> context, IList<TCollectionElement> list)
        {
            if (list != null && list.Count > 0)
            {
                //context.MessageFormatter.AppendArgument("MaxElements", _max);
                return false;
            }

            return true;
        }

        public override string Name => "ListMustHasOneOrMoreItemValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "{PropertyName} must contain at least one item.";
    }
}