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
    [Migration("20220824094059_InitialCreate")]
    partial class InitialCreate
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
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.FlashcardLevel", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FlashcardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("level")
                        .HasColumnType("int");

                    b.HasKey("UserId", "FlashcardId");

                    b.HasIndex("FlashcardId");

                    b.ToTable("FlashcardLevel");
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.Folder", b =>
                {
                    b.Property<Guid>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FolderId");

                    b.HasIndex("UserId");

                    b.ToTable("Folders");
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
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.RoleUser", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUser");
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

                    b.HasKey("UserId");

                    b.ToTable("Users");
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

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.RoleUser", b =>
                {
                    b.HasOne("Flashcards.Domain.Models.Entities.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Flashcards.Domain.Models.Entities.User", "User")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
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
                    b.Navigation("RoleUsers");
                });

            modelBuilder.Entity("Flashcards.Domain.Models.Entities.User", b =>
                {
                    b.Navigation("DeckUsers");

                    b.Navigation("FlashcardLevels");

                    b.Navigation("Folders");

                    b.Navigation("RoleUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
