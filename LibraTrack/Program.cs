using LibraTrack.AppDbContext;

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

            #endregion

        }
    }
}
