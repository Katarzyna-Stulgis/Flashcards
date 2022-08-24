namespace Flashcards.Domain.Models.Entities
{
    public class DeckFolder
    {
        public Guid DeckId { get; set; }
        public Deck Deck { get; set; }

        public Guid FolderId { get; set; }
        public Folder Folder { get; set; }
    }
}
