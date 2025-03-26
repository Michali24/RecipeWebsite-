using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebStie.Data.Migrations
{
    public partial class addrecipevariable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DifficultyLevel",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipeAuthor",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DifficultyLevel",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeAuthor",
                table: "Recipes");
        }
    }
}
