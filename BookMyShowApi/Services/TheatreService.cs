using AutoMapper;
using BookMyShowApi.Models.Core;
using DataModel = BookMyShowApi.Models.Data;
using System.Collections.Generic;

namespace BookMyShowApi.Services
{
    public class TheatreService :ITheatreService
    {
        PetaPoco.Database DataBase;
        IMapper Mapper;

        public TheatreService(PetaPoco.Database db, IMapper mapper)
        {
            this.DataBase = db;
            this.Mapper = mapper;
        }

        public IEnumerable<Theatre> GetAllTheatres()
        {
            var theatres = this.DataBase.Query<DataModel.Theatre>("Select * from Theater");
            return this.Mapper.Map<List<Theatre>>(theatres);
        }

        public Theatre GetTheatreById(int id)
        {
            var theatre = this.DataBase.SingleOrDefault<DataModel.Theatre>("Select * from Theater where Id=@0", id);
            return this.Mapper.Map<Theatre>(theatre);
        }

        public void AddTheatre(Theatre newTheatre)
        {
            DataModel.Theatre theatre = this.Mapper.Map<DataModel.Theatre>(newTheatre);
            this.DataBase.Insert(theatre);
        }
    }
}
