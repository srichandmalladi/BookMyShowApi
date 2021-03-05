using BookMyShowApi.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShowApi.Services
{
    public interface ITicketService
    {
        IEnumerable<TicketCore> GetAllTickets();

        TicketCore GetTicket(int id);

        void AddNewTicket(TicketCore Ticket);

        void Delete(int id);
    }
}
