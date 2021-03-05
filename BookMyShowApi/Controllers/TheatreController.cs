using BookMyShowApi.Models.CoreModels;
using BookMyShowApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace BookMyShowApi.Controllers
{
    [Route("api/Theatre")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private ITheatreService _theatre;
        public TheatreController(ITheatreService theatre)
        {
            this._theatre = theatre;
        }

        // GET: api/Theatre
        [Route("")]
        public IEnumerable<TheatreCore> GetAllTheatres()
        {
            return _theatre.GetAllTheatres();
        }

        // GET api/Theatre/id
        [Route("{id}")]
        [ResponseType(typeof(TheatreCore))]
        public TheatreCore GetTheatre(int id)
        {
            return _theatre.GetTheatre(id);
        }

        // Post api/Theatre/Add
        [Route("Add")]
        public void AddNewTheatre(TheatreCore theatre)
        {
            _theatre.AddNewTheatre(theatre);
        }

        // DELETE api/Theatre/Delete/id
        [Route("Delete/{id}")]
        public void Delete(int id)
        {
            _theatre.Delete(id);
        }
    }
}
