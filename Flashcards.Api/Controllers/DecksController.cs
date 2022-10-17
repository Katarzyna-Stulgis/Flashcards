using AutoMapper;
using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Flashcards.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/decks")]
    [ApiController]
    public class DecksController : ControllerBase
    {
        private readonly IFlashcardService<Deck> _deckService;
        private readonly IMapper _mapper;

        public DecksController(IFlashcardService<Deck> deckService, IMapper mapper)
        {
            _deckService = deckService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Deck>>> GetAll(Guid userId)
        {
            var task = await _deckService.GetAllAsync(userId);
            var dto = _mapper.Map<List<DeckDto>>(task);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Deck>> Get([FromRoute] Guid id)
        {
            var task = await _deckService.GetAsync(id);
            var dto = _mapper.Map<DeckDto>(task);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<Flashcard>> Add([FromBody] DeckDto dto)
        {
            var deck = _mapper.Map<Deck>(dto);
            var task = await _deckService.AddAsync(deck);

            return Ok(task.DeckId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] DeckDto dto)
        {
            var deck = _mapper.Map<Deck>(dto);
            var task = await _deckService.UpdateAsync(deck);
            return Ok(task.DeckId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var task = await _deckService.DeleteAsync(id);
            return Ok(id);

        }

    }
}
