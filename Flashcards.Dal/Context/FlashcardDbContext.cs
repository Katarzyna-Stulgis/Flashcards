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

            // data
            var roleUser = new Role
            {
                RoleId = Guid.NewGuid(),
                Name = "User"
            };
            var roleAdmin = new Role
            {
                RoleId = Guid.NewGuid(),
                Name = "Admin"
            };

            var user1 = new User
            {
                UserId = Guid.NewGuid(),
                Name = "User1",
                Email = "User1@flashcards.com",
                Password = "User1"
            };

            var user2 = new User
            {
                UserId = Guid.NewGuid(),
                Name = "User2",
                Email = "User2@flashcards.com",
                Password = "User2"
            };

            var folder1 = new Folder
            {
                FolderId = Guid.NewGuid(),
                UserId = user1.UserId,
                Name = "Folder1",
            };

            var folder2 = new Folder
            {
                FolderId = Guid.NewGuid(),
                UserId = user1.UserId,
                Name = "Folder2",
            };

            var deck1 = new Deck
            {
                DeckId = Guid.NewGuid(),
                Title = "Deck1",
                VisibilityType = Domain.Models.Enums.VisibilityType.Public
            };

            var deck2 = new Deck
            {
                DeckId = Guid.NewGuid(),
                Title = "Deck2",
                VisibilityType = Domain.Models.Enums.VisibilityType.Public
            };

            var flashcard1 = new Flashcard
            {
                FlashcardId = Guid.NewGuid(),
                Question = "KOT",
                Answer = "CAT",
                DeckId = deck1.DeckId
            };

            var flashcard2 = new Flashcard
            {
                FlashcardId = Guid.NewGuid(),
                Question = "PIES",
                Answer = "DOG",
                DeckId = deck1.DeckId
            };

            // Add data to Db
            modelBuilder.Entity<Role>().HasData(roleUser, roleAdmin);

            modelBuilder.Entity<User>().HasData(user1, user2);

            modelBuilder.Entity<RoleUser>().HasData(
                new RoleUser { RoleId = roleUser.RoleId, UserId = user1.UserId },
                new RoleUser { RoleId = roleUser.RoleId, UserId = user2.UserId });

            modelBuilder.Entity<Folder>().HasData(folder1, folder2);

            modelBuilder.Entity<Deck>().HasData(deck1, deck2);

            modelBuilder.Entity<DeckFolder>().HasData(
                new DeckFolder { DeckId = deck1.DeckId, FolderId = folder1.FolderId, },
                new DeckFolder { DeckId = deck2.DeckId, FolderId = folder1.FolderId, });

            modelBuilder.Entity<DeckUser>().HasData(
                new DeckUser { DeckId = deck1.DeckId, UserId = user1.UserId, IsEditable = true },
                new DeckUser { DeckId = deck2.DeckId, UserId = user1.UserId, IsEditable = true });

            modelBuilder.Entity<Flashcard>().HasData(flashcard1, flashcard2);

            modelBuilder.Entity<FlashcardLevel>().HasData(
                new FlashcardLevel { FlashcardId = flashcard1.FlashcardId, UserId = user1.UserId, Level = Domain.Models.Enums.Level.learning },
                new FlashcardLevel { FlashcardId = flashcard2.FlashcardId, UserId = user1.UserId, Level = Domain.Models.Enums.Level.learning });
        }
    }
}
