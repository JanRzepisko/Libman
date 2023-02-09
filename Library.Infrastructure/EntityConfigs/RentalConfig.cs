using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityConfigs;

internal sealed class RentalConfig : IEntityTypeConfiguration<Domain.Entities.Rental>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Rental> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasOne(c => c.User)
            .WithMany(c => c.ActiveRelant)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c => c.Library)
            .WithMany(c => c.Rentals)
            .HasForeignKey(c => c.LibraryId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}