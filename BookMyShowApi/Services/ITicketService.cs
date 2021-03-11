using BookMyShowApi.Models.Core;
using System.Collections.Generic;
using BookMyShowApi.Models.Core.View;

namespace BookMyShowApi.Services
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAllTickets();

        Ticket GetTicketById(int id);

        object AddTicket(Ticket Ticket);

        IEnumerable<Ticket> GetTicketsByShowId(int showId);

        IEnumerable<TicketView> GetTicketsByUserId(string userId);

        TicketView GetTicketsByTicketId(int ticketId);
    }
}
