using Flashcards.Domain.Models.Enums;

namespace Flashcards.Domain.Models.Entities
{
    public class FlashcardLevel
    {
        public Level Level { get; set; }

        public Guid FlashcardId { get; set; }
        public Flashcard Flashcard { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
