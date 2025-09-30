using LibraTrack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraTrack.Configurations
{
    public class MemberLoansConfiguration : IEntityTypeConfiguration<MemberLoans>
    {
        public void Configure(EntityTypeBuilder<MemberLoans> builder)
        {
            builder.HasKey(ml => new { ml.LoanId, ml.MemberId, ml.BookId });
            builder.HasOne(ml => ml.Loan)
                   .WithMany()
                   .HasForeignKey(ml => ml.LoanId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ml => ml.Loan)
                  .WithMany()
                  .HasForeignKey(ml => ml.LoanId);

            builder.HasOne(ml => ml.Member)
                   .WithMany()
                   .HasForeignKey(ml => ml.MemberId);

            builder.HasOne(ml => ml.Book)
                   .WithMany()
                   .HasForeignKey(ml => ml.BookId);
        }
    }
}
