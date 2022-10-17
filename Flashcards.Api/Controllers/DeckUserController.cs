using AutoMapper;
using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/deck-users")]
    [ApiController]
    public class DeckUserController : ControllerBase
    {
        private readonly IShareDeckService _deckUserService;
        private readonly IMapper _mapper;

        public DeckUserController(IShareDeckService deckUserService, IMapper mapper)
        {
            _deckUserService = deckUserService;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<DeckUser>> Get(Guid userId, Guid deckId)
        {
            var task = await _deckUserService.Get(userId, deckId);
            //  var dto = _mapper.Map<List<DeckDto>>(task);
            return Ok(task);
        }

        [HttpGet]
        public async Task<ActionResult<List<DeckUser>>> GetAll(Guid userId, bool isEditable)
        {
            var task = await _deckUserService.GetAllList(userId, isEditable);
            //  var dto = _mapper.Map<List<DeckDto>>(task);
            return Ok(task);
        }


        [HttpPost]
        public async Task<ActionResult<Flashcard>> Add([FromBody] DeckUser deck)
        {
            //   var deck = _mapper.Map<Deck>(dto);
            var task = await _deckUserService.AddAsync(deck);

            return Ok(task.DeckId);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeckUser deck)
        {
            var task = await _deckUserService.DeleteAsync(deck);
            return Ok(deck.DeckId);

        }
    }
}
