namespace OdeToFoodMVC5.Migrations
{
    using OdeToFoodMVC5.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFoodMVC5.Models.OdeToFoodMVC5Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OdeToFoodMVC5.Models.OdeToFoodMVC5Db";
        }

        protected override void Seed(OdeToFoodMVC5.Models.OdeToFoodMVC5Db context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Sabatino's", City = "Baltimore", Country = "USA" },
                new Restaurant { Name = "Great Lake", City = "Chicago", Country = "USA" },
                new Restaurant
                {
                    Name = "Smaka",
                    City = "Gothenburg",
                    Country = "Sweden",
                    Reviews =
                        new List<RestaurantReview>{
                        new RestaurantReview {Rating = 9, Body ="Great food!",ReviewerName = "Scott"}
                    }
                });
            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                    new Restaurant { Name = i.ToString(), City = "NoWhere", Country = "USA" });
            }
        }
    }
}
