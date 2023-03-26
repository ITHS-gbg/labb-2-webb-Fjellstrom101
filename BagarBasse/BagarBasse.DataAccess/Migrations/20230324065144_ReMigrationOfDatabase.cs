using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BagarBasse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReMigrationOfDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundCssClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ProductId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => new { x.ProductId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BackgroundCssClass", "Deleted", "Name", "Url", "Visible" },
                values: new object[,]
                {
                    { 1, "", false, "Cupcakes", "cupcakes", true },
                    { 2, "bg-pastel-pink", false, "♥ Alla Hjärtans Dag ♥", "allahjartansdag", true },
                    { 3, "", false, "Kakor", "kakor", true },
                    { 4, "bg-pastel-yellow", false, "Tårtor", "tartor", true },
                    { 5, "", false, "Cheesecakes", "cheesecakes", true }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Styck" },
                    { 2, "2-pack" },
                    { 3, "4-pack" },
                    { 4, "6-pack" },
                    { 5, "12-pack" },
                    { 6, "24-pack" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Deleted", "Description", "Image", "Ingredients", "Title", "Visible" },
                values: new object[,]
                {
                    { 1, 1, false, "En av BagarBasses äldsta och mest sålda desserter, vår klassiska red velvet cupcake är en rödfärgad kaka med chokladsmak toppad med vispad vaniljglasyr.", "images/1-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Cider Vinegar, Vanilla Extract, Food Dye, AP Flour", "Red Velvet Cupcakes", true },
                    { 2, 1, false, "Våra världsberömda vaniljcupcakes, förminskade ner till en (eller två!) tugga: lätt och smör vaniljkaka toppad med en signaturvirvel av vaniljsmörkräm.", "images/2-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites", "Klassiska Vanilj Mini Cupcakes", true },
                    { 3, 1, false, "Liten i storleken, enorm i smaken: Våra minichokladcupcakes är gjorda med vår lätta och fuktiga kaksmet och toppade med vanilj eller chokladsmörkräm.", "images/3-1.webp", "AP Flour, Granulated Sugar, Canola oil, Cocoa Powder, Baking Powder, Baking Soda, Salt, Milk, Eggs, Vanilla Extract, Chocolate Callets 65%, Confectionary Sugar, Sprinkles", "Klassiska Choklad Mini Cupcakes", true },
                    { 4, 1, false, "Återskapa vår favorit-SATC-scen med en krossvärd vaniljcupcake toppad med rosa vaniljsmörkräm och en tusensköna", "images/4-1.webp", "Cake Flour, Granulated Sugar, Butter, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Vanilla Extract, Confectionary Sugar, Food Dye, Sprinkles", "Carrie Cupcakes", true },
                    { 5, 1, false, "Ingenting säger firande som konfetti, inifrån och ut. Våra klassiska vaniljcupcakes är laddade med konfetti, toppade med vaniljsmörkräm och duschade med mer konfetti!", "images/5-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Chocolate Callets 65%, Confectionary Sugar, Sprinkles, Egg Whites, Food Dye", "Konfetti Cupcake Blandning", true },
                    { 6, 1, false, "Ett sortiment av BagarBasses berömda chokladcupcakes: lätt som en fjäder chokladkaka toppad med vanilj eller chokladsmörkräm och diverse strössel.", "images/6-1.webp", "Granulated Sugar, AP Flour, Cocoa Powder, Baking Powder, Baking Soda, Salt, Eggs, Milk, Vanilla Extract, Canola Oil, Water, Confectionary Sugar, Milk, Sprinkles, Food Dye", "Klassiska Choklad Cupcakes", true },
                    { 7, 1, false, "Älskar du choklad? Vi har gjort ett cupcake-sortiment just för dig. Njut av fyra Devil's Food-cupcakes med chokladmockasmörkräm, fyra Chokladtryffelcupcakes fyllda med vit chokladganache och doppad i chokladganache, och fyra Chokladcupcakes med en krämig jordnötssmörkräm och toppad med hackade jordnötter.", "images/7-1.webp", "Butter, All Purpose Flour, Egg, Salt, Sugar, Vanilla, Canola Oil, Milk, Coca Powder, Baking Powder, Confectioner’S Sugar, Peanut Butter, Peanuts, Heavy Cream", "Chokladälskarens Cupcake Blandning", true },
                    { 8, 1, false, "Vad gör vår vaniljcupcake till en bästsäljare? En oemotståndligt lätt och smörig smula toppad med vanilj eller chokladsmörkräm, alltid i vår signaturvirvel.", "images/8-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Chocolate Callets 65%, Confectionary Sugar, Sprinkles, Egg Whites, Food Dye", "Klassiska Vanilj Cupcakes", true },
                    { 9, 3, false, "Det stämmer – vi förvandlade vår berömda bananpudding till en snart känd kaka. Vår Banana Pudding Cookie är en mjuk och söt godbit fylld med vita chokladchips, vaniljrån och vår världsberömda bananpuddingmix. Njut av 6 kakor i varje förpackning - tillräckligt att dela!", "images/9-1.webp", "Vanilla wafers, bananas, butter, all purpose flour, egg, salt, sugar, vanilla, milk powder, baking soda, brown sugar, white chocolate chips", "Banan Pudding Kakor", true },
                    { 10, 2, false, "Dela dina känslor med tre hjärtformade utskurna kakor, täckta med rött, vitt och rosa socker.", "images/10-1.webp", "Flour, Salt, Baking Soda, Butter, Sugar, Eggs, Vanilla Extract, Sanding Sugar, Food Dye", "Hjärtformade Kakor", true },
                    { 11, 3, false, "Denna kaka innehåller våra mjukgräddade, bananpudding-packade kakor med en läcker twist - vår berömda Red Velvet-kaka!", "images/11-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites", "Red Velvet Banan Pudding Kakor", true },
                    { 12, 3, false, "Vår mjuka och sega version av den klassiska chokladkakan – men gör den chunky!", "images/12-1.webp", "AP Flour, Baking Soda, Salt, Butter, Granulated Sugar, Brown Sugar, Vanilla Extract, Eggs, Chocolate Callets 65%", "Chocolate Chunk Cookies", true },
                    { 13, 3, false, "Fyll din kakburk med två av våra favoritklassiker: ett dussin vardera av våra chokladbitar och havregrynsrussinkakor.", "images/13-1.webp", "AP Flour, Baking Soda, Salt, Butter, Granulated Sugar, Brown Sugar, Vanilla Extract, Eggs, Chocolate Callets 65%, Cinnamon, Oats, Raisins", "Blandade Kakor", true },
                    { 14, 2, false, "Dela kärleken med våra världsberömda minichoklad- och vaniljcupcakes, alla toppade med ett sortiment av vår vanilj- och chokladsmörkräm och alla hjärtans dag-dekorationer.", "images/14-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites", "Små Bitar Av Kärlek - Blandade Cupcakes", true },
                    { 15, 2, false, "Vår klassiska konfetti-tårta blir rosa till Alla hjärtans dag, dekorerad med hjärtkinnar och inskriven med \"Be Mine\" på toppen.", "images/15-1.webp", "Sugar, Butter, Vanilla, Cake Flour, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Confetti, Food Dye, Confectioner's Sugar", "Alla Hjärtans Dags Tårta", true },
                    { 16, 2, false, "Våra klassiska vanilj-, choklad- och röd sammetscupcakes toppade med vackra blommönster gjorda med röd, vit eller rosa vaniljsmörkräm – den perfekta Alla hjärtans dag-presenten!", "images/16-1.webp", "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites", "Rosencupcakes", true },
                    { 17, 4, false, "Vi gör vår smöriga, älskade vaniljkaka extra festlig med konfetti hopvikt i varje lager, täcker sedan tårtan med smörkräm och pryder den med mer konfetti utanför.", "images/17-1.webp", "Cake Flour, Granulated Sugar, Butter, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Vanilla Extract, Confectionary Sugar, Chocolate Callets 65%, Sprinkles", "Konfettitårta", true },
                    { 18, 4, false, "Den unika kombinationen av banan, ananas och pekannötter smaksätter denna klassiska södra lagerkaka, som har en konsistens som liknar vår extra fuktiga morotskaka. Vi avslutar denna storsäljare med färskostglasyr och ett stänk pekannötter.", "images/18-1.webp", "AP Flour, Baking Soda, Salt, Cinnamon, Bananas, Eggs, Granulated Sugar, Canola Oil, Pineapple, Vanilla Extract, Pecans, Cream Cheese, Confectionary Sugar", "Kolibritårta", true },
                    { 19, 4, false, "Tre lager superrik chokladkaka och silkeslen chokladsmörkräm betyder ren, överseende lycka.", "images/19-1.webp", "AP Flour, Granulated Sugar, Canola oil, Cocoa Powder, Baking Powder, Baking Soda, Salt, Milk, Eggs, Vanilla Extract, Confectionary Sugar, Food Dye, Sprinkles", "Chokladtårta", true },
                    { 20, 4, false, "Vi laddar vår superfuktiga morotskaka med nyrivna morötter, saftig ananas, riven kokos, russin och valnötter och toppar den sedan med syrlig färskostfrosting och mer hackade nötter.", "images/20-1.webp", "AP Flour, Cinnamon, Baking Powder, Baking Soda, Salt, Eggs, Granulated Sugar, Canola Oil, Carrots, Pineapple, Raisins, Coconut Sweetened, Walnuts, Cream Cheese", "Morotstårta", true },
                    { 21, 5, false, "Hur förbättrar du vår klassiska cheesecake med vaniljstång? Toppa den med smörig kola och rostade pekannötter!", "images/21-1.webp", "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Milk, Graham Cracker, Butter, Caramel, Pecans", "Karamel Pekan Cheesecake", true },
                    { 22, 5, false, "Smaksatt med vaniljbönor från översta hyllan ovanpå en graham cracker skorpa, är denna rika cheesecake en klassiker av en utsökt god anledning.", "images/22-1.webp", "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Milk, Graham Cracker, Butter", "Vanilj Cheesecake", true },
                    { 23, 5, false, "Smaka på sommarens sötma året runt med vår key lime cheesecake, smaksatt med färsk key lime juice och avslutad med en graham cracker crust och en klick vispgrädde.", "images/23-1.webp", "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Graham Cracker, Butter, Salt, Key Lime Juice", "Key Lime Cheesecake", true },
                    { 24, 5, false, "Juicy blåbär toppar vår tidlösa cheesecake med vaniljstång, avslutad med en graham cracker crust.", "images/24-1.webp", "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Milk, Graham Cracker, Butter, Blueberries, Lemon Zest, Cornstarch, Water, Brown Sugar", "Blåbärs Cheesecake", true }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "Deleted", "OriginalPrice", "Price", "Visible" },
                values: new object[,]
                {
                    { 1, 4, false, 149.9m, 129.9m, true },
                    { 2, 5, false, 120.0m, 120.0m, true },
                    { 3, 5, false, 120.0m, 120.0m, true },
                    { 4, 4, false, 149.9m, 120.0m, true },
                    { 5, 4, false, 149.9m, 120.0m, true },
                    { 6, 4, false, 149.9m, 120.0m, true },
                    { 7, 4, false, 480.0m, 480.0m, true },
                    { 8, 4, false, 149.9m, 120.0m, true },
                    { 9, 4, false, 80.0m, 80.0m, true },
                    { 10, 6, false, 300.0m, 249.0m, true },
                    { 11, 1, false, 450.0m, 450.0m, true },
                    { 12, 4, false, 259.0m, 259.0m, true },
                    { 13, 4, false, 150m, 150m, true },
                    { 14, 4, false, 150m, 150m, true },
                    { 15, 4, false, 100m, 100m, true },
                    { 16, 6, false, 300m, 300m, true },
                    { 17, 1, false, 380.0m, 380.0m, true },
                    { 18, 1, false, 360.0m, 360.0m, true },
                    { 19, 1, false, 340.0m, 340.0m, true },
                    { 20, 1, false, 310.0m, 310.0m, true },
                    { 21, 1, false, 65m, 65m, true },
                    { 22, 1, false, 65m, 65m, true },
                    { 23, 1, false, 65m, 65m, true },
                    { 24, 1, false, 65m, 65m, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductTypeId",
                table: "OrderItems",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductTypeId",
                table: "ProductVariants",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_UserId",
                table: "UserInfos",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
