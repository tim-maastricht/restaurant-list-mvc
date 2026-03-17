using Microsoft.EntityFrameworkCore;
using RestaurantList.Models;

namespace RestaurantList.Data
{
    // RestaurantListContext class inherits from DbContext
    public class RestaurantListContext : DbContext
    {
        // Constructor that takes DbContextOptions and passes it to the base class constructor
        public RestaurantListContext(DbContextOptions<RestaurantListContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // defines composite key for the RestaurantDish entity/ helper model using RestaurantId and DishId
            modelBuilder.Entity<RestaurantDish>().HasKey(rd => new { rd.RestaurantId, rd.DishId });

            modelBuilder.Entity<RestaurantDish>()
                .HasOne(r => r.Restaurant)
                .WithMany(rd => rd.RestaurantDishes)
                .HasForeignKey(r => r.RestaurantId);

            modelBuilder.Entity<RestaurantDish>()
               .HasOne(d => d.Dish)
               .WithMany(rd => rd.RestaurantDishes)
               .HasForeignKey(d => d.DishId);

            base.OnModelCreating(modelBuilder);
        }
        // each DbSet corresponds to a table in the database
        // DbSet acts as a bridge between our code and database, allowing us to perform CRUD operations on the entities
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<RestaurantDish> RestaurantDishes { get; set; }
    }
}
