using ApplicationService.DTOs;
using ApplicationService.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private readonly OrganisationManagementService _service = null;
        public OrganisationController()
        {
            _service = new OrganisationManagementService();
        }


        // GET: api/<OrganisationController>
        [HttpGet]
        public IEnumerable<object> Get(string? searchByName, int? page)
        {
            return _service.Get(searchByName, page);
        }

        // GET api/<OrganisationController>/5
        [HttpGet("{id}")]
        public OrganisationDTO Get(int id)
        {
            return _service.GetById(id);
        }

        // POST api/<OrganisationController>
        [HttpPost]
        public void Post([FromBody] OrganisationDTO organisationDTO)
        {
            _service.Save(organisationDTO);
        }

        // PUT api/<OrganisationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrganisationDTO organisationDTO)
        {
            _service.Update(organisationDTO);
        }

        // DELETE api/<OrganisationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
