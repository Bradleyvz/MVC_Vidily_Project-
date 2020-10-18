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
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Ajax.Utilities;

namespace MVC_Vidily.Controllers
{
    public class MoviesController : Controller
    {
        private DataContext _context;
        public MoviesController()
        {
            _context = new DataContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(c => c.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)

                return HttpNotFound();

            return View(movie);
        }
        public ActionResult Random()
        {

            return View();
        }
    }
}

