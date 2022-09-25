using AutoMapper;
using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckUserController : ControllerBase
    {
        private readonly IFlashcardService<DeckUser> _deckUserService;
        private readonly IMapper _mapper;

        public DeckUserController(IFlashcardService<DeckUser> deckUserService, IMapper mapper)
        {
            _deckUserService = deckUserService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeckUser>>> GetAll(Guid userId)
        {
            var task = await _deckUserService.GetAllAsync(userId);
          //  var dto = _mapper.Map<List<DeckDto>>(task);
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeckUser>> Get([FromRoute] Guid id)
        {
            var task = await _deckUserService.GetAsync(id);
        //    var dto = _mapper.Map<DeckDto>(task);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Flashcard>> Add([FromBody] DeckUser deck)
        {
         //   var deck = _mapper.Map<Deck>(dto);
            var task = await _deckUserService.AddAsync(deck);

            return Ok(task.DeckId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] DeckUser deck)
        {
           // var deck = _mapper.Map<Deck>(dto);
            var task = await _deckUserService.UpdateAsync(deck);
            return Ok(task.DeckId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var task = await _deckUserService.DeleteAsync(id);
            return Ok(id);

        }
    }
}
