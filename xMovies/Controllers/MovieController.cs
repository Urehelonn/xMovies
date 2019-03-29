using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xMovies.Models;
using xMovies.ViewModels;

namespace xMovies.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie{ Id = 1, Name = "Deadpool" },
                new Movie{ Id = 2, Name = "Spiderman - Home Comming" },
                new Movie{ Id = 3, Name = "Detective Pikachu" },
                new Movie{ Id = 4, Name = "One Punch Man" },
            };

            var movieV = new MovieIndexViewModel {
                Movies = movies
            };

            return View(movieV);
        }

        [Route("movie/detail/{Id}")]
        public ActionResult Show(int Id)
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie{ Id = 1, Name = "Deadpool" },
                new Movie{ Id = 2, Name = "Spiderman - Home Comming" },
                new Movie{ Id = 3, Name = "Detective Pikachu" },
                new Movie{ Id = 4, Name = "One Punch Man" },
            };

            var movie = movies[Id - 1];

            return View(movie);
        }
    }
}