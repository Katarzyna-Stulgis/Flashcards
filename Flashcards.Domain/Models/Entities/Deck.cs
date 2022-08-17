using Flashcards.Domain.Models.Enums;

namespace Flashcards.Domain.Models.Entities
{
    public class Deck
    {
        public int DeckId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public VisibilityType VisibilityType { get; set; } = VisibilityType.Public;

        public int FolderId { get; set; }
        public Folder Folder { get; set; }
        public ICollection<Flashcard> Flashcards { get; set; }
    }
}
