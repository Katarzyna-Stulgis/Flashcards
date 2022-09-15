namespace Flashcards.Service.Dtos
{
    public class FlashcardDto
    {
        public Guid FlashcardId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
