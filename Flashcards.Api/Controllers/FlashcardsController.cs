using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/flashcards")]
    [ApiController]
    public class FlashcardsController : ControllerBase
    {
        private readonly IFlashcardService<Flashcard> _flashcardService;

        public FlashcardsController(IFlashcardService<Flashcard> flashcardService)
        {
            _flashcardService = flashcardService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Flashcard>>> GetAll()
        {
            var task = await _flashcardService.GetAllAsync();
            return Ok(task);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<Flashcard>> Get([FromRoute] Guid guid)
        {
            var task = await _flashcardService.GetAsync(guid);
            if (task == null)
            {
                return NotFound("Flashcard not found");
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Flashcard>> Add([FromBody] Flashcard flashcard)
        {
            Flashcard task;
            try
            {
                task = await _flashcardService.AddAsync(flashcard);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] Flashcard flashcard)
        {
            var task = await _flashcardService.UpdateAsync(flashcard);
            return Ok(task.FlashcardId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var task = await _flashcardService.DeleteAsync(id);

            return Ok(id);
        }
    }
}
