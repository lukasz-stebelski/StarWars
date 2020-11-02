using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Model.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PlanetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Planet_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterEpisode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpisodeId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterEpisode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterEpisode_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterEpisode_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterFriend",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(nullable: false),
                    FriendId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFriend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterFriend_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharacterFriend_Character_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Name", "PlanetId" },
                values: new object[,]
                {
                    { 1, "Luke Skywalker", null },
                    { 2, "Darth Vader", null },
                    { 3, "Han Solo", null },
                    { 5, "Wilhuff Tarkin", null },
                    { 6, "C-3PO", null },
                    { 7, "R2-D2", null }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "NEWHOPE" },
                    { 2, "EMPIRE" },
                    { 3, "JEDI" }
                });

            migrationBuilder.InsertData(
                table: "Planet",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Alderaan" });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Name", "PlanetId" },
                values: new object[] { 4, "Leia Organa", 1 });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "Id", "CharacterId", "EpisodeId" },
                values: new object[,]
                {
                    { 16, 6, 3 },
                    { 13, 5, 3 },
                    { 9, 3, 3 },
                    { 6, 2, 3 },
                    { 3, 1, 3 },
                    { 18, 7, 2 },
                    { 15, 6, 2 },
                    { 12, 5, 2 },
                    { 8, 3, 2 },
                    { 5, 2, 2 },
                    { 2, 1, 2 },
                    { 17, 7, 1 },
                    { 14, 6, 1 },
                    { 19, 7, 3 },
                    { 11, 5, 1 },
                    { 4, 2, 1 },
                    { 1, 1, 1 },
                    { 7, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "Id", "CharacterId", "FriendId" },
                values: new object[,]
                {
                    { 19, 7, 3 },
                    { 18, 7, 1 },
                    { 17, 6, 7 },
                    { 8, 3, 7 },
                    { 4, 1, 7 },
                    { 15, 6, 3 },
                    { 14, 6, 1 },
                    { 3, 1, 6 },
                    { 13, 5, 2 },
                    { 5, 2, 5 },
                    { 6, 3, 1 },
                    { 1, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "CharacterEpisode",
                columns: new[] { "Id", "CharacterId", "EpisodeId" },
                values: new object[] { 10, 4, 1 });

            migrationBuilder.InsertData(
                table: "CharacterFriend",
                columns: new[] { "Id", "CharacterId", "FriendId" },
                values: new object[,]
                {
                    { 2, 1, 4 },
                    { 7, 3, 4 },
                    { 9, 4, 1 },
                    { 10, 4, 3 },
                    { 11, 4, 6 },
                    { 12, 4, 7 },
                    { 16, 6, 4 },
                    { 20, 7, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_PlanetId",
                table: "Character",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEpisode_CharacterId",
                table: "CharacterEpisode",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEpisode_EpisodeId",
                table: "CharacterEpisode",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFriend_CharacterId",
                table: "CharacterFriend",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFriend_FriendId",
                table: "CharacterFriend",
                column: "FriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterEpisode");

            migrationBuilder.DropTable(
                name: "CharacterFriend");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Planet");
        }
    }
}
