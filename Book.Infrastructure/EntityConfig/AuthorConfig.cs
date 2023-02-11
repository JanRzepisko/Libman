using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityConfigs;

internal sealed class AuthorConfig : IEntityTypeConfiguration<Book.Domain.Entities.Author>
{
    public void Configure(EntityTypeBuilder<Book.Domain.Entities.Author> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        
        builder.HasMany(c => c.Books)
            .WithOne(c => c.Author)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}