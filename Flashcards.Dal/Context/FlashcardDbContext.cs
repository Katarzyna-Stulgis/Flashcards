using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Dal.Context
{
    public class FlashcardDbContext : DbContext
    {
        public FlashcardDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Deck> Decks { get; set; }
        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<Role>()
            .HasMany(p => p.Users)
            .WithMany(p => p.Roles)
            .UsingEntity<RoleUser>(
                j => j
                    .HasOne(pt => pt.User)
                    .WithMany(t => t.RoleUsers)
                    .HasForeignKey(pt => pt.UserId),
                j => j
                    .HasOne(pt => pt.Role)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(pt => pt.RoleId),
                j =>
                {
                    j.HasKey(t => new { t.RoleId, t.UserId });
                });

            modelBuilder.Entity<Deck>()
            .HasMany(p => p.Users)
            .WithMany(p => p.Decks)
            .UsingEntity<DeckUser>(
                j => j
                    .HasOne(pt => pt.User)
                    .WithMany(t => t.DeckUsers)
                    .HasForeignKey(pt => pt.UserId),
                j => j
                    .HasOne(pt => pt.Deck)
                    .WithMany(p => p.DeckUsers)
                    .HasForeignKey(pt => pt.DeckId),
                j =>
                {
                    j.HasKey(t => new { t.UserId, t.DeckId });
                });

            modelBuilder.Entity<Deck>()
            .HasMany(p => p.Folders)
            .WithMany(p => p.Decks)
            .UsingEntity<DeckFolder>(
                j => j
                    .HasOne(pt => pt.Folder)
                    .WithMany(t => t.DeckFolders)
                    .HasForeignKey(pt => pt.FolderId),
                j => j
                    .HasOne(pt => pt.Deck)
                    .WithMany(p => p.DeckFolders)
                    .HasForeignKey(pt => pt.DeckId),
                j =>
                {
                    j.HasKey(t => new { t.FolderId, t.DeckId });
                });
        }
    }
}
