using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        private const string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OdeToFood;Integrated Security=True;";

        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
             : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
