using LibraTrack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraTrack.Configurations
{
    public class FineConfiguration : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            builder.Property(f => f.Amount)
                .HasColumnType("decimal(6,2)");

            builder.Property(f => f.IssuedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(f => f.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(f => f.Loan)
                .WithOne(l => l.Fine)
                .HasForeignKey<Fine>(f => f.LoanId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
