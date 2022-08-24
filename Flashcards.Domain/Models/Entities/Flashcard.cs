namespace Flashcards.Domain.Models.Entities
{
    public class Flashcard
    {
        public Guid FlashcardId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public Guid DeckId { get; set; }
        public Deck? Deck { get; set; }
        public ICollection<User>? Users { get; set; }
        public List<FlashcardLevel>? FlashcardLevels { get; set; }
    }
}
