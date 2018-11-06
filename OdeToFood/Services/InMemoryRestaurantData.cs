using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using OdeToFood.Models;


namespace OdeToFood.Services
{
  public class InMemoryRestaurantData : IRestaurantData
  {
    public InMemoryRestaurantData()
    {
      _restaurants = new List<Restaurant>
                       {
                         new Restaurant
                         {
                           Id = 1,
                           Name = "Pizza"
                         },
                         new Restaurant
                         {
                           Id = 2,
                           Name = "Chang"
                         },
                         new Restaurant
                         {
                           Id = 3,
                           Name = "New Resty"
                         }
                       };
    }

    public IEnumerable<Restaurant> GetAll()
    {
      return _restaurants.OrderBy(r => r.Name);
    }

    public Restaurant Get(int id)
    {
      return _restaurants.FirstOrDefault(r => r.Id == id);
    }

    public Restaurant Add(Restaurant restaurant)
    {
      restaurant.Id = _restaurants.Max(r => r.Id) + 1;
      _restaurants.Add(restaurant);
      return restaurant;
    }

    private List<Restaurant> _restaurants;

  }
}
