using AutoMapper;
using BookMyShowApi.Models.Core;
using BookMyShowApi.Models.Core.View;
using DataModel = BookMyShowApi.Models.Data;

namespace BookMyShow.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataModel.Movie, Movie>().ReverseMap();
            CreateMap<DataModel.Theatre, Theatre>().ReverseMap();
            CreateMap<DataModel.Show, Show>().ReverseMap();
            CreateMap<DataModel.Ticket, Ticket>().ReverseMap();
            CreateMap<DataModel.View.MoviesTheatreView, MoviesTheatreView>().ReverseMap();
            CreateMap<DataModel.View.TicketView, TicketView>().ReverseMap();
        }
    }
}