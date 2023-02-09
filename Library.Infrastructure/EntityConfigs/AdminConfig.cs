using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityConfigs;

internal sealed class AdminConfig : IEntityTypeConfiguration<Domain.Entities.Admin>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Admin> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        
        builder.HasOne(c => c.Library)
            .WithMany(c => c.Admins)
            .HasForeignKey(c => c.LibraryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}