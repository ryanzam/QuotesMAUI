using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuotesAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Quotes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Quotes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Quotes");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Quotes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
