using ApplicationService.DTOs;
using ApplicationService.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginManagementService _service = null;
       public LoginController()
        {
            _service = new LoginManagementService();
        }
        
        
        // POST: Login/Create
        [HttpPost]
        public bool Authentication(LoginDTO loggedUser)
        {
           return _service.Validate(loggedUser);           
        }
    }
}
