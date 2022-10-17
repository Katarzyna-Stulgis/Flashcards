using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flashcards.Dal.Migrations
{
    public partial class changeroleuserrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUser");

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

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "DeckId", "Description", "Title", "VisibilityType" },
                values: new object[,]
                {
                    { new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40"), null, "Deck1", 0 },
                    { new Guid("a2936d2e-97fe-4892-8542-0cd78b5567eb"), null, "Deck2", 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { new Guid("46f1bc82-bcaf-4c59-825b-979980813ca5"), "Admin" },
                    { new Guid("98b0ebe0-13a5-4b79-8899-d4cdfecb09d9"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Flashcards",
                columns: new[] { "FlashcardId", "Answer", "DeckId", "Question" },
                values: new object[,]
                {
                    { new Guid("20100ab0-436b-41e7-927b-f592e9b7b940"), "DOG", new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40"), "PIES" },
                    { new Guid("360b284f-421b-48fb-b7ab-dee2259d8116"), "CAT", new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40"), "KOT" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { new Guid("6b81215f-4b26-4493-93b0-b508dc91921b"), "User1@flashcards.com", "User1", "User1", new Guid("98b0ebe0-13a5-4b79-8899-d4cdfecb09d9") },
                    { new Guid("8e006f03-2172-4879-88f3-8e18d69ac935"), "User2@flashcards.com", "User2", "User2", new Guid("98b0ebe0-13a5-4b79-8899-d4cdfecb09d9") }
                });

            migrationBuilder.InsertData(
                table: "DeckUser",
                columns: new[] { "DeckId", "UserId", "IsEditable" },
                values: new object[,]
                {
                    { new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40"), new Guid("6b81215f-4b26-4493-93b0-b508dc91921b"), true },
                    { new Guid("a2936d2e-97fe-4892-8542-0cd78b5567eb"), new Guid("6b81215f-4b26-4493-93b0-b508dc91921b"), true }
                });

            migrationBuilder.InsertData(
                table: "FlashcardLevel",
                columns: new[] { "FlashcardId", "UserId", "Level" },
                values: new object[,]
                {
                    { new Guid("20100ab0-436b-41e7-927b-f592e9b7b940"), new Guid("6b81215f-4b26-4493-93b0-b508dc91921b"), 0 },
                    { new Guid("360b284f-421b-48fb-b7ab-dee2259d8116"), new Guid("6b81215f-4b26-4493-93b0-b508dc91921b"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "FolderId", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("48965add-832e-49b5-ac6a-b89fb3aa5087"), null, "Folder1", new Guid("6b81215f-4b26-4493-93b0-b508dc91921b") },
                    { new Guid("91d86030-9a4c-40a7-8cb9-352dffe5f6e5"), null, "Folder2", new Guid("6b81215f-4b26-4493-93b0-b508dc91921b") }
                });

            migrationBuilder.InsertData(
                table: "DeckFolder",
                columns: new[] { "DeckId", "FolderId" },
                values: new object[] { new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40"), new Guid("48965add-832e-49b5-ac6a-b89fb3aa5087") });

            migrationBuilder.InsertData(
                table: "DeckFolder",
                columns: new[] { "DeckId", "FolderId" },
                values: new object[] { new Guid("a2936d2e-97fe-4892-8542-0cd78b5567eb"), new Guid("48965add-832e-49b5-ac6a-b89fb3aa5087") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "DeckFolder",
                keyColumns: new[] { "DeckId", "FolderId" },
                keyValues: new object[] { new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40"), new Guid("48965add-832e-49b5-ac6a-b89fb3aa5087") });

            migrationBuilder.DeleteData(
                table: "DeckFolder",
                keyColumns: new[] { "DeckId", "FolderId" },
                keyValues: new object[] { new Guid("a2936d2e-97fe-4892-8542-0cd78b5567eb"), new Guid("48965add-832e-49b5-ac6a-b89fb3aa5087") });

            migrationBuilder.DeleteData(
                table: "DeckUser",
                keyColumns: new[] { "DeckId", "UserId" },
                keyValues: new object[] { new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40"), new Guid("6b81215f-4b26-4493-93b0-b508dc91921b") });

            migrationBuilder.DeleteData(
                table: "DeckUser",
                keyColumns: new[] { "DeckId", "UserId" },
                keyValues: new object[] { new Guid("a2936d2e-97fe-4892-8542-0cd78b5567eb"), new Guid("6b81215f-4b26-4493-93b0-b508dc91921b") });

            migrationBuilder.DeleteData(
                table: "FlashcardLevel",
                keyColumns: new[] { "FlashcardId", "UserId" },
                keyValues: new object[] { new Guid("20100ab0-436b-41e7-927b-f592e9b7b940"), new Guid("6b81215f-4b26-4493-93b0-b508dc91921b") });

            migrationBuilder.DeleteData(
                table: "FlashcardLevel",
                keyColumns: new[] { "FlashcardId", "UserId" },
                keyValues: new object[] { new Guid("360b284f-421b-48fb-b7ab-dee2259d8116"), new Guid("6b81215f-4b26-4493-93b0-b508dc91921b") });

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: new Guid("91d86030-9a4c-40a7-8cb9-352dffe5f6e5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("46f1bc82-bcaf-4c59-825b-979980813ca5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8e006f03-2172-4879-88f3-8e18d69ac935"));

            migrationBuilder.DeleteData(
                table: "Decks",
                keyColumn: "DeckId",
                keyValue: new Guid("a2936d2e-97fe-4892-8542-0cd78b5567eb"));

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "FlashcardId",
                keyValue: new Guid("20100ab0-436b-41e7-927b-f592e9b7b940"));

            migrationBuilder.DeleteData(
                table: "Flashcards",
                keyColumn: "FlashcardId",
                keyValue: new Guid("360b284f-421b-48fb-b7ab-dee2259d8116"));

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: new Guid("48965add-832e-49b5-ac6a-b89fb3aa5087"));

            migrationBuilder.DeleteData(
                table: "Decks",
                keyColumn: "DeckId",
                keyValue: new Guid("910f6e0e-9d9d-48ed-b995-835eb99c3c40"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("6b81215f-4b26-4493-93b0-b508dc91921b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("98b0ebe0-13a5-4b79-8899-d4cdfecb09d9"));

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UserId",
                table: "RoleUser",
                column: "UserId");
        }
    }
}
