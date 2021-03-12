using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkiAPI.Models;
using ParkiAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkiAPI.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/users")]
    //[Route("api/[controller]")] //changeable ~Burak
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User model)
        {
            var user = this.userRepository.Authenticate(model.UserName, model.Password);
            if (user==null)
            {
                return BadRequest(new { message = "Username or password is incorrect!" });
            }
            return Ok(user);
        }
    }
}
