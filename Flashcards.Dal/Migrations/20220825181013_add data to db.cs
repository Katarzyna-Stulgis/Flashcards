using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flashcards.Dal.Migrations
{
    public partial class adddatatodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "level",
                table: "FlashcardLevel",
                newName: "Level");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Folders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "DeckId", "Description", "Title", "VisibilityType" },
                values: new object[,]
                {
                    { new Guid("19d22b9b-8764-4474-bcc8-46098343c5f1"), null, "Deck2", 0 },
                    { new Guid("2d3aa240-0469-4703-a79c-b587f1665151"), null, "Deck1", 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { new Guid("39b7e6b7-8ff9-4159-a0b9-128bc228941a"), "Admin" },
                    { new Guid("f74afa8b-ae7b-4886-92db-1be0e2495fff"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("212c6278-2116-488b-84fe-3353b3d18447"), "User1@flashcards.com", "User1", "User1" },
                    { new Guid("961cd73b-a462-49d6-a8d9-fb9730654942"), "User2@flashcards.com", "User2", "User2" }
                });

            migrationBuilder.InsertData(
                table: "DeckUser",
                columns: new[] { "DeckId", "UserId", "IsEditable" },
                values: new object[,]
                {
                    { new Guid("19d22b9b-8764-4474-bcc8-46098343c5f1"), new Guid("212c6278-2116-488b-84fe-3353b3d18447"), true },
                    { new Guid("2d3aa240-0469-4703-a79c-b587f1665151"), new Guid("212c6278-2116-488b-84fe-3353b3d18447"), true }
                });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "FlashcardId", "Answer", "DeckId", "Question" },
                values: new object[,]
                {
                    { new Guid("82f6eb02-fbd3-4224-819e-e41b4327a7e8"), "DOG", new Guid("2d3aa240-0469-4703-a79c-b587f1665151"), "PIES" },
                    { new Guid("843e2257-0f9e-4172-80c7-dcab58115097"), "CAT", new Guid("2d3aa240-0469-4703-a79c-b587f1665151"), "KOT" }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "FolderId", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("56582a77-fbb8-426c-84dd-4175db3d752c"), null, "Folder1", new Guid("212c6278-2116-488b-84fe-3353b3d18447") },
                    { new Guid("f227ba3a-9e2a-4135-9f0e-b57de88084a7"), null, "Folder2", new Guid("212c6278-2116-488b-84fe-3353b3d18447") }
                });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f74afa8b-ae7b-4886-92db-1be0e2495fff"), new Guid("212c6278-2116-488b-84fe-3353b3d18447") },
                    { new Guid("f74afa8b-ae7b-4886-92db-1be0e2495fff"), new Guid("961cd73b-a462-49d6-a8d9-fb9730654942") }
                });

            migrationBuilder.InsertData(
                table: "DeckFolder",
                columns: new[] { "DeckId", "FolderId" },
                values: new object[,]
                {
                    { new Guid("19d22b9b-8764-4474-bcc8-46098343c5f1"), new Guid("56582a77-fbb8-426c-84dd-4175db3d752c") },
                    { new Guid("2d3aa240-0469-4703-a79c-b587f1665151"), new Guid("56582a77-fbb8-426c-84dd-4175db3d752c") }
                });

            migrationBuilder.InsertData(
                table: "FlashcardLevel",
                columns: new[] { "FlashcardId", "UserId", "Level" },
                values: new object[,]
                {
                    { new Guid("82f6eb02-fbd3-4224-819e-e41b4327a7e8"), new Guid("212c6278-2116-488b-84fe-3353b3d18447"), 0 },
                    { new Guid("843e2257-0f9e-4172-80c7-dcab58115097"), new Guid("212c6278-2116-488b-84fe-3353b3d18447"), 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeckFolder",
                keyColumns: new[] { "DeckId", "FolderId" },
                keyValues: new object[] { new Guid("19d22b9b-8764-4474-bcc8-46098343c5f1"), new Guid("56582a77-fbb8-426c-84dd-4175db3d752c") });

            migrationBuilder.DeleteData(
                table: "DeckFolder",
                keyColumns: new[] { "DeckId", "FolderId" },
                keyValues: new object[] { new Guid("2d3aa240-0469-4703-a79c-b587f1665151"), new Guid("56582a77-fbb8-426c-84dd-4175db3d752c") });

            migrationBuilder.DeleteData(
                table: "DeckUser",
                keyColumns: new[] { "DeckId", "UserId" },
                keyValues: new object[] { new Guid("19d22b9b-8764-4474-bcc8-46098343c5f1"), new Guid("212c6278-2116-488b-84fe-3353b3d18447") });

            migrationBuilder.DeleteData(
                table: "DeckUser",
                keyColumns: new[] { "DeckId", "UserId" },
                keyValues: new object[] { new Guid("2d3aa240-0469-4703-a79c-b587f1665151"), new Guid("212c6278-2116-488b-84fe-3353b3d18447") });

            migrationBuilder.DeleteData(
                table: "FlashcardLevel",
                keyColumns: new[] { "FlashcardId", "UserId" },
                keyValues: new object[] { new Guid("82f6eb02-fbd3-4224-819e-e41b4327a7e8"), new Guid("212c6278-2116-488b-84fe-3353b3d18447") });

            migrationBuilder.DeleteData(
                table: "FlashcardLevel",
                keyColumns: new[] { "FlashcardId", "UserId" },
                keyValues: new object[] { new Guid("843e2257-0f9e-4172-80c7-dcab58115097"), new Guid("212c6278-2116-488b-84fe-3353b3d18447") });

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: new Guid("f227ba3a-9e2a-4135-9f0e-b57de88084a7"));

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f74afa8b-ae7b-4886-92db-1be0e2495fff"), new Guid("212c6278-2116-488b-84fe-3353b3d18447") });

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f74afa8b-ae7b-4886-92db-1be0e2495fff"), new Guid("961cd73b-a462-49d6-a8d9-fb9730654942") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("39b7e6b7-8ff9-4159-a0b9-128bc228941a"));

            migrationBuilder.DeleteData(
                table: "Decks",
                keyColumn: "DeckId",
                keyValue: new Guid("19d22b9b-8764-4474-bcc8-46098343c5f1"));

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "FlashcardId",
                keyValue: new Guid("82f6eb02-fbd3-4224-819e-e41b4327a7e8"));

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "FlashcardId",
                keyValue: new Guid("843e2257-0f9e-4172-80c7-dcab58115097"));

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: new Guid("56582a77-fbb8-426c-84dd-4175db3d752c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("f74afa8b-ae7b-4886-92db-1be0e2495fff"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("961cd73b-a462-49d6-a8d9-fb9730654942"));

            migrationBuilder.DeleteData(
                table: "Decks",
                keyColumn: "DeckId",
                keyValue: new Guid("2d3aa240-0469-4703-a79c-b587f1665151"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("212c6278-2116-488b-84fe-3353b3d18447"));

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "FlashcardLevel",
                newName: "level");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Folders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
