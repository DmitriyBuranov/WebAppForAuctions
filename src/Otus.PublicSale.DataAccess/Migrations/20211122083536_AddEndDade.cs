using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Otus.PublicSale.DataAccess.Migrations
{
    public partial class AddEndDade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Auctions");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Auctions",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Auctions");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
