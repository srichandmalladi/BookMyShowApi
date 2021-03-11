using System;

namespace BookMyShowApi.Models.Data.View
{
    public class TicketView
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int NoOfTicketsBooked { get; set; }

        public int Slot { get; set; }
    }
}
