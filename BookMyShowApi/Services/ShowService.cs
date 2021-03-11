using AutoMapper;
using BookMyShowApi.Models.Core;
using DataModel = BookMyShowApi.Models.Data;
using System.Collections.Generic;

namespace BookMyShowApi.Services
{
    public class ShowService : IShowService
    {
        PetaPoco.Database DataBase;
        IMapper Mapper;

        public ShowService(PetaPoco.Database db, IMapper mapper)
        {
            this.DataBase = db;
            this.Mapper = mapper;
        }

        public IEnumerable<Show> GetAllShows()
        {

            var shows = this.DataBase.Query<DataModel.Show>("Select * from Show");
            return this.Mapper.Map<List<Show>>(shows);
        }

        public Show GetShowById(int id)
        {
            var show = this.DataBase.SingleOrDefault<DataModel.Show>("Select * from Show where Id=@0", id);
            return this.Mapper.Map<Show>(show);
        }

        public void AddShow(Show newShow)
        {
            DataModel.Show show = this.Mapper.Map<DataModel.Show>(newShow);
            this.DataBase.Insert(show);
        }
    }
}
