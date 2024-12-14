using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    IdAuthor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Birth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nationality = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.IdAuthor);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    IdCharacter = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Rol = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CharSummary = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.IdCharacter);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    IdProducer = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProducerName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Foundation = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.IdProducer);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    IdSeries = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 70, nullable: false),
                    SeriesSummary = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Launch = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.IdSeries);
                });

            migrationBuilder.CreateTable(
                name: "AuthorSeries",
                columns: table => new
                {
                    AuthorsIdAuthor = table.Column<int>(type: "INTEGER", nullable: false),
                    SeriesIdSeries = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorSeries", x => new { x.AuthorsIdAuthor, x.SeriesIdSeries });
                    table.ForeignKey(
                        name: "FK_AuthorSeries_Authors_AuthorsIdAuthor",
                        column: x => x.AuthorsIdAuthor,
                        principalTable: "Authors",
                        principalColumn: "IdAuthor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorSeries_Series_SeriesIdSeries",
                        column: x => x.SeriesIdSeries,
                        principalTable: "Series",
                        principalColumn: "IdSeries",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSeries",
                columns: table => new
                {
                    CharactersIdCharacter = table.Column<int>(type: "INTEGER", nullable: false),
                    SeriesIdSeries = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSeries", x => new { x.CharactersIdCharacter, x.SeriesIdSeries });
                    table.ForeignKey(
                        name: "FK_CharacterSeries_Characters_CharactersIdCharacter",
                        column: x => x.CharactersIdCharacter,
                        principalTable: "Characters",
                        principalColumn: "IdCharacter",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSeries_Series_SeriesIdSeries",
                        column: x => x.SeriesIdSeries,
                        principalTable: "Series",
                        principalColumn: "IdSeries",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProducerSeries",
                columns: table => new
                {
                    ProducersIdProducer = table.Column<int>(type: "INTEGER", nullable: false),
                    SeriesIdSeries = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducerSeries", x => new { x.ProducersIdProducer, x.SeriesIdSeries });
                    table.ForeignKey(
                        name: "FK_ProducerSeries_Producers_ProducersIdProducer",
                        column: x => x.ProducersIdProducer,
                        principalTable: "Producers",
                        principalColumn: "IdProducer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProducerSeries_Series_SeriesIdSeries",
                        column: x => x.SeriesIdSeries,
                        principalTable: "Series",
                        principalColumn: "IdSeries",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorSeries_SeriesIdSeries",
                table: "AuthorSeries",
                column: "SeriesIdSeries");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSeries_SeriesIdSeries",
                table: "CharacterSeries",
                column: "SeriesIdSeries");

            migrationBuilder.CreateIndex(
                name: "IX_ProducerSeries_SeriesIdSeries",
                table: "ProducerSeries",
                column: "SeriesIdSeries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorSeries");

            migrationBuilder.DropTable(
                name: "CharacterSeries");

            migrationBuilder.DropTable(
                name: "ProducerSeries");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
