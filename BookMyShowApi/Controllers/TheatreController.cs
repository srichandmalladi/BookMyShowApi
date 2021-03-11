using BookMyShowApi.Models.Core;
using BookMyShowApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookMyShowApi.Controllers
{
    [Route("api/theatre")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private ITheatreService TheatreService;
        public TheatreController(ITheatreService theatreService)
        {
            this.TheatreService = theatreService;
        }

        // GET: api/theatre/all
        [Route("all")]
        public IEnumerable<Theatre> GetAllTheatres()
        {
            return this.TheatreService.GetAllTheatres();
        }

        // GET api/theatre/id
        [Route("{id}")]
        public Theatre GetTheatreById(int id)
        {
            return this.TheatreService.GetTheatreById(id);
        }

        // Post api/theatre/add
        [Route("add")]
        public void AddTheatre(Theatre theatre)
        {
            this.TheatreService.AddTheatre(theatre);
        }
    }
}
