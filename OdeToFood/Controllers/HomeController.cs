using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModel;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurant _restaurant;
        private IGreeter _greeter;

        public HomeController(IRestaurant restaurant, IGreeter greeter)
        {
            _restaurant = restaurant;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurant.GetAll();
            model.MessageOfTheDay = _greeter.Greet();

            return View(model);
        }
        
        public IActionResult Detail(int id)
        {
            var restaurant = _restaurant.Get(id);

            if (restaurant == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(restaurant);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var restaurant = new Restaurant {
                Name = model.Name,
                Cusine = model.Cusine
            };
            _restaurant.Add(restaurant);

            return RedirectToAction("Detail", new { id = restaurant.Id });
        }
    }
}