namespace RestaurantList.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        // a dish can be offered in multiple restaurants, so we need a list of RestaurantDish to represent the many-to-many relationship
        public List<RestaurantDish>? RestaurantDishes { get; set; }
    }
}
