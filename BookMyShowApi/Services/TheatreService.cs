﻿using AutoMapper;
using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Models.DataModels;
using System.Collections.Generic;

namespace BookMyShowApi.Services
{
    public class TheatreService :ITheatreService
    {
        PetaPoco.Database _dataContext;
        IMapper _mapper;

        public TheatreService(IDataBaseContext dbcontext, IMapper mapper)
        {
            this._dataContext = dbcontext.getDataBase();
            this._mapper = mapper;
        }

        public IEnumerable<TheatreCore> GetAllTheatres()
        {
            var theatres = _dataContext.Query<Theatre>("Select * from Theater");
            return _mapper.Map<List<TheatreCore>>(theatres);
        }

        public TheatreCore GetTheatreById(int id)
        {
            var theatre = _dataContext.Single<Theatre>("Select * from Theater where Id=@0", id);
            return _mapper.Map<TheatreCore>(theatre);
        }

        public void AddTheatre(TheatreCore theatre)
        {
            Theatre _theatre = _mapper.Map<Theatre>(theatre);
            _dataContext.Insert(_theatre);
        }

        public void DeleteTheatre(int id)
        {
            _dataContext.Delete<Theatre>(id);
        }
    }
}
