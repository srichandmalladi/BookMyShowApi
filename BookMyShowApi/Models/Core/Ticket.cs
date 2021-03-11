using System;

namespace BookMyShowApi.Models.Core
{
    public class Ticket
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ShowId { get; set; }

        public DateTime Date { get; set; }

        public int NoOfTicketsBooked { get; set; }

        public int Slot { get; set; }
    }
}
