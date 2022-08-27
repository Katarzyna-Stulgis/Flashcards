using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IFlashcardService<User> _userService;

        public UsersController(IFlashcardService<User> userService)
        {
            _userService = userService;
        }
    }
}
