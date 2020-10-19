using AutoMapper;
using MVC_Vidily.Data;
using MVC_Vidily.DTO;
using MVC_Vidily.Migrations;
using MVC_Vidily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataContext = MVC_Vidily.Data.DataContext;

namespace MVC_Vidily.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private DataContext _context;
        public MoviesController()
        {
            _context = new DataContext();
        }

        //GET/api/movies
        public IEnumerable<MovieDTO> GetMovies()
        {
            return _context.movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
        }

        //GET/api/movie/1
        public  IHttpActionResult GetMovie(int id)
        {
            var movie = _context.movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));

        }
        //POST/api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id.ToString()), movieDTO);

        }
        //PUT/api/movie/1

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDTO, movieInDb);

            _context.SaveChanges();
            return Ok();
        }
        //DELETE/api/movie/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var moviesInDb = _context.movies.SingleOrDefault(m => m.Id == id);
            if (moviesInDb == null)
                return NotFound();

            _context.movies.Remove(moviesInDb);
            _context.SaveChanges();
            return Ok();

        }
    }
}
