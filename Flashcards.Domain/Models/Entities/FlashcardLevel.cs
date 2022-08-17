using Flashcards.Domain.Models.Enums;

namespace Flashcards.Domain.Models.Entities
{
    public class FlashcardLevel
    {
        public Level level { get; set; }

        public Flashcard Flashcard { get; set; }
        public User User { get; set; }
        public ICollection<RoleUser> RoleUsers { get; set; }
    }
}
