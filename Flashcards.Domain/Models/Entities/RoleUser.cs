namespace Flashcards.Domain.Models.Entities
{
    public class RoleUser
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
