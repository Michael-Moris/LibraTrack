using Microsoft.EntityFrameworkCore;
using LibraTrack.Helper;
using LibraTrack.Models;

namespace LibraTrack.AppDbContext
{
    public static class LibraryDbContextSeed
    {
        public static bool SeedData(LibraryDbContext dbContext)
        {
            try
            {
                dbContext.Database.Migrate();
                bool HasAuthor = dbContext.Authors.Any();
                bool HasBook = dbContext.Books.Any();
                bool HasCategory = dbContext.Categories.Any();
                bool HasMember = dbContext.Members.Any();
                if (HasAuthor && HasBook && HasCategory && HasMember)
                    return false;

                if (!HasAuthor)
                {
                    var Authors = JsonSeeder.LoadDataFromJsonFile<Author>("Files/Authors.json");
                    dbContext.Authors.AddRange(Authors);
                }
                if (!HasCategory)
                {
                    var Categories = JsonSeeder.LoadDataFromJsonFile<Category>("Files/Categories.json");
                    dbContext.Categories.AddRange(Categories);
                }
                dbContext.SaveChanges();
                if (!HasBook)
                {
                    var Books = JsonSeeder.LoadDataFromJsonFile<Book>("Files/Books.json");
                    dbContext.Books.AddRange(Books);
                }
                if (!HasMember)
                {
                    var Members = JsonSeeder.LoadDataFromJsonFile<Member>("Files/Members.json");
                    dbContext.Members.AddRange(Members);
                }

                int RowsAffected = dbContext.SaveChanges();
                return RowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An Error Occurred While Seeding Data: {ex.Message}");
                return false;
            }
        }
    }
}
