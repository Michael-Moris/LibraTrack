using LibraTrack.AppDbContext;
using LibraTrack.Models;
using LibraTrack.Models.Enum;

namespace LibraTrack.Helper
{
    public static class LoanManagement
    {
        public static bool BorrowBook(int MemberId, int BookId, int BorrowDays, LibraryDbContext dbContext)
        {
            using var Transaction = dbContext.Database.BeginTransaction();
            try
            {
                // Check if Member Exists and is Active
                var Member = dbContext.Members.Find(MemberId);
                if (Member is null || Member.Status == MemberStatus.Suspended)
                    return false;

                // Check if Book Exists and is Available
                var Book = dbContext.Books.Find(BookId);
                if (Book is null || Book.AvailableCopies == 0)
                    return false;

                // Create a New Loan Record
                var Loan = new Loan();
                dbContext.Loans.Add(Loan);
                dbContext.SaveChanges();

                // Create a New MemberLoans (LoanId, MemberId, BookId)
                var MemberLoan = new MemberLoans
                {
                    BookId = BookId,
                    LoanId = Loan.Id,
                    MemberId = MemberId,
                    DueDate = DateTime.Now.AddDays(BorrowDays)
                };

                //Add MemberLoan
                dbContext.MemberLoans.Add(MemberLoan);

                // Decrease the AvailableCopies of the Book by 1
                Book.AvailableCopies -= 1;
                dbContext.SaveChanges();
                Transaction.Commit();
                return true;
            }
            catch
            {
                Transaction.Rollback();
                return false;
            }
        }
    }
}
