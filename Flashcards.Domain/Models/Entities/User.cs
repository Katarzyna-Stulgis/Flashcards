﻿namespace Flashcards.Domain.Models.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
        public ICollection<Folder>? Folders { get; set; }
        public ICollection<Flashcard>? Flashcards { get; set; }
        public List<FlashcardLevel>? FlashcardLevels { get; set; }
        public ICollection<Deck>? Decks { get; set; }
        public List<DeckUser>? DeckUsers { get; set; }
    }
}
