﻿using OdeToFood.Filters;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}