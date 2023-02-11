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
        
        builder.HasMany(c => c.Books)
            .WithOne(c => c.Library)
            .HasForeignKey(c => c.LibraryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.Admins)
            .WithOne(c => c.Library)
            .HasForeignKey(c => c.LibraryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.Users)
            .WithOne(c => c.Library)
            .HasForeignKey(c => c.LibraryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Rentals)
            .WithOne(c => c.Library)
            .HasForeignKey(c => c.LibraryId)
            .OnDelete(DeleteBehavior.Cascade);     
        
        builder.HasMany(c => c.RentalsHistory)
            .WithOne(c => c.Library)
            .HasForeignKey(c => c.LibraryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}