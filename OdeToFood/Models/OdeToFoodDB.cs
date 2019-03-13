using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OdeToFood;

namespace OdeToFood.Models
{
    public class OdeToFoodDB
    {
        public IEnumerable<Restaurant> Restaurants {
            get
            {
                using (LINQ_to_SQL_CaspersDatabaseDataContext ctx = new LINQ_to_SQL_CaspersDatabaseDataContext())
                {
                    List<Restaurant> restaurants = new List<Restaurant>();
                    var RestaurantsInfo = ctx.Restaurants;
                    foreach (var restaurant in RestaurantsInfo)
                    {
                        restaurants.Add(new Restaurant()
                        {
                            Name = restaurant.Name,
                            City = restaurant.City,
                            Country = restaurant.Country,
                            Id = restaurant.Id
                            });
                    }
                    return restaurants;
                }
            }
        }        
    }
}