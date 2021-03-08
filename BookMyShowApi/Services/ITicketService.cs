using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShowApi.Services
{
    public interface ITicketService
    {
        IEnumerable<TicketCore> GetAllTickets();

        TicketCore GetTicketById(int id);

        void AddTicket(TicketCore Ticket);

        void DeleteTicket(int id);

        IEnumerable<TicketCore> GetTicketsByShowId(int showId);

        IEnumerable<TicketView> GetTicketsByUserId(string userId);
    }
}
