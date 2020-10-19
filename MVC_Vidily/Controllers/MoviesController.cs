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
using System.Web.Razor;


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

        public ViewResult NewMovie()
        {
            
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
             Genres=genre
            };

            return View("MovieForm",viewModel);
        }
        //Edit Action Not Working 
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
            
             Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {

                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
          
            if (movie.Id==0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var MoviesInDb = _context.Movies.Single(m => m.Id == movie.Id);
                MoviesInDb.Name = movie.Name;
                MoviesInDb.ReleaseDate = movie.ReleaseDate;
                MoviesInDb.GenreId = movie.GenreId;
                MoviesInDb.NumInStock = movie.NumInStock;
              
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
         

        }

    }
}

