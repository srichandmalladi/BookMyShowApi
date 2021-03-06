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
        [Route("addTicket")]
        public void AddNewTicket(TicketCore Ticket)
        {
            TicketService.AddNewTicket(Ticket);
        }

        // DELETE api/ticket/delete/id
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            TicketService.Delete(id);
        }

        //GET api/ticket/getTicketsByShowId
        [Route("getTicketsByShowId/{showId}")]
        public IEnumerable<TicketCore> getTicketsByShowId(int showId)
        {
            return TicketService.getTicketsByShowId(showId);
        }

        //GET api/ticket/getTicketsByUserId
        [Route("getTicketsByUserId/{userId}")]
        public IEnumerable<TicketView> getTicketsByShowId(string userId)
        {
            return TicketService.getTicketsByUserId(userId);
        }
    }
}
