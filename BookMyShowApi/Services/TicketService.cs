using AutoMapper;
using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Models.DataModels;
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

        public TicketCore GetTicket(int id)
        {
            var ticket = _dataContext.Single<Ticket>("Select * from Ticket where TicketId=@0", id);
            return _mapper.Map<TicketCore>(ticket);
        }

        public void AddNewTicket(TicketCore ticket)
        {
            Ticket _ticket = _mapper.Map<Ticket>(ticket);
            _dataContext.Insert(_ticket);
            Show show = _dataContext.Single<Show>("Select * from Show where ShowId =@0", _ticket.ShowId);
            show.NoOfTicketsBooked = show.NoOfTicketsBooked + _ticket.NoOfTicketsBooked;
            _dataContext.Update("Show", "ShowId", show);

        }

        public void Delete(int id)
        {
            _dataContext.Delete<Ticket>(id);
        }
    }
}
