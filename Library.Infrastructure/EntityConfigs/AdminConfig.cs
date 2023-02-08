using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityConfigs;

internal sealed class LibraryConfig : IEntityTypeConfiguration<Domain.Entities.Library>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Library> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        
        builder.HasMany(C => C.Books)
            .WithOne(C => C.Library)
            .HasForeignKey(C => C.LibraryId)
            .OnDelete(DeleteBehavior.Cascade);      
        
        builder.HasMany(C => C.Books)
            .WithOne(C => C.Library)
            .HasForeignKey(C => C.LibraryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}