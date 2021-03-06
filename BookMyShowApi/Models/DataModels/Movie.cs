﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetaPoco;

namespace BookMyShowApi.Models.DataModels
{
    [PetaPoco.TableName("Movie")]
    public class Movie
    {
        public int Id {get; set;}

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }
    }
}
