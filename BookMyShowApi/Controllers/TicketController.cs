using BookMyShowApi.Models.Core;
using BookMyShowApi.Models.Core.View;
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
        public IEnumerable<Ticket> GetAllTickets()
        {
            return this.TicketService.GetAllTickets();
        }

        // GET api/ticket/id
        [Route("{id}")]
        public Ticket GetTicketById(int id)
        {
            return this.TicketService.GetTicketById(id);
        }

        // Post api/ticket/add
        [Route("add")]
        public object AddTicket(Ticket Ticket)
        {
            return this.TicketService.AddTicket(Ticket);
        }

        //GET api/ticket/getTicketsByShowId
        [Route("getTicketsByShowId/{showId}")]
        public IEnumerable<Ticket> GetTicketsByShowId(int showId)
        {
            return this.TicketService.GetTicketsByShowId(showId);
        }

        //GET api/ticket/getTicketsByUserId
        [Route("getTicketsByUserId/{userId}")]
        public IEnumerable<TicketView> GetTicketsByUserId(string userId)
        {
            return this.TicketService.GetTicketsByUserId(userId);
        }

        //GET api/ticket/getTicketsByTicketId
        [Route("getTicketsByTicketId/{ticketId}")]
        public TicketView GetTicketsByTicketId(int ticketId)
        {
            return this.TicketService.GetTicketsByTicketId(ticketId);
        }
    }
}
