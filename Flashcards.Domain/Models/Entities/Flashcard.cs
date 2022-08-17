namespace Flashcards.Domain.Models.Entities
{
    public class Flashcard
    {
        public int FlashcardId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int DeckId { get; set; }
        public Deck Deck { get; set; }

        public ICollection<FlashcardLevel> FlashcardLevels { get; set; }
    }
}
