using AutoMapper;
using BookMyShowApi.Models.Core;
using DataModel = BookMyShowApi.Models.Data;
using System.Collections.Generic;
using BookMyShowApi.Models.Core.View;

namespace BookMyShowApi.Services
{
    public class TicketService : ITicketService
    {
        PetaPoco.Database DataBase;
        IMapper Mapper;

        public TicketService(PetaPoco.Database db, IMapper mapper)
        {
            this.DataBase = db;
            this.Mapper = mapper;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {

            var tickets = this.DataBase.Query<DataModel.Ticket>("Select * from Ticket");
            return this.Mapper.Map<List<Ticket>>(tickets);
        }

        public Ticket GetTicketById(int id)
        {
            var ticket = this.DataBase.SingleOrDefault<DataModel.Ticket>("Select * from Ticket where Id=@0", id);
            return this.Mapper.Map<Ticket>(ticket);
        }

        public object AddTicket(Ticket newTicket)
        {
            DataModel.Ticket ticket = this.Mapper.Map<DataModel.Ticket>(newTicket);
            return this.DataBase.Insert(ticket);
        }
        public IEnumerable<Ticket> GetTicketsByShowId(int showId)
        {
            var tickets = this.DataBase.Query<DataModel.Ticket>("Select * from Ticket where showId=@0", showId);
            return this.Mapper.Map<List<Ticket>>(tickets);
        }

        public IEnumerable<TicketView> GetTicketsByUserId(string userId)
        {
            var tickets= this.DataBase.Query<DataModel.View.TicketView>("Select * from TicketView where userId=@0 order by Date desc", userId);
            return this.Mapper.Map<List<TicketView>>(tickets);
        }

        public TicketView GetTicketsByTicketId(int ticketId)
        {
            var tickets = this.DataBase.SingleOrDefault<DataModel.View.TicketView>("Select * from TicketView where Id=@0", ticketId);
            return this.Mapper.Map<TicketView>(tickets);
        }
    }
}
