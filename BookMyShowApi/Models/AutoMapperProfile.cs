using AutoMapper;
using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Models.DataModels;
using System;

namespace BookMyShow.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, MovieCore>().ReverseMap();
            CreateMap<Theatre, TheatreCore>().ReverseMap();
            CreateMap<Show, ShowCore>().ReverseMap();
            CreateMap<Ticket, TicketCore>().ReverseMap();
        }
    }
}