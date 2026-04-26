using KSN.TPS.InvoiceHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDN.TPS.Framework.Persistence.EF;

namespace KSN.TPS.InvoiceHub.Persistence.Mapping
{
    public class InvoiceBatchMapping : EntityMapperBase<InvoiceBatch, Guid>
    {
        public override void Configure(EntityTypeBuilder<InvoiceBatch> builder)
        {

            base.Configure(builder);

            builder.Property(t => t.InsertBaseType).IsRequired().HasComment("InsertBaseType");
            builder.Property(t => t.UserContainerId).IsRequired().HasComment("UserContainerId");
            builder.Property(t => t.CreatedUserId).IsRequired().HasComment("CreatedUserId");
            builder.Property(t => t.FileName).HasColumnType("nvarchar").HasMaxLength(255).HasComment("FileName");
            builder.Property(t => t.TotalInvoiceCount).IsRequired().HasComment("TotalInvoiceCount");


        }
    }
}
