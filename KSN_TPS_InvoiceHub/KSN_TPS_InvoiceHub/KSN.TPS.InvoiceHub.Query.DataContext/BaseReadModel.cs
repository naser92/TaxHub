using PDN.TPS.Framework.Domain;

namespace KSN.TPS.InvoiceHub.Query.DataContext
{
    public class BaseReadModel<Tkey> : FullEntity<Tkey>
    {
        public BaseReadModel()
        {
        }


        public Guid? CreatedByUserId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? ModifiedByUserId { get; set; }

        public DateTime? DeletedDate { get; set; }

        public Guid? DeletedByUserId { get; set; }
    }
}
