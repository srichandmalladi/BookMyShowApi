using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Models.ViewModels;
using BookMyShowApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookMyShowApi.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService MovieService;

        public MovieController(IMovieService movieService)
        {
            this.MovieService = movieService;
        }
        
        // GET: api/movie/all
        [Route("all")]
        public IEnumerable<MovieCore> GetAllMovies()
        {
            return MovieService.GetAllMovies();
        }

        // GET api/movie/id
        [Route("{id}")]
        public MovieCore GetMovieById(int id)
        {
            return MovieService.GetMovieById(id);
        }

        // Post api/movie/add
        [Route("add")]
        public void AddMovie(MovieCore movie)
        {
            MovieService.AddMovie(movie);
        }

        // DELETE api/movie/delete/id
        [Route("delete/{id}")]
        public void DeleteMovie(int id)
        {
            MovieService.DeleteMovie(id);
        }

        //GET api/movie/getMovies
        [Route("getMoviesByCity/{city}")]
        public IEnumerable<MoviesTheatre> MoviesInCity(string city)
        {
            return MovieService.MoviesInCity(city);
        }

        //GET api/movie/getMovieByShowId/id
        [Route("getMovieByShowId/{id}")]
        public MoviesTheatre GetMovieByShowId(int id)
        {
            return MovieService.GetMovieByShowId(id);
        }
    }
}
