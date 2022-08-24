using Flashcards.Domain.Models.Enums;

namespace Flashcards.Domain.Models.Entities
{
    public class Deck
    {
        public Guid DeckId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public VisibilityType VisibilityType { get; set; } = VisibilityType.Public;

        public ICollection<Flashcard>? Flashcards { get; set; }
        public ICollection<Folder>? Folders { get; set; }
        public List<DeckFolder>? DeckFolders { get; set; }
        public ICollection<User> Users { get; set; }
        public List<DeckUser> DeckUsers { get; set; }
    }
}
