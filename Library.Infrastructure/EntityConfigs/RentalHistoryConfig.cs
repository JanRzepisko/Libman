using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityConfigs;

internal sealed class RentalHistoryConfig : IEntityTypeConfiguration<Domain.Entities.RentalHistory>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.RentalHistory> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasOne(c => c.Book)
            .WithMany(c => c.RentalsHistory)
            .HasForeignKey(c => c.BookId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c => c.User)
            .WithMany(c => c.RelantsHistory)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c => c.Library)
            .WithMany(c => c.RentalsHistory)
            .HasForeignKey(c => c.LibraryId)
            .OnDelete(DeleteBehavior.Cascade); 
        
    }
}