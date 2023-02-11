using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityConfigs;

internal sealed class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        
        builder.HasOne(c => c.Library)
            .WithMany(c => c.Books)
            .HasForeignKey(c => c.LibraryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.RentalsHistory)
            .WithOne(c => c.Book)
            .HasForeignKey(c => c.BookId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}