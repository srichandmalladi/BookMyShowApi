using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetaPoco;

namespace BookMyShowApi.Models.CoreModels
{
    public class ShowCore
    {
        public int ShowId { get; set; }

        public int TheatreId { get; set; }

        public int MovieId { get; set; }

        public int Slot { get; set; }

        public int NoOfTicketsBooked { get; set; }
    }
}
