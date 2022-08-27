using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Flashcards.Service.DataServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAccountService _userService;

        public UsersController(IAccountService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
        {
            User task;
            try
            {
                task = await _userService.Register(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(task);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] User user)
        {
            string token =  _userService.GenerateJwt(user);

            return Ok(token);
        }


    }
}
