using ApplicationService.DTOs;
using ApplicationService.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventManagementService _service;
        public EventController()
        {
            _service = new EventManagementService();
        }


        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<object> Get(string? searchByName, DateTime? searchByDate, int? page)
        {
            return _service.Get(searchByName, searchByDate, page);
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public EventDTO Get(int id)
        {
            return _service.GetById(id);
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] EventDTO eventDTO)
        {
            _service.Save(eventDTO);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EventDTO eventDTO)
        {
            _service.Update(eventDTO);
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
