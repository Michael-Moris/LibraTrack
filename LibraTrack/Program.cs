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

        }
    }
}
