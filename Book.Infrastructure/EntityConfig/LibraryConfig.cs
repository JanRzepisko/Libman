using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityConfigs;

internal sealed class LibraryConfig : IEntityTypeConfiguration<Book.Domain.Entities.Library>
{
    public void Configure(EntityTypeBuilder<Book.Domain.Entities.Library> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        
        builder.HasMany(c => c.Books)
            .WithOne(c => c.Library)
            .HasForeignKey(c => c.LibraryId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}