namespace Flashcards.Service.Dtos
{
    public class DeckUserDto
    {
        public bool IsEditable { get; set; }
        public Guid DeckId { get; set; }
        public Guid UserId { get; set; }
    }
}
