namespace Flashcards.Domain.Models.Entities
{
    public class DeckUser
    {
        public bool IsEditable { get; set; }

        public Guid DeckId { get; set; }
        public Deck? Deck { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
