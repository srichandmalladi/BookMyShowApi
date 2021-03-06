using AutoMapper;
using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Models.DataModels;
using BookMyShowApi.Models.ViewModels;
using System.Collections.Generic;

namespace BookMyShowApi.Services
{
    public class TicketService : ITicketService
    {
        PetaPoco.Database _dataContext;
        IMapper _mapper;

        public TicketService(IDataBaseContext dbcontext, IMapper mapper)
        {
            this._dataContext = dbcontext.getDataBase();
            this._mapper = mapper;
        }

        public IEnumerable<TicketCore> GetAllTickets()
        {

            var tickets = _dataContext.Query<Ticket>("Select * from Ticket");
            return _mapper.Map<List<TicketCore>>(tickets);
        }

        public TicketCore GetTicketById(int id)
        {
            var ticket = _dataContext.Single<Ticket>("Select * from Ticket where Id=@0", id);
            return _mapper.Map<TicketCore>(ticket);
        }

        public void AddNewTicket(TicketCore ticket)
        {
            Ticket _ticket = _mapper.Map<Ticket>(ticket);
            _dataContext.Insert(_ticket);
        }

        public void Delete(int id)
        {
            _dataContext.Delete<Ticket>(id);
        }
        public IEnumerable<TicketCore> getTicketsByShowId(int showId)
        {
            var tickets = _dataContext.Query<Ticket>("Select * from Ticket where showId=@0",showId);
            return _mapper.Map<List<TicketCore>>(tickets);
        }

        public IEnumerable<TicketView> getTicketsByUserId(string userId)
        {
            var tickets= _dataContext.Query<TicketView>("Select * from TicketView where userId=@0", userId);
            return tickets;
        }
    }
}
