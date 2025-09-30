using LibraTrack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraTrack.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.Property(l => l.LoanDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(l => l.Status)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
