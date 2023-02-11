using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityConfigs;

internal sealed class BookConfig : IEntityTypeConfiguration<Book.Domain.Entities.Book>
{
    public void Configure(EntityTypeBuilder<Book.Domain.Entities.Book> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        
        builder.HasOne(c => c.Author)
            .WithMany(c => c.Books)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        }
}