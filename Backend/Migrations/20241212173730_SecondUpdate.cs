using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SecondUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorSeries_Authors_AuthorsIdAuthor",
                table: "AuthorSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_ProducerSeries_Producers_ProducersIdProducer",
                table: "ProducerSeries");

            migrationBuilder.RenameColumn(
                name: "ProducersIdProducer",
                table: "ProducerSeries",
                newName: "ProducerIdProducer");

            migrationBuilder.RenameColumn(
                name: "AuthorsIdAuthor",
                table: "AuthorSeries",
                newName: "AuthorIdAuthor");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorSeries_Authors_AuthorIdAuthor",
                table: "AuthorSeries",
                column: "AuthorIdAuthor",
                principalTable: "Authors",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProducerSeries_Producers_ProducerIdProducer",
                table: "ProducerSeries",
                column: "ProducerIdProducer",
                principalTable: "Producers",
                principalColumn: "IdProducer",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorSeries_Authors_AuthorIdAuthor",
                table: "AuthorSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_ProducerSeries_Producers_ProducerIdProducer",
                table: "ProducerSeries");

            migrationBuilder.RenameColumn(
                name: "ProducerIdProducer",
                table: "ProducerSeries",
                newName: "ProducersIdProducer");

            migrationBuilder.RenameColumn(
                name: "AuthorIdAuthor",
                table: "AuthorSeries",
                newName: "AuthorsIdAuthor");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorSeries_Authors_AuthorsIdAuthor",
                table: "AuthorSeries",
                column: "AuthorsIdAuthor",
                principalTable: "Authors",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProducerSeries_Producers_ProducersIdProducer",
                table: "ProducerSeries",
                column: "ProducersIdProducer",
                principalTable: "Producers",
                principalColumn: "IdProducer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
