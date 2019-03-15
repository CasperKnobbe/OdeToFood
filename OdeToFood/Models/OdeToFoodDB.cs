using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OdeToFood;

namespace OdeToFood.Models
{
    public class OdeToFoodDB
    {
        public List<RestaurantReview> GetRestaurantReviews()
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

        public void SetRestaurantReview(RestaurantReview restaurantReview)
        {
            using (LINQ_to_SQL_CaspersDatabaseDataContext ctx = new LINQ_to_SQL_CaspersDatabaseDataContext())
            {
                ctx.RestaurantReviews.InsertOnSubmit(new OdeToFood.RestaurantReview
                {
                    Body = restaurantReview.Body,
                    Id = restaurantReview.Id,
                    Rating = restaurantReview.Rating,
                    RestaurantId = restaurantReview.RestaurantId,
                });
                ctx.SubmitChanges();
            };
        }


        public List<Restaurant> GetRestaurants()
        {
            using (LINQ_to_SQL_CaspersDatabaseDataContext ctx = new LINQ_to_SQL_CaspersDatabaseDataContext())
            {
                List<Restaurant> restaurants = new List<Restaurant>();
                var restaurantInfo = ctx.Restaurants;
                foreach (var restaurant in restaurantInfo)
                {
                    restaurants.Add(new Restaurant()
                    {
                        Id = restaurant.Id,
                        Name = restaurant.Name,
                        City = restaurant.City,
                        Country = restaurant.Country,
                        Reviews = new List<RestaurantReview>()
                    });
                    foreach (var review in restaurant.RestaurantReviews)
                    {
                        restaurants.Last().Reviews.Add(new RestaurantReview
                        {
                            Id = review.Id,
                            Body = review.Body,
                            Rating = review.Rating,
                            RestaurantId = review.RestaurantId
                        });                    
                    }                    
                }
                return restaurants;
            }
        }

        public void SetRestaurant(Restaurant restaurant)
        {
            using (LINQ_to_SQL_CaspersDatabaseDataContext ctx = new LINQ_to_SQL_CaspersDatabaseDataContext())
            {
                ctx.Restaurants.InsertOnSubmit(new OdeToFood.Restaurant
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    City = restaurant.City,
                    Country = restaurant.Country
                });
                ctx.SubmitChanges();
            }
        }
    }
}