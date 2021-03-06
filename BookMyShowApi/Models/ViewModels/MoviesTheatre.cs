using System;
using System.Collections.Generic;
using System.Linq;
namespace BookMyShowApi.Models.ViewModels
{
    public class MoviesTheatre
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public int ShowId { get; set; }

        public int TheatreId { get; set; }

        public string Name { get; set; }

        public int Slot { get; set; }

        public string City { get; set; }

        public int NoOfSlots { get; set; }

        public int NoOfSeats { get; set; }

        public int TicketCost { get; set; }

    }
}
