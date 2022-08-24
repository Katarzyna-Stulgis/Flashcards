using System.ComponentModel.DataAnnotations.Schema;

namespace Flashcards.Domain.Models.Entities
{
    public class RoleUser
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
