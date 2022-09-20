using Flashcards.Domain.Models.Entities;

namespace Flashcards.Service.Dtos
{
    public class DeckDto
    {
        public Guid DeckId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? FlashcardAmount => Flashcards != null ? Flashcards!.Count : 0;
        public ICollection<FlashcardDto>? Flashcards { get; set; }

        public List<DeckFolderDto>? DeckFolders { get; set; }
        public List<DeckUserDto> DeckUsers { get; set; }
    }
}
