using BookMyShowApi.Models.Core;
using BookMyShowApi.Models.Core.View;
using BookMyShowApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public IEnumerable<Movie> GetAllMovies()
        {
            return this.MovieService.GetAllMovies();
        }

        // GET api/movie/id
        [Route("{id}")]
        public Movie GetMovieById(int id)
        {
            return this.MovieService.GetMovieById(id);
        }

        // Post api/movie/add
        [Route("add")]
        public void AddMovie(Movie movie)
        {
            this.MovieService.AddMovie(movie);
        }

        //GET api/movie/getMovies
        [Route("getMoviesByCity/{city}")]
        public IEnumerable<MoviesTheatreView> MoviesInCity(string city)
        {
            return this.MovieService.MoviesInCity(city);
        }

        //GET api/movie/getMovieByShowId/id
        [Route("getMovieByShowId/{id}")]
        public MoviesTheatreView GetMovieByShowId(int id)
        {
            return this.MovieService.GetMovieByShowId(id);
        }
    }
}
