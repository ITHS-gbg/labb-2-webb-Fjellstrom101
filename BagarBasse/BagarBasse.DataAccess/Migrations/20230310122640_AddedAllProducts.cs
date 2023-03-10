using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BagarBasse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedAllProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Deleted", "Description", "Image", "Ingredients", "Title" },
                values: new object[,]
                {
                    { 7, 1, false, "Älskar du choklad? Vi har gjort ett cupcake-sortiment just för dig. Njut av fyra Devil's Food-cupcakes med chokladmockasmörkräm, fyra Chokladtryffelcupcakes fyllda med vit chokladganache och doppad i chokladganache, och fyra Chokladcupcakes med en krämig jordnötssmörkräm och toppad med hackade jordnötter.", "images/7-1.webp", "Butter, All Purpose Flour, Egg, Salt, Sugar, Vanilla, Canola Oil, Milk, Coca Powder, Baking Powder, Confectioner’S Sugar, Peanut Butter, Peanuts, Heavy Cream", "Chokladälskarens Cupcake Blandning" },
                    { 8, 1, false, "Vad gör vår vaniljcupcake till en bästsäljare? En oemotståndligt lätt och smörig smula toppad med vanilj eller chokladsmörkräm, alltid i vår signaturvirvel.", "images/8-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Chocolate Callets 65%, Confectionary Sugar, Sprinkles, Egg Whites, Food Dye", "Klassiska Vanilj Cupcakes" },
                    { 9, 3, false, "Det stämmer – vi förvandlade vår berömda bananpudding till en snart känd kaka. Vår Banana Pudding Cookie är en mjuk och söt godbit fylld med vita chokladchips, vaniljrån och vår världsberömda bananpuddingmix. Njut av 6 kakor i varje förpackning - tillräckligt att dela!", "images/9-1.webp", "Vanilla wafers, bananas, butter, all purpose flour, egg, salt, sugar, vanilla, milk powder, baking soda, brown sugar, white chocolate chips", "Banan Pudding Kakor" },
                    { 10, 2, false, "Dela dina känslor med tre hjärtformade utskurna kakor, täckta med rött, vitt och rosa socker.", "images/10-1.webp", "Flour, Salt, Baking Soda, Butter, Sugar, Eggs, Vanilla Extract, Sanding Sugar, Food Dye", "Hjärtformade Kakor" },
                    { 11, 3, false, "Denna kaka innehåller våra mjukgräddade, bananpudding-packade kakor med en läcker twist - vår berömda Red Velvet-kaka!", "images/11-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites", "Red Velvet Banan Pudding Kakor" },
                    { 12, 3, false, "Vår mjuka och sega version av den klassiska chokladkakan – men gör den chunky!", "images/12-1.webp", "AP Flour, Baking Soda, Salt, Butter, Granulated Sugar, Brown Sugar, Vanilla Extract, Eggs, Chocolate Callets 65%", "Chocolate Chunk Cookies" },
                    { 13, 3, false, "Fyll din kakburk med två av våra favoritklassiker: ett dussin vardera av våra chokladbitar och havregrynsrussinkakor.", "images/13-1.webp", "AP Flour, Baking Soda, Salt, Butter, Granulated Sugar, Brown Sugar, Vanilla Extract, Eggs, Chocolate Callets 65%, Cinnamon, Oats, Raisins", "Blandade Kakor" },
                    { 14, 2, false, "Dela dina känslor med tre hjärtformade utskurna kakor, täckta med rött, vitt och rosa socker.", "images/14-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites", "Dela kärleken med våra världsberömda minichoklad- och vaniljcupcakes, alla toppade med ett sortiment av vår vanilj- och chokladsmörkräm och alla hjärtans dag-dekorationer." },
                    { 15, 2, false, "Vår klassiska konfetti-tårta blir rosa till Alla hjärtans dag, dekorerad med hjärtkinnar och inskriven med \"Be Mine\" på toppen.", "images/15-1.webp", "Sugar, Butter, Vanilla, Cake Flour, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Confetti, Food Dye, Confectioner's Sugar", "Alla Hjärtans Dags Tårta" },
                    { 16, 2, false, "Våra klassiska vanilj-, choklad- och röd sammetscupcakes toppade med vackra blommönster gjorda med röd, vit eller rosa vaniljsmörkräm – den perfekta Alla hjärtans dag-presenten!", "images/16-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites", "Rosencupcakes" },
                    { 17, 4, false, "Vi gör vår smöriga, älskade vaniljkaka extra festlig med konfetti hopvikt i varje lager, täcker sedan tårtan med smörkräm och pryder den med mer konfetti utanför.", "images/17-1.webp", "Cake Flour, Granulated Sugar, Butter, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Vanilla Extract, Confectionary Sugar, Chocolate Callets 65%, Sprinkles", "Konfettitårta" },
                    { 18, 4, false, "Den unika kombinationen av banan, ananas och pekannötter smaksätter denna klassiska södra lagerkaka, som har en konsistens som liknar vår extra fuktiga morotskaka. Vi avslutar denna storsäljare med färskostglasyr och ett stänk pekannötter.", "images/18-1.webp", "AP Flour, Baking Soda, Salt, Cinnamon, Bananas, Eggs, Granulated Sugar, Canola Oil, Pineapple, Vanilla Extract, Pecans, Cream Cheese, Confectionary Sugar", "Kolibritårta" },
                    { 19, 4, false, "Tre lager superrik chokladkaka och silkeslen chokladsmörkräm betyder ren, överseende lycka.", "images/19-1.webp", "AP Flour, Granulated Sugar, Canola oil, Cocoa Powder, Baking Powder, Baking Soda, Salt, Milk, Eggs, Vanilla Extract, Confectionary Sugar, Food Dye, Sprinkles", "Chokladtårta" },
                    { 20, 4, false, "Vi laddar vår superfuktiga morotskaka med nyrivna morötter, saftig ananas, riven kokos, russin och valnötter och toppar den sedan med syrlig färskostfrosting och mer hackade nötter.", "images/20-1.webp", "AP Flour, Cinnamon, Baking Powder, Baking Soda, Salt, Eggs, Granulated Sugar, Canola Oil, Carrots, Pineapple, Raisins, Coconut Sweetened, Walnuts, Cream Cheese", "Morotstårta" },
                    { 21, 5, false, "Hur förbättrar du vår klassiska cheesecake med vaniljstång? Toppa den med smörig kola och rostade pekannötter!", "images/21-1.webp", "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Milk, Graham Cracker, Butter, Caramel, Pecans", "Karamel Pekan Cheesecake" },
                    { 22, 5, false, "Smaksatt med vaniljbönor från översta hyllan ovanpå en graham cracker skorpa, är denna rika cheesecake en klassiker av en utsökt god anledning.", "images/22-1.webp", "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Milk, Graham Cracker, Butter", "Vanilj Cheesecake" },
                    { 23, 5, false, "Smaka på sommarens sötma året runt med vår key lime cheesecake, smaksatt med färsk key lime juice och avslutad med en graham cracker crust och en klick vispgrädde.", "images/23-1.webp", "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Graham Cracker, Butter, Salt, Key Lime Juice", "Key Lime Cheesecake" },
                    { 24, 5, false, "Juicy blåbär toppar vår tidlösa cheesecake med vaniljstång, avslutad med en graham cracker crust.", "images/24-1.webp", "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Milk, Graham Cracker, Butter, Blueberries, Lemon Zest, Cornstarch, Water, Brown Sugar", "Blåbärs Cheesecake" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
