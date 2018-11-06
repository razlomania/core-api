using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Cache;
using System.Threading.Tasks;

using OdeToFood.Models;


namespace OdeToFood.ViewModels
{
  public class RestaurantEditModel
  {
    [Required]
    public string Name { get; set; }
    public CuisineType Cuisine { get; set; }
  }
}
