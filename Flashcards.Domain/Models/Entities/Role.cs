namespace Flashcards.Domain.Models.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public ICollection<RoleUser> RoleUsers { get; set; }
    }
}
