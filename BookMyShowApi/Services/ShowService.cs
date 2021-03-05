using AutoMapper;
using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShowApi.Services
{
    public class ShowService : IShowService
    {
        PetaPoco.Database _dataContext;
        IMapper _mapper;

        public ShowService(IDataBaseContext dbcontext, IMapper mapper)
        {
            this._dataContext = dbcontext.getDataBase();
            this._mapper = mapper;
        }

        public IEnumerable<ShowCore> GetAllShows()
        {

            var shows = _dataContext.Query<Show>("Select * from Show");
            return _mapper.Map<List<ShowCore>>(shows);
        }

        public ShowCore GetShow(int id)
        {
            var show = _dataContext.Single<Show>("Select * from Show where ShowId=@0", id);
            return _mapper.Map<ShowCore>(show);
        }

        public void AddNewShow(ShowCore show)
        {
            Show _show = _mapper.Map<Show>(show);
            _dataContext.Insert("Show", "ShowId", _show);
        }

        public void Delete(int id)
        {
            _dataContext.Delete<Show>(id);
        }
    }
}
