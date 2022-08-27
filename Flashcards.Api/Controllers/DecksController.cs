using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/decks")]
    [ApiController]
    public class DecksController : ControllerBase
    {
        private readonly IFlashcardService<Deck> _deckService;

        public DecksController(IFlashcardService<Deck> deckService)
        {
            _deckService = deckService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Deck>>> GetAll()
        {
            var task = await _deckService.GetAllAsync();
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Deck>> Get([FromRoute] Guid id)
        {
            var task = await _deckService.GetAsync(id);
            if (task == null)
            {
                return NotFound("Deck not found");
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Flashcard>> Add([FromBody] Deck deck)
        {
            Deck task;
            try
            {
                task = await _deckService.AddAsync(deck);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] Deck deck)
        {
            if (id != deck.DeckId)
            {
                return BadRequest();
            }

            var task = await _deckService.UpdateAsync(deck);
            if (task != null)
            {
                return Ok("Deck edited id: " + deck.DeckId);
            }

            return NotFound("Deck not found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var task = await _deckService.DeleteAsync(id);

            if (task != null)
            {
                return Ok($"Deck deleted (id: {id})");
            }

            return NotFound("Deck not found");
        }

    }
}
