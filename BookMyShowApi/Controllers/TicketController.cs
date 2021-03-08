using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Models.ViewModels;
using BookMyShowApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookMyShowApi.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        ITicketService TicketService;
        public TicketController(ITicketService ticketService)
        {
            this.TicketService = ticketService;
        }

        // GET: api/ticket
        [Route("all")]
        public IEnumerable<TicketCore> GetAllTickets()
        {
            return TicketService.GetAllTickets();
        }

        // GET api/ticket/id
        [Route("{id}")]
        public TicketCore GetTicketById(int id)
        {
            return TicketService.GetTicketById(id);
        }

        // Post api/ticket/add
        [Route("add")]
        public void AddTicket(TicketCore Ticket)
        {
            TicketService.AddTicket(Ticket);
        }

        // DELETE api/ticket/delete/id
        [Route("delete/{id}")]
        public void DeleteTicket(int id)
        {
            TicketService.DeleteTicket(id);
        }

        //GET api/ticket/getTicketsByShowId
        [Route("getTicketsByShowId/{showId}")]
        public IEnumerable<TicketCore> GetTicketsByShowId(int showId)
        {
            return TicketService.GetTicketsByShowId(showId);
        }

        //GET api/ticket/getTicketsByUserId
        [Route("getTicketsByUserId/{userId}")]
        public IEnumerable<TicketView> GetTicketsByShowId(string userId)
        {
            return TicketService.GetTicketsByUserId(userId);
        }
    }
}
