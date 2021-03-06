using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetaPoco;

namespace BookMyShowApi.Models.CoreModels
{
    public class TheatreCore
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int NoOfSlots { get; set; }

        public int NoOfSeats { get; set; }

        public int TicketCost { get; set; }
    }
}
