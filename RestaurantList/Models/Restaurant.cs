namespace RestaurantList.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        // a restaurant can offer multiple dishes, so we need a list of RestaurantDish to represent the many-to-many relationship
        public List<RestaurantDish>? RestaurantDishes { get; set; }
    }
}
