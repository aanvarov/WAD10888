using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WAD.WebApp._10888.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Steak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    BinaryPhoto = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steak_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Steak_CategoryId",
                table: "Steak",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Steak");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
