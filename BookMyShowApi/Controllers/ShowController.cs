using BookMyShowApi.Models.Core;
using BookMyShowApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookMyShowApi.Controllers
{
    [Route("api/show")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        IShowService ShowService;
        public ShowController(IShowService showService)
        {
            this.ShowService = showService;
        }

        // GET: api/show/all
        [Route("all")]
        public IEnumerable<Show> GetAllShows()
        {
            return this.ShowService.GetAllShows();
        }

        // GET api/show/id
        [Route("{id}")]
        public Show GetShowById(int id)
        {
            return this.ShowService.GetShowById(id);
        }

        // Post api/show/add
        [Route("add")]
        public void AddShow(Show show)
        {
            this.ShowService.AddShow(show);
        }
    }
}
