namespace Flashcards.Domain.Models.Entities
{
    public class Folder
    {
        public Guid FolderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Deck>? Decks { get; set; }
        public List<DeckFolder>? DeckFolders { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
