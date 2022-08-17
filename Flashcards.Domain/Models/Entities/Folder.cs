namespace Flashcards.Domain.Models.Entities
{
    public class Folder
    {
        public int FolderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Deck> Decks { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
