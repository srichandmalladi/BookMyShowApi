using BookMyShowApi.Models.CoreModels;
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
        public IEnumerable<ShowCore> GetAllShows()
        {
            return ShowService.GetAllShows();
        }

        // GET api/show/id
        [Route("{id}")]
        public ShowCore GetShowById(int id)
        {
            return ShowService.GetShowById(id);
        }

        // Post api/show/add
        [Route("add")]
        public void AddShow(ShowCore show)
        {
            ShowService.AddShow(show);
        }

        // DELETE api/show/delete/id
        [Route("delete/{id}")]
        public void DeleteShow(int id)
        {
            ShowService.DeleteShow(id);
        }
    }
}
