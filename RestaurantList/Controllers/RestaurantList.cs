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

        public async Task<IActionResult> Index()
        {
            return View(await _context.Restaurants.ToListAsync());
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
