using BookMyShowApi.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShowApi.Services
{
    public interface IShowService
    {
        IEnumerable<ShowCore> GetAllShows();

        ShowCore GetShow(int id);

        void AddNewShow(ShowCore show);

        void Delete(int id);
    }
}
