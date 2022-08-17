using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Dal.Context
{
    public class FlashcardDbContext : DbContext
    {
        public FlashcardDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flashcard>()
            .HasMany(p => p.Users)
            .WithMany(p => p.Flashcards)
            .UsingEntity<FlashcardLevel>(
                j => j
                    .HasOne(pt => pt.User)
                    .WithMany(t => t.FlashcardLevels)
                    .HasForeignKey(pt => pt.UserId),
                j => j
                    .HasOne(pt => pt.Flashcard)
                    .WithMany(p => p.FlashcardLevels)
                    .HasForeignKey(pt => pt.FlashcardId),
                j =>
                {
                    j.HasKey(t => new { t.UserId, t.FlashcardId });
                });

            modelBuilder.Entity<Flashcard>()
                .HasOne(e => e.Deck)
                .WithMany(e => e.Flashcards).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
