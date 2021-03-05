using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetaPoco;

namespace BookMyShowApi.Models.DataModels
{
    [TableName("Ticket")]
    public class Ticket
    {
        public int TicketId { get; set; }

        public string UserId { get; set; }

        public string ShowId { get; set; }

        public int NoOfTicketsBooked { get; set; }

        public int Slot { get; set; }
    }
}
