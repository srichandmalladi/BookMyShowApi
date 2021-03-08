using BookMyShowApi.Models.CoreModels;
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
        public IEnumerable<TheatreCore> GetAllTheatres()
        {
            return TheatreService.GetAllTheatres();
        }

        // GET api/theatre/id
        [Route("{id}")]
        public TheatreCore GetTheatreById(int id)
        {
            return TheatreService.GetTheatreById(id);
        }

        // Post api/theatre/add
        [Route("add")]
        public void AddTheatre(TheatreCore theatre)
        {
            TheatreService.AddTheatre(theatre);
        }

        // DELETE api/theatre/delete/id
        [Route("delete/{id}")]
        public void DeleteTheatre(int id)
        {
            TheatreService.DeleteTheatre(id);
        }
    }
}
