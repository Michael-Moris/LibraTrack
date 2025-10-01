using LibraTrack.AppDbContext;
using LibraTrack.Models;
using LibraTrack.Models.Enum;
using Microsoft.EntityFrameworkCore;

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

        public static bool ReturnBook(int MemberId, int BookId, LibraryDbContext dbContext)
        {
            // Return MemberLoan
            var MemberLoan = dbContext.MemberLoans
                .Include(l => l.Loan)
                .Include(b => b.Book)
                .FirstOrDefault(ml => ml.MemberId == MemberId && ml.BookId == BookId && ml.ReturnDate == null);

            // Check MemberLoan
            if (MemberLoan is null)
                return false;

            // Set ReturnDate of MemberLoan
            MemberLoan.ReturnDate = DateTime.Now;

            // Return Book [AvailableCopies +1]
            MemberLoan.Book.AvailableCopies += 1;

            // Calculate Fine if ReturnDate > DueDate
            if (MemberLoan.ReturnDate > MemberLoan.DueDate)
            {
                var DaysLate = (MemberLoan.ReturnDate.Value - MemberLoan.DueDate).Days;
                decimal DailyFine = 0.1M * MemberLoan.Book.Price; // 10% of Book Price per day
                var Fine = new Fine
                {
                    Amount = DailyFine * DaysLate,
                    Loan = MemberLoan.Loan
                };
                dbContext.Fines.Add(Fine);
                MemberLoan.Loan.Status = LoanStatus.Overdue;
                var Member = dbContext.Members.FirstOrDefault(m => m.Id == MemberLoan.MemberId);
                Member.Status = MemberStatus.Suspended;
            }
            else
            {
                MemberLoan.Loan.Status = LoanStatus.Returned;
            }

            dbContext.SaveChanges();
            return true;
        }

    }
}
