using MVC_Vidily.Models;
//Added in the using models using statement.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Vidily.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie=new Movie() { }
            return View();
        }
    }
}