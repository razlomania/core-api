﻿using System;
using System.Threading;

using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;


namespace OdeToFood.Controllers
{
  public class HomeController : Controller

  {
    private readonly IRestaurantData _restaurantData;
    private IGreeter _greeter;

    public HomeController(IRestaurantData restaurantData,
                          IGreeter greeter)
    {
      _restaurantData = restaurantData;
      _greeter = greeter;
    }
    public IActionResult Index()
    {
      var model = new HomeIndexViewModel
      {
        Restaurants = _restaurantData.GetAll(),
        CurrentMessage = _greeter.GetMessageOfTheDay()
      };

      return View(model);
    }

    public IActionResult Details(int id)
    {
      var model = _restaurantData.Get(id);
      if (model == null)
      {
        return RedirectToAction(nameof(Index));
      }
      return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(RestaurantEditModel model)
    {
      if (ModelState.IsValid)
      {
        var newRestaurant = new Restaurant();
        newRestaurant.Name = model.Name;
        newRestaurant.Cuisine = model.Cuisine;

        newRestaurant = _restaurantData.Add(newRestaurant);

        return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
      }
      else
      {
        return View();
      }
    }
  }
}