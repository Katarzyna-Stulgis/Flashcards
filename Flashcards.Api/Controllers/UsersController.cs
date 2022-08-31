using AutoMapper;
using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Flashcards.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public UsersController(IAccountService userService, IMapper mapper)
        {
            _accountService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] RegisterUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _accountService.Register(user);

            return Ok("User register");
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var user = _mapper.Map<User>(dto);
            string token = _accountService.GenerateJwt(user);

            return Ok(token);
        }
    }
}
