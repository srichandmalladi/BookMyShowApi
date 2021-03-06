using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShowApi.Models.ViewModels
{
    public class TicketView
    {
        public string UserId { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int NoOfTicketsBooked { get; set; }

        public int Slot { get; set; }
    }
}
