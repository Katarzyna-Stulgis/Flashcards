using Flashcards.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flashcards.Domain.Models.Entities
{
    public class FlashcardLevel
    {
        public Level level { get; set; }
        public int FlashcardId { get; set; }
        public Flashcard Flashcard { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
