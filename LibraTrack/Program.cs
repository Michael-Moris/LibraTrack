using LibraTrack.AppDbContext;
using LibraTrack.Helper;

namespace LibraTrack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using LibraryDbContext dbContext = new();

            #region Test Connection
            //bool canConnect = dbContext.Database.CanConnect();
            //Console.WriteLine($"Can Connect to Database: {canConnect}"); 
            #endregion

            #region Seeding
            //bool Result = LibraryDbContextSeed.SeedData(dbContext);
            //Console.WriteLine(Result ? "Data Seeded Successfully!..." : "No Data Seeded!...");
            #endregion

            #region Data Manipulation

            #region Try 01: Retrieve the book title, its category title , and the author’s full name for all books whose price is greater than 300.
            //var books = dbContext.Books
            //    .Where(b => b.Price > 300)
            //    .Select(b => new
            //    {
            //        b.Title,
            //        CategoryTitle = b.Category.Title,
            //        AuthorFullName = b.Author.FirstName + " " + b.Author.LastName,
            //        price = b.Price
            //    })
            //    .ToList();

            //Console.WriteLine("Books with Price Greater than 300: \n");
            //foreach (var book in books)
            //{
            //    Console.WriteLine($"Title: {book.Title}, Category: {book.CategoryTitle}, Author: {book.AuthorFullName}, Price: {book.price}");
            //}
            #endregion

            #region Try 02: Retrieve All Authors And His/Her Books if Exists.
            //var AuthorsBooks = dbContext.Authors
            //    .Select(a => new
            //    {
            //        AuthorFullName = a.FirstName + " " + a.LastName,
            //        Books = a.Books.Select(b => b.Title).ToList()
            //    }).ToList();

            //foreach (var author in AuthorsBooks)
            //{
            //    Console.WriteLine($"Author: {author.AuthorFullName}");
            //    if (author.Books.Any())
            //    {
            //        foreach (var book in author.Books)
            //            Console.WriteLine($"\tBook: {book}.");
            //    }
            //    else
            //        Console.WriteLine("\tNo Books Found.");
            //}
            #endregion

            #region Try 03: Member with id 1 Want To Borrow The Book With Id 2 And He Will Return it After 5 Days.
            //int MemberId = 1;
            //int BookId = 2;
            //int BorrowDays = 5;

            //bool Results = LoanManagement.BorrowBook(MemberId, BookId, BorrowDays, dbContext);
            //if (Results)
            //    Console.WriteLine($"Member With Id {MemberId} Borrowed The Book With Id {BookId} For {BorrowDays} Days Successfully!...");
            //else
            //    Console.WriteLine("Book Borrowing Failed! Check The Member Status Or Book Availability...");
            #endregion

            #region Try 04: After 10 Days Member with id 1 Returned The Book.
            //int MemberId = 1;
            //int BookId = 2;

            //bool Results = LoanManagement.ReturnBook(MemberId, BookId, dbContext);
            //if (Results)
            //    Console.WriteLine($"Member With Id {MemberId} Returned The Book With Id {BookId} Successfully!...");
            //else
            //    Console.WriteLine("Book Returning Failed! Check If The Member Has Borrowed This Book...");
            #endregion

            #region Try 05: Retrieve all members who currently have active loans (i.e., loans that have not yet been returned)
            //var MembersWithActiveLoans = dbContext.Members
            //    .Where(m => dbContext.MemberLoans.Any(ml => ml.MemberId == m.Id && ml.ReturnDate == null))
            //    .ToList();
            //foreach (var member in MembersWithActiveLoans)
            //{
            //    Console.WriteLine($"Member Id: {member.Id}, Name: {member.Name}, Email: {member.Email}, Status: {member.Status}");
            //}
            #endregion

            #endregion

        }
    }
}
