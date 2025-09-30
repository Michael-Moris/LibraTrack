using LibraTrack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraTrack.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.PhoneNumber)
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(m => m.Address)
                .HasMaxLength(100);

            builder.Property(m => m.MembershipDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(m => m.Status)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
