using KSN.TPS.InvoiceHub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDN.TPS.Framework.Persistence.EF;

namespace KSN.TPS.InvoiceHub.Persistence.Mapping
{
    public class InvoiceInboxMapping : EntityMapperBase<InvoiceInbox, Guid>
    {
        public override void Configure(EntityTypeBuilder<InvoiceInbox> builder)
        {

            base.Configure(builder);

            builder.Property(t => t.BatchId).IsRequired().HasComment("BatchId");
            builder.Property(t => t.UserContainerId).IsRequired().HasComment("UserContainerId");
            builder.Property(t => t.InvoiceNumber).HasColumnType("nvarchar").HasMaxLength(50).IsRequired().HasComment("InvoiceNumber");
            builder.Property(t => t.InvoiceDate).IsRequired().HasComment("InvoiceDate");
            builder.Property(t => t.Payload).HasColumnType("nvarcharmax").HasMaxLength(-1).IsRequired().HasComment("Payload");
            builder.Property(t => t.Status).IsRequired().HasComment("Status");
            builder.Property(t => t.ProcessResult).HasColumnType("nvarcharmax").HasMaxLength(-1).HasComment("ProcessResult");
            builder.Property(t => t.ProcessedDate).HasComment("ProcessedDate");

            builder.HasOne(x => x.Batch).WithMany(x => x.InvoiceInbox).HasForeignKey(x => x.BatchId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
