using AutoMapper;
using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Models.DataModels;
using BookMyShowApi.Models.ViewModels;
using System.Collections.Generic;

namespace BookMyShowApi.Services
{
    public class MovieService : IMovieService
    { 
        PetaPoco.Database _dataContext;
        IMapper _mapper;

        public MovieService(IDataBaseContext dbcontext, IMapper mapper)
        {
            this._dataContext = dbcontext.getDataBase();
            this._mapper = mapper;
        }

        public IEnumerable<MovieCore> GetAllMovies()
        {

            var movies = _dataContext.Query<Movie>("Select * from Movie");
            return _mapper.Map<List<MovieCore>>(movies);
        }

        public MovieCore GetMovie(int id)
        {
            var movie = _dataContext.Single<Movie>("Select * from Movie where MovieId=@0", id);
            return _mapper.Map<MovieCore>(movie);
        }

        public void AddNewMovie(MovieCore movie)
        {
            Movie _movie = _mapper.Map<Movie>(movie);
            _dataContext.Insert(_movie);
        }

        public void Delete(int id)
        {
            _dataContext.Delete<Movie>(id);
        }

        public IEnumerable<MoviesTheatre> MoviesInCity(string city)
        {
            return _dataContext.Query<MoviesTheatre>("select * from Movie_Theatre where City=@0", city);
        }

        public MoviesTheatre getMovieByShowId(int id)
        {
            return _dataContext.Single<MoviesTheatre>("select * from Movie_Theatre where ShowId=@0", id);
        }
    }
}