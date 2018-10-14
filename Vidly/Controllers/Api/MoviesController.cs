using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using AutoMapper;
using Vidly.DTOs;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: api/Movies
        public IEnumerable<MovieDto> Get()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie,MovieDto>);
        }

        // GET: api/Movies/5
        public MovieDto Get(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movie==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Movie,MovieDto>(movie);
        }

        // POST: api/Movies
        public MovieDto Post([FromBody]MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Mapper.Map<Movie, MovieDto>(movie);

        }

        // PUT: api/Movies/5
        public void Put(int id, [FromBody]MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieinDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieinDb);

            _context.SaveChanges();
        }

        // DELETE: api/Movies/5
        public void Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movie);
            _context.SaveChanges();

        }
    }
}

