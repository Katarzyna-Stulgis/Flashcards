﻿// <auto-generated />
using System;
using Flashcards.Dal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Flashcards.Dal.Migrations
{
    [DbContext(typeof(FlashcardDbContext))]
    [Migration("20220829111720_change role-user relation")]
    partial class changeroleuserrelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.Deck", b =>
                {
                    b.Property<Guid>("DeckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisibilityType")
                        .HasColumnType("int");

                    b.HasKey("DeckId");

                    b.ToTable("Decks");

                    b.HasData(
                        new
                        {
                            DeckId = new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40"),
                            Title = "Deck1",
                            VisibilityType = 0
                        },
                        new
                        {
                            DeckId = new Guid("a2936d2e-97fe-4892-8542-0cd78b5567eb"),
                            Title = "Deck2",
                            VisibilityType = 0
                        });
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.DeckFolder", b =>
                {
                    b.Property<Guid>("FolderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeckId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FolderId", "DeckId");

                    b.HasIndex("DeckId");

                    b.ToTable("DeckFolder");

                    b.HasData(
                        new
                        {
                            FolderId = new Guid("48965add-832e-49b5-ac6a-b89fb3aa5087"),
                            DeckId = new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40")
                        },
                        new
                        {
                            FolderId = new Guid("48965add-832e-49b5-ac6a-b89fb3aa5087"),
                            DeckId = new Guid("a2936d2e-97fe-4892-8542-0cd78b5567eb")
                        });
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.DeckUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeckId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsEditable")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "DeckId");

                    b.HasIndex("DeckId");

                    b.ToTable("DeckUser");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("6b81215f-4b26-4493-93b0-b508dc91921b"),
                            DeckId = new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40"),
                            IsEditable = true
                        },
                        new
                        {
                            UserId = new Guid("6b81215f-4b26-4493-93b0-b508dc91921b"),
                            DeckId = new Guid("a2936d2e-97fe-4892-8542-0cd78b5567eb"),
                            IsEditable = true
                        });
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.Flashcard", b =>
                {
                    b.Property<Guid>("FlashcardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DeckId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlashcardId");

                    b.HasIndex("DeckId");

                    b.ToTable("Flashcards");

                    b.HasData(
                        new
                        {
                            FlashcardId = new Guid("360b284f-421b-48fb-b7ab-dee2259d8116"),
                            Answer = "CAT",
                            DeckId = new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40"),
                            Question = "KOT"
                        },
                        new
                        {
                            FlashcardId = new Guid("20100ab0-436b-41e7-927b-f592e9b7b940"),
                            Answer = "DOG",
                            DeckId = new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40"),
                            Question = "PIES"
                        });
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.FlashcardLevel", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FlashcardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("UserId", "FlashcardId");

                    b.HasIndex("FlashcardId");

                    b.ToTable("FlashcardLevel");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("6b81215f-4b26-4493-93b0-b508dc91921b"),
                            FlashcardId = new Guid("360b284f-421b-48fb-b7ab-dee2259d8116"),
                            Level = 0
                        },
                        new
                        {
                            UserId = new Guid("6b81215f-4b26-4493-93b0-b508dc91921b"),
                            FlashcardId = new Guid("20100ab0-436b-41e7-927b-f592e9b7b940"),
                            Level = 0
                        });
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.Folder", b =>
                {
                    b.Property<Guid>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FolderId");

                    b.HasIndex("UserId");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            FolderId = new Guid("48965add-832e-49b5-ac6a-b89fb3aa5087"),
                            Name = "Folder1",
                            UserId = new Guid("6b81215f-4b26-4493-93b0-b508dc91921b")
                        },
                        new
                        {
                            FolderId = new Guid("91d86030-9a4c-40a7-8cb9-352dffe5f6e5"),
                            Name = "Folder2",
                            UserId = new Guid("6b81215f-4b26-4493-93b0-b508dc91921b")
                        });
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("98b0ebe0-13a5-4b79-8899-d4cdfecb09d9"),
                            Name = "User"
                        },
                        new
                        {
                            RoleId = new Guid("46f1bc82-bcaf-4c59-825b-979980813ca5"),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("6b81215f-4b26-4493-93b0-b508dc91921b"),
                            Email = "User1@flashcards.com",
                            Name = "User1",
                            Password = "User1",
                            RoleId = new Guid("98b0ebe0-13a5-4b79-8899-d4cdfecb09d9")
                        },
                        new
                        {
                            UserId = new Guid("8e006f03-2172-4879-88f3-8e18d69ac935"),
                            Email = "User2@flashcards.com",
                            Name = "User2",
                            Password = "User2",
                            RoleId = new Guid("98b0ebe0-13a5-4b79-8899-d4cdfecb09d9")
                        });
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.DeckFolder", b =>
                {
                    b.HasOne("Flashcards.Domain.Models.Entities.Deck", "Deck")
                        .WithMany("DeckFolders")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Flashcards.Domain.Models.Entities.Folder", "Folder")
                        .WithMany("DeckFolders")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deck");

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.DeckUser", b =>
                {
                    b.HasOne("Flashcards.Domain.Models.Entities.Deck", "Deck")
                        .WithMany("DeckUsers")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Flashcards.Domain.Models.Entities.User", "User")
                        .WithMany("DeckUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deck");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.Flashcard", b =>
                {
                    b.HasOne("Flashcards.Domain.Models.Entities.Deck", "Deck")
                        .WithMany("Flashcards")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deck");
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.FlashcardLevel", b =>
                {
                    b.HasOne("Flashcards.Domain.Models.Entities.Flashcard", "Flashcard")
                        .WithMany("FlashcardLevels")
                        .HasForeignKey("FlashcardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Flashcards.Domain.Models.Entities.User", "User")
                        .WithMany("FlashcardLevels")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flashcard");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.Folder", b =>
                {
                    b.HasOne("Flashcards.Domain.Models.Entities.User", "User")
                        .WithMany("Folders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.User", b =>
                {
                    b.HasOne("Flashcards.Domain.Models.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.Deck", b =>
                {
                    b.Navigation("DeckFolders");

                    b.Navigation("DeckUsers");

                    b.Navigation("Flashcards");
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.Flashcard", b =>
                {
                    b.Navigation("FlashcardLevels");
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.Folder", b =>
                {
                    b.Navigation("DeckFolders");
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.User", b =>
                {
                    b.Navigation("DeckUsers");

                    b.Navigation("FlashcardLevels");

                    b.Navigation("Folders");
                });
#pragma warning restore 612, 618
        }
    }
}
