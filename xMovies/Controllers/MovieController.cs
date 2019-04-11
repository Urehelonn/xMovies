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
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
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

        //Get: movie/detail/:id
        //take id and direct to movie detail page
        [Route("movie/detail/{Id}")]
        public ActionResult Show(int Id)
        {
            var movie = GetMoviesById(Id);
            Console.WriteLine(movie);
            return View(movie);
        }

        //Get: movie/new
        //direct to add new movie page
        public ActionResult New()
        {
            return View();
        }

        //Get: movie/edit/:id
        //take id and direct to movie edit page
        public ActionResult Edit(int Id)
        {
            return View();
        }

        //functions
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