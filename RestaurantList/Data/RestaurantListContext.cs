using Microsoft.EntityFrameworkCore;

namespace RestaurantList.Data
{
    // RestaurantListContext class inherits from DbContext
    public class RestaurantListContext : DbContext
    {
        // Constructor that takes DbContextOptions and passes it to the base class constructor
        public RestaurantListContext(DbContextOptions<RestaurantListContext> options) : base(options)
        {
        }
    }
}
