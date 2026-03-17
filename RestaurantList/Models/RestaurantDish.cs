namespace RestaurantList.Models
{
    public class RestaurantDish
    {
        // this is the join entity/ helper class for the many-to-many relationship between Restaurant and Dish
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
