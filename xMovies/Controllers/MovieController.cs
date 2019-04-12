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
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),
            };
            return View("MovieForm", viewModel);
        }

        //Get: movie/new
        //apply change of the movie from edit page or create page to database
        public ActionResult Save(Movie movie)
        {
            //create new movie
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            //edit movie
            else
            {
                var movieInDb = _context.Movies.First(m=>m.Id==movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movie");
        }

        //Get: movie/edit/:id
        //take id and direct to movie edit page
        public ActionResult Edit(int Id)
        {
            var movie = GetMoviesById(Id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
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