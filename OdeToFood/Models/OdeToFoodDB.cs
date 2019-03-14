using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OdeToFood;

namespace OdeToFood.Models
{
    public class OdeToFoodDB
    {
        public List<RestaurantReview> GetRestaurants()
        {
            using (LINQ_to_SQL_CaspersDatabaseDataContext ctx = new LINQ_to_SQL_CaspersDatabaseDataContext())
            {
                    
                List<RestaurantReview> restaurantReviews = new List<RestaurantReview>();
                var RestaurantReviewsInfo = ctx.RestaurantReviews;
                foreach (var restaurantReview in RestaurantReviewsInfo)
                {
                    restaurantReviews.Add(new RestaurantReview()
                    {
                        Id= restaurantReview.Id,
                        Body = restaurantReview.Body,
                        Rating = restaurantReview.Rating,
                        RestaurantId = restaurantReview.RestaurantId
                        });
                }
                return restaurantReviews;
            }
        }
        public void SetRestaurants(RestaurantReview restaurantReview)
        {
            using (LINQ_to_SQL_CaspersDatabaseDataContext ctx = new LINQ_to_SQL_CaspersDatabaseDataContext()
            {
              ctx.RestaurantReviews.InsertOnSubmit(new OdeToFood.RestaurantReview
              {
                  Body = restaurantReview.Body,
                  Id = restaurantReview.Id,
                  Rating = restaurantReview.Rating,
                  RestaurantId = restaurantReview.RestaurantId,
              })
            }) ;
        }        
    }
}