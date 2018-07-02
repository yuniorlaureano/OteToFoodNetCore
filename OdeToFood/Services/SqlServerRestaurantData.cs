using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class SqlServerRestaurantData : IRestaurant
    {
        private OdeFoodDbContext context;

        public SqlServerRestaurantData(OdeFoodDbContext _context)
        {
            context = _context;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
            context.SaveChanges();

            return restaurant;
        }

        public Restaurant Get(int id)
        {
            Restaurant model = context.Restaurants.Where( r => r.Id == id).FirstOrDefault();
            return model;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return context.Restaurants.OrderBy(r => r.Name);
        }
    }
}
