﻿using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        // POST: SpecificReviews
        public ActionResult RestaurantReviews(int id)
        {
            var model =
                from r in _reviews
                where r.RestaurantId == id
                orderby r.Rating
                select r;

            return View(model);
        }

        // GET: Reviews
        public ActionResult Index()
        {
            var model =
                from r in _reviews
                orderby r.Rating
                select r;

            return View(model);
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        public ActionResult Create(Models.RestaurantReview collection)
        {
            try
            {
                dB.SetRestaurantReview(collection);
                _reviews.Add(collection);
                UpdateModel(_reviews);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {
            var review = _reviews.Single(r => r.Id == id);
            
            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var review = _reviews.Single(r => r.Id == id);

                UpdateModel(review);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        static OdeToFoodDB dB = new OdeToFoodDB();
        static List<Models.RestaurantReview> _reviews = dB.GetRestaurantReviews();
    }
}
