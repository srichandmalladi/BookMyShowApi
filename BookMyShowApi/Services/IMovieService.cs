using BookMyShowApi.Models.Core;
using BookMyShowApi.Models.Core.View;
using System.Collections.Generic;


namespace BookMyShowApi.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();

        Movie GetMovieById(int id);
        
        void AddMovie(Movie movie);

        IEnumerable<MoviesTheatreView> MoviesInCity(string city);

        MoviesTheatreView GetMovieByShowId(int id);
    }
}
