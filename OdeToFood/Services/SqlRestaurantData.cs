﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;
using Microsoft.EntityFrameworkCore;

using OdeToFood.Data;
using OdeToFood.Models;


namespace OdeToFood.Services
{
  public class SqlRestaurantData : IRestaurantData
  {
    private OdeToFoodDbContext _context;

    public SqlRestaurantData(OdeToFoodDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Restaurant> GetAll()
    {
      return _context.Restaurants.OrderBy(r => r.Name);
    }

    public Restaurant Get(int id)
    {

      return _context.Restaurants.FirstOrDefault(r => r.Id == id);
    }

    public Restaurant Add(Restaurant restaurant)
    {
      _context.Restaurants.Add(restaurant);
      _context.SaveChanges();
      return restaurant;
    }

    public Restaurant Update(Restaurant restaurant)
    {
      _context.Attach(restaurant).State = EntityState.Modified;
      _context.SaveChanges();
      return restaurant;
    }
  }
}
