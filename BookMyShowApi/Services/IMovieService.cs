using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShowApi.Services
{
    public interface IMovieService
    {
        IEnumerable<MovieCore> GetAllMovies();

        MovieCore GetMovieById(int id);
        
        void AddMovie(MovieCore movie);
        
        void DeleteMovie(int id);

        IEnumerable<MoviesTheatre> MoviesInCity(string city);

        MoviesTheatre GetMovieByShowId(int id);
    }
}
