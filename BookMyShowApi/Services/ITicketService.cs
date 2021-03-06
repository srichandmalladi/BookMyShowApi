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

        void AddNewTicket(TicketCore Ticket);

        void Delete(int id);

        IEnumerable<TicketCore> getTicketsByShowId(int showId);

        IEnumerable<TicketView> getTicketsByUserId(string userId);
    }
}
