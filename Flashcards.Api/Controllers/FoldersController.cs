using AutoMapper;
using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Flashcards.Service.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/folders")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        private readonly IFlashcardService<Folder> _folderService;
        private readonly IMapper _mapper;

        public FoldersController(IFlashcardService<Folder> folderService, IMapper mapper)
        {
            _folderService = folderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Folder>>> GetAll(Guid userId)
        {
            var task = await _folderService.GetAllAsync(userId);
            var dto = _mapper.Map<List<FolderDto>>(task);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Folder>> Get([FromRoute] Guid id)
        {
            var task = await _folderService.GetAsync(id);
            var dto = _mapper.Map<FolderDto>(task);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<Folder>> Add([FromBody] FolderDto dto)
        {
            var folder = _mapper.Map<Folder>(dto);
            var task = await _folderService.AddAsync(folder);

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] FolderDto dto)
        {
            var folder = _mapper.Map<Folder>(dto);
            var task = await _folderService.UpdateAsync(folder);
           return Ok(task.FolderId);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var task = await _folderService.DeleteAsync(id);
            return Ok(id);
        }
    }
}
