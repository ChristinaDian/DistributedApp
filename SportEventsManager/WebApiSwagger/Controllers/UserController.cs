using ApplicationService.DTOs;
using ApplicationService.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManagementService _service = null;
        public UserController()
        {
            _service = new UserManagementService(); 
        }


        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<object> Get(string? searchByName, string? searchByTown, int? page)
        {
            return _service.Get(searchByName, searchByTown, page);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserDTO Get(int id)
        {
            return _service.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UserDTO userDTO)
        {
            _service.Save(userDTO);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDTO userDTO)
        {
            _service.Update(userDTO);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
