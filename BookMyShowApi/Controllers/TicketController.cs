using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace BookMyShowApi.Controllers
{
    [Route("api/Ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        ITicketService _ticket;
        public TicketController(ITicketService ticket)
        {
            this._ticket = ticket;
        }

        // GET: api/Ticket
        [Route("")]
        public IEnumerable<TicketCore> GetAllTickets()
        {
            return _ticket.GetAllTickets();
        }

        // GET api/Ticket/id
        [Route("{id}")]
        [ResponseType(typeof(TicketCore))]
        public TicketCore Get(int id)
        {
            return _ticket.GetTicket(id);
        }

        // Post api/Ticket/Add
        [Route("Add")]
        public void AddNewTicket(TicketCore Ticket)
        {
            _ticket.AddNewTicket(Ticket);
        }

        // DELETE api/Ticket/Delete/id
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _ticket.Delete(id);
        }
    }
}
