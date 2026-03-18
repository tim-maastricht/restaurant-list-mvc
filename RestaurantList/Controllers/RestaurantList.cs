using Microsoft.AspNetCore.Mvc;
using RestaurantList.Data;
using RestaurantList.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantList.Controllers
{
    public class RestaurantList : Controller
    {
        private readonly RestaurantListContext _context;
        public RestaurantList(RestaurantListContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            // this is a LINQ query to get all restaurants from the database, and if a search string is provided, filter the restaurants by name
            var restaurants = from r in _context.Restaurants select r;

            if (!string.IsNullOrEmpty(searchString))
            {
                restaurants = restaurants.Where(r => r.Name.Contains(searchString));
            }
            // this is like an SQL filter that will be applied to the query, and the results will be returned as a list to the view
            return View(await restaurants.ToListAsync());
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            var restaurant = await _context.Restaurants
                .Include(rd => rd.RestaurantDishes)
                .ThenInclude(d => d.Dish)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }
    }
}
