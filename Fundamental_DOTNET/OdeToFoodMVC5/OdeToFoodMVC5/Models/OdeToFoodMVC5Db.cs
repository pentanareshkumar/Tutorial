using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFoodMVC5.Models
{
    public class OdeToFoodMVC5Db : DbContext
    {
        public OdeToFoodMVC5Db()
            : base("name=DefaultConnection")
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> RestaurantReviews { get; set; }
    }
}