﻿using BookMyShowApi.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShowApi.Services
{
    public interface ITheatreService
    {
        IEnumerable<TheatreCore> GetAllTheatres();

        TheatreCore GetTheatreById(int id);

        void AddNewTheatre(TheatreCore theatre);

        void Delete(int id);
    }
}
