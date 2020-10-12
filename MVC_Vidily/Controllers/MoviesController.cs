using MVC_Vidily.Models;
//Added in the using models using statement.
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC_Vidily.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sherk" };
            return View(movie);
        }
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            
                pageIndex = 1;
                if (string.IsNullOrWhiteSpace(sortBy))
                
                    sortBy = "Name";


                    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        }
        //Controller Action for the Custom Route in Route.Config File 
        //Adding the Atrribute Routing in the Controller.
        [Route("movies.released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month )
        {

            return Content(year +"/"+month);
        }

    }
}
    


