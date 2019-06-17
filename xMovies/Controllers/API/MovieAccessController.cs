using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using xMovies.Dto;
using xMovies.Models;

namespace xMovies.Controllers.API
{
    public class MovieAccessController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieAccessController()
        {
            _context = new ApplicationDbContext();
        }

        //post: api/movieAccessRecord/
        [HttpPost]
        public IHttpActionResult CreateMovieAccessRecord(MovieAccessRecordDto movieAccessRecord)
        {            
            //get customer first
            var customer = _context.Customers.Single(c => c.Id == movieAccessRecord.CustomerId);
            //get movie to see if there is movie with such id
            var movie = _context.Movies.SingleOrDefault(m => m.Id == movieAccessRecord.MovieId);

            //check if customer has permission to access the movie
            if(movie.Limit && customer.MembershipTypeId < MembershipType.ShortTermVip)
            {
                return BadRequest("User is restricted from accessing this movie.");
            }

            //add movie id to the customer's movie list
            customer.MovieList.Add(movieAccessRecord.MovieId);

            var record = new MovieAccessRecord
            {
                CustomerId = customer.Id,
                MovieId = movie.Id,
                DateHappened = DateTime.Now
            };

            _context.MovieAccessRecords.Add(record);

            //after modify user and record data save change
            _context.SaveChanges();
            return Ok();
        }
    }
}
