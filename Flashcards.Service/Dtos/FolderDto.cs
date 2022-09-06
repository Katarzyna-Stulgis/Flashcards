namespace Flashcards.Service.Dtos
{
    public class FolderDto
    {
        public Guid FolderId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public Guid UserId { get; set; }
        public ICollection<DeckDto>? Decks { get; set; }
    }
}
