using LibraTrack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraTrack.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Description)
                   .HasMaxLength(100);

            builder.HasMany(c => c.Books)
                   .WithOne(b => b.Category)
                   .HasForeignKey(b => b.CategoryId);
        }
    }
}
