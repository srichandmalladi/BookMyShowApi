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

        // Post api/Show/Add
        [Route("addShow")]
        public void AddNewShow(ShowCore show)
        {
            ShowService.AddNewShow(show);
        }

        // DELETE api/show/delete/id
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            ShowService.Delete(id);
        }
    }
}
