using AutoMapper;
using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Models.DataModels;
using BookMyShowApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace BookMyShowApi.Controllers
{
    [Route("api/Show")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        IShowService _show;
        public ShowController(IShowService show)
        {
            this._show = show;
        }

        // GET: api/Show
        [Route("")]
        public IEnumerable<ShowCore> GetAllShows()
        {
            return _show.GetAllShows();
        }

        // GET api/Show/id
        [Route("{id}")]
        [ResponseType(typeof(ShowCore))]
        public ShowCore GetShowS(int id)
        {
            return _show.GetShow(id);
        }

        // Post api/Show/Add
        [Route("Add")]
        public void AddNewShow(ShowCore show)
        {
            _show.AddNewShow(show);
        }

        // DELETE api/Show/Delete/id
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _show.Delete(id);
        }
    }
}
