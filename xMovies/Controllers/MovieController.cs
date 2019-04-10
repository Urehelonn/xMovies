using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using xMovies.Models;
using xMovies.ViewModels;

namespace xMovies.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movie
        public ActionResult Index()
        {
            List<Movie> movies = GetMovies().ToList();
            var movieV = new MovieIndexViewModel {
                Movies = movies
            };

            return View(movieV);
        }

        [Route("movie/detail/{Id}")]
        public ActionResult Show(int Id)
        {
            var movie = GetMoviesById(Id);
            Console.WriteLine(movie);
            return View(movie);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.Genre);
        }
        public Movie GetMoviesById(int Id)
        {
            return GetMovies().SingleOrDefault(c=>c.Id==Id);
        }
    }
}