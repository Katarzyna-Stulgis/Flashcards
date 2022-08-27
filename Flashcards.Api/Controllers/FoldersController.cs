using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/folders")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        private readonly IFlashcardService<Folder> _folderService;

        public FoldersController(IFlashcardService<Folder> folderService)
        {
            _folderService = folderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Folder>>> GetAll()
        {
            var task = await _folderService.GetAllAsync();
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Folder>> Get([FromRoute] Guid id)
        {
            var task = await _folderService.GetAsync(id);
            if (task == null)
            {
                return NotFound("Folder not found");
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Folder>> Add([FromBody] Folder folder)
        {
            Folder task;
            try
            {
                task = await _folderService.AddAsync(folder);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] Folder folder)
        {
            if (id != folder.FolderId)
            {
                return BadRequest();
            }

            var task = await _folderService.UpdateAsync(folder);
            if (task != null)
            {
                return Ok("Folder edited id: " + task.FolderId);
            }

            return NotFound("Folder not found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var task = await _folderService.DeleteAsync(id);

            if (task != null)
            {
                return Ok($"Folder deleted (id: {id})");
            }

            return NotFound("Folder not found");
        }
    }
}
