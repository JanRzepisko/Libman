using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityConfigs;

internal sealed class UserConfig : IEntityTypeConfiguration<Domain.Entities.User>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.User> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasMany(c => c.ActiveRentals)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.RelantsHistory)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c => c.Library)
            .WithMany(c => c.Users)
            .HasForeignKey(c => c.LibraryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}