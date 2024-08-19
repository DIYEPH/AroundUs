using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.Configurations
{
    internal sealed class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable(TableNames.AppRoles);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .HasMaxLength(250)
                .IsRequired(true);
            builder.Property(x => x.Id)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.RoleId)
                .IsRequired();
            builder.HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(e => e.RoleId)
                .IsRequired();
        }
    }
}
