﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFoodMVC5.Models;
using System.Collections.Generic;

namespace OdeToFoodMVC5.Tests.Features
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var data = new Restaurant();
            data.Reviews = new List<RestaurantReview>();
            data.Reviews.Add(new RestaurantReview() { Rating = 4 });

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(4, result.Rating);
        }
    }
}
