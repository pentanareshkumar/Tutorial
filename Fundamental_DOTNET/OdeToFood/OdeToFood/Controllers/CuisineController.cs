﻿using OdeToFood.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    //[Authorize]
    //[Log]
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/
        public ActionResult Search(string name)
        {
            //throw new Exception("Something Terrible Happened !");

            var message = Server.HtmlEncode(name);

            return Content(message);
        }
    }
}
