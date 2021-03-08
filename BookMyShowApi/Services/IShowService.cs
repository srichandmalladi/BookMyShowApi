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

        ShowCore GetShowById(int id);

        void AddShow(ShowCore show);

        void DeleteShow(int id);
    }
}
