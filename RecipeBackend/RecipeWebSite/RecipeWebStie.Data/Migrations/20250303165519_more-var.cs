using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebStie.Data.Migrations
{
    public partial class morevar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FinalScore",
                table: "Recipes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WeightedRating",
                table: "Ratings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalScore",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "WeightedRating",
                table: "Ratings");
        }
    }
}
