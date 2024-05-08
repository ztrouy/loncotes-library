using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoncotesLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CheckoutDays = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patrons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaterialName = table.Column<string>(type: "text", nullable: false),
                    MaterialTypeId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    OutOfCirculationSince = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialTypes_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaterialId = table.Column<int>(type: "integer", nullable: false),
                    PatronId = table.Column<int>(type: "integer", nullable: false),
                    CheckoutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkouts_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checkouts_Patrons_PatronId",
                        column: x => x.PatronId,
                        principalTable: "Patrons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "History" },
                    { 3, "Comedy" },
                    { 4, "Sci-Fi" },
                    { 5, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "MaterialTypes",
                columns: new[] { "Id", "CheckoutDays", "Name" },
                values: new object[,]
                {
                    { 1, 14, "Children's Book" },
                    { 2, 21, "Book" },
                    { 3, 7, "Manga" },
                    { 4, 4, "Movie" }
                });

            migrationBuilder.InsertData(
                table: "Patrons",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsActive", "LastName" },
                values: new object[,]
                {
                    { 1, "42 Whatnot Way", "ztrouy@example.com", "Zachary", true, "Trouy" },
                    { 2, "69 Baser Boulevard", "zhop@example.com", "Zavier", true, "Hopson" },
                    { 3, "32 Cellular Court", "ccote@example.com", "Chad", true, "Cote" },
                    { 4, "27 Dullard Drive", "ebrewer@example.com", "Ezra", true, "Brewer" },
                    { 5, "83 Light Lane", "lbresson@example.com", "Lucas", true, "Bresson" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "GenreId", "MaterialName", "MaterialTypeId", "OutOfCirculationSince" },
                values: new object[,]
                {
                    { 1, 1, "Hems and Gems", 1, null },
                    { 2, 3, "Fighter Spiders", 1, null },
                    { 3, 3, "Hairy Clefairy", 1, null },
                    { 4, 1, "Book of Madness", 2, new DateTime(1995, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, "Age of Faith", 2, new DateTime(1950, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, "Romeo and or Juliet", 2, null },
                    { 7, 4, "Hyperion Cantos", 2, null },
                    { 8, 5, "Giddeon the 9th", 2, null },
                    { 9, 1, "Dead Witch Walking", 2, null },
                    { 10, 4, "Fall of Hyperion", 2, null },
                    { 11, 1, "Inuyasha", 3, new DateTime(2012, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 3, "Saiki K", 3, null },
                    { 13, 1, "Lord of the Rings", 4, null },
                    { 14, 2, "Song of the South", 4, new DateTime(1192, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 3, "Hot Fuzz", 4, null }
                });

            migrationBuilder.InsertData(
                table: "Checkouts",
                columns: new[] { "Id", "CheckoutDate", "MaterialId", "PatronId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, null },
                    { 3, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, null },
                    { 5, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 2, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2, new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2, new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 2, new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1, null },
                    { 15, new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, null },
                    { 19, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 3, null },
                    { 20, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, null },
                    { 22, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, null },
                    { 23, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, null },
                    { 24, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, null },
                    { 25, new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 5, null },
                    { 26, new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 5, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_MaterialId",
                table: "Checkouts",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_PatronId",
                table: "Checkouts",
                column: "PatronId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_GenreId",
                table: "Materials",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialTypeId",
                table: "Materials",
                column: "MaterialTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Patrons");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MaterialTypes");
        }
    }
}
