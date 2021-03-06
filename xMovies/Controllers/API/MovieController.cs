﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using xMovies.Dto;
using xMovies.Models;
using AutoMapper;
using System.Data.Entity;

namespace xMovies.Controllers.API
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        //get: api/movie
        public IHttpActionResult GetMovies()
        {
            var movieDtos = _context.Movies
                .Include(m=>m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDtos);
        }

        //get: api/movie/:Id
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m=>m.Id==Id);
            if (movie == null) return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //post: api/movie
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult AddMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri+"/"+ movie.Id), movie);
        }

        //put: api/movie/:Id
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = _context.Movies.Single(m => m.Id == Id);
            if (movie == null) return NotFound();

            Mapper.Map(movieDto, movie);
            _context.SaveChanges();

            return Ok(movieDto);
        }

        //delete: api/movie/:Id
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m=>m.Id==Id);
            if (movie == null) return NotFound();

            return Ok();
        }

    }
}
