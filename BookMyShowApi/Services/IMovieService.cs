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

        MovieCore GetMovie(int id);
        
        void AddNewMovie(MovieCore movie);
        
        void Delete(int id);
        IEnumerable<MoviesTheatre> MoviesInCity(string city);
        MoviesTheatre getMovieByShowId(int id);
    }
}
