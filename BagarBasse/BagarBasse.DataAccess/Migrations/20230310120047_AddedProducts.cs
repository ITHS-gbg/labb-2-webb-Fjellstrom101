using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BagarBasse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Featured",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Deleted", "Description", "Image", "Ingredients", "Title" },
                values: new object[,]
                {
                    { 1, 1, false, "En av BagarBasses äldsta och mest sålda desserter, vår klassiska red velvet cupcake är en rödfärgad kaka med chokladsmak toppad med vispad vaniljglasyr.", "images/1-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Cider Vinegar, Vanilla Extract, Food Dye, AP Flour", "Red Velvet Cupcakes" },
                    { 2, 1, false, "Våra världsberömda vaniljcupcakes, förminskade ner till en (eller två!) tugga: lätt och smör vaniljkaka toppad med en signaturvirvel av vaniljsmörkräm.", "images/2-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites", "Klassiska Vanilj Mini Cupcakes" },
                    { 3, 1, false, "Liten i storleken, enorm i smaken: Våra minichokladcupcakes är gjorda med vår lätta och fuktiga kaksmet och toppade med vanilj eller chokladsmörkräm.", "images/3-1.webp", "AP Flour, Granulated Sugar, Canola oil, Cocoa Powder, Baking Powder, Baking Soda, Salt, Milk, Eggs, Vanilla Extract, Chocolate Callets 65%, Confectionary Sugar, Sprinkles", "Klassiska Choklad Mini Cupcakes" },
                    { 4, 1, false, "Återskapa vår favorit-SATC-scen med en krossvärd vaniljcupcake toppad med rosa vaniljsmörkräm och en tusensköna", "images/4-1.webp", "Cake Flour, Granulated Sugar, Butter, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Vanilla Extract, Confectionary Sugar, Food Dye, Sprinkles", "Carrie Cupcakes" },
                    { 5, 1, false, "Ingenting säger firande som konfetti, inifrån och ut. Våra klassiska vaniljcupcakes är laddade med konfetti, toppade med vaniljsmörkräm och duschade med mer konfetti!", "images/5-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Chocolate Callets 65%, Confectionary Sugar, Sprinkles, Egg Whites, Food Dye", "Konfetti Cupcake Blandning" },
                    { 6, 1, false, "Ett sortiment av BagarBasses berömda chokladcupcakes: lätt som en fjäder chokladkaka toppad med vanilj eller chokladsmörkräm och diverse strössel.", "images/6-1.webp", "Granulated Sugar, AP Flour, Cocoa Powder, Baking Powder, Baking Soda, Salt, Eggs, Milk, Vanilla Extract, Canola Oil, Water, Confectionary Sugar, Milk, Sprinkles, Food Dye", "Klassiska Choklad Cupcakes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<bool>(
                name: "Featured",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
