using AutoMapper;
using BookMyShowApi.Models.Core;
using BookMyShowApi.Models.Core.View;
using System.Collections.Generic;
using DataModel = BookMyShowApi.Models.Data;

namespace BookMyShowApi.Services
{
    public class MovieService : IMovieService
    { 
        PetaPoco.Database DataBase;
        IMapper Mapper;

        public MovieService(PetaPoco.Database db, IMapper mapper)
        {
            this.DataBase = db;
            this.Mapper = mapper;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            var movies = this.DataBase.Query<DataModel.Movie>("Select * from Movie");
            return this.Mapper.Map<List<Movie>>(movies);
        }

        public Movie GetMovieById(int id)
        {
            var movie = this.DataBase.SingleOrDefault<DataModel.Movie>("Select * from Movie where Id=@0", id);
            return this.Mapper.Map<Movie>(movie);
        }

        public void AddMovie(Movie newMovie)
        {
            DataModel.Movie movie = this.Mapper.Map<DataModel.Movie>(newMovie);
            this.DataBase.Insert(movie);
        }

        public IEnumerable<MoviesTheatreView> MoviesInCity(string city)
        {
            var movies = this.DataBase.Query<DataModel.View.MoviesTheatreView>("select * from MovieTheatreView where City=@0", city);
            return this.Mapper.Map<List<MoviesTheatreView>>(movies);
        }

        public MoviesTheatreView GetMovieByShowId(int id)
        {
            return this.DataBase.SingleOrDefault<MoviesTheatreView>("select * from MovieTheatreView where ShowId=@0", id);
        }
    }
}