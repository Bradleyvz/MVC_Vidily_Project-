using Microsoft.Owin.Security.Provider;
using MVC_Vidily.Models;
using MVC_Vidily.ViewModel;
//Added in the using models using statement.
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MVC_Vidily.ViewModel;

namespace MVC_Vidily.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie> 
            { 
            new Movie{Id=1,Name="Sherk"},
            new Movie{Id=2,Name="Wall-e"}
            };

        }
        //GET:Movies/Random
        public ActionResult Random()
        {
            var movies = new Movie() { Name = "Sherk" };
            var customers = new List<Customer>
            
            { 
            new Customer{Name="Customer1"},
            new Customer{Name="Customer2"}

            };
            var viewModel = new RandomViewModel
            {
                Movie = movies,
                Customers = customers

            };
            return View(viewModel);
       
        }

    }
}
    


