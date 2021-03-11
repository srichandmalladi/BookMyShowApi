using BookMyShowApi.Models.Core;
using System.Collections.Generic;

namespace BookMyShowApi.Services
{
    public interface IShowService
    {
        IEnumerable<Show> GetAllShows();

        Show GetShowById(int id);

        void AddShow(Show show);
    }
}
