using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Models.ViewModels;
using BookMyShowApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookMyShowApi.Controllers
{
    [Route("api/Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movie;

        public MovieController(IMovieService movie)
        {
            this._movie = movie;
        }
        
        // GET: api/Movie
        [Route("")]
        public IEnumerable<MovieCore> GetAllMovies()
        {
            return _movie.GetAllMovies();
        }

        // GET api/Movie/id
        [Route("{id}")]
        public MovieCore GetMovie(int id)
        {
            return _movie.GetMovie(id);
        }

        // Post api/Movie/Add
        [Route("Add")]
        public void AddNewMovie(MovieCore movie)
        {
            _movie.AddNewMovie(movie);
        }

        // DELETE api/Movie/Delete/id
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _movie.Delete(id);
        }

        //api/Movie/getMovies
        [Route("getMovies/{city}")]
        public IEnumerable<MoviesTheatre> MoviesInCity(string city)
        {
            return _movie.MoviesInCity(city);
        }

        [Route("getMovie/{id}")]
        public MoviesTheatre getMovie(int id)
        {
            return _movie.getMovieByShowId(id);
        }
    }
}
