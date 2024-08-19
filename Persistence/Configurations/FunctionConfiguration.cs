using Domain.Entities.Identity;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.Configurations
{
    internal sealed class FunctionConfiguration : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.ToTable(TableNames.Functions);

            builder.Property(x => x.Id).HasDefaultValue(0);
            builder.Property(x => x.Code).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Key).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.ActionValue).IsRequired(true);
            builder.Property(x => x.ParentId).HasDefaultValue(-1);
            builder.Property(x => x.CssClass).HasMaxLength(10).IsRequired(true);
            builder.Property(x => x.Url).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Status).HasDefaultValue(FunctionStatus.Active);
            builder.Property(x => x.SortOrder).HasDefaultValue(-1);
            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.ModifiedDate).IsRequired(true);
        }
    }
}
