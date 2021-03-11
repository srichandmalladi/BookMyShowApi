using BookMyShowApi.Models.Core;
using System.Collections.Generic;

namespace BookMyShowApi.Services
{
    public interface ITheatreService
    {
        IEnumerable<Theatre> GetAllTheatres();

        Theatre GetTheatreById(int id);

        void AddTheatre(Theatre theatre);
    }
}
