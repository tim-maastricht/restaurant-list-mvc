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

            modelBuilder.Entity<Restaurant>().HasData(
                // this is seeding the database with an initial restaurant entry, which will be added to the Restaurants table when the database is created or updated
                new Restaurant
                {
                    Id = 1,
                    Name = "Gourmet Pizzeria",
                    Address = "1234 Culinary St, Flavour, CA 90210",
                    ImageUrl = "https://www.whereyoueat.com/r_gallery_images/rgallery-21635/Best_Italian_Pizza2.jpg"
                }
            );

            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = 1,
                    Name = "Pizza",
                    Price = 10
                },
                new Dish
                {
                    Id = 2,
                    Name = "Pasta",
                    Price = 9
                }
            );

            modelBuilder.Entity<RestaurantDish>().HasData(
                // this is seeding the RestaurantDishes table with two entries that link the restaurant with id 1 to the dishes with ids 1 and 2
                // establishing a many-to-many relationship between the restaurant and its dishes
                new RestaurantDish
                {
                    RestaurantId = 1,
                    DishId = 1
                },
                new RestaurantDish
                {
                    RestaurantId = 1,
                    DishId = 2
                }
            );

            base.OnModelCreating(modelBuilder);
        }
        // each DbSet corresponds to a table in the database
        // DbSet acts as a bridge between our code and database, allowing us to perform CRUD operations on the entities
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<RestaurantDish> RestaurantDishes { get; set; }
    }
}
