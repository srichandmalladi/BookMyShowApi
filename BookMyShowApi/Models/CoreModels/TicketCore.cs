using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetaPoco;

namespace BookMyShowApi.Models.CoreModels
{
    public class TicketCore
    {
        public int TicketId { get; set; }

        public string UserId { get; set; }

        public int ShowId { get; set; }

        public int NoOfTicketsBooked { get; set; }

        public int Slot { get; set; }
    }
}
