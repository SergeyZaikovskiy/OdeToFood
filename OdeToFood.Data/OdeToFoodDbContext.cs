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

        //public OdeToFoodDbContext(DbContextOptions options) : base(options)
        //{
        //}

        //public OdeToFoodDbContext()
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    if (options.IsConfigured)
        //    {
        //        return;
        //    }

        //    options.UseSqlServer(_connectionString);
        //}


        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
