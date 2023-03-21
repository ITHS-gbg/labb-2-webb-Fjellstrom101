﻿// <auto-generated />
using System;
using BagarBasse.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BagarBasse.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230321100627_ProductFlags")]
    partial class ProductFlags
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BagarBasse.Shared.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundCssClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BackgroundCssClass = "",
                            Deleted = false,
                            Name = "Cupcakes",
                            Url = "cupcakes",
                            Visible = true
                        },
                        new
                        {
                            Id = 2,
                            BackgroundCssClass = "bg-pastel-pink",
                            Deleted = false,
                            Name = "♥ Alla Hjärtans Dag ♥",
                            Url = "allahjartansdag",
                            Visible = true
                        },
                        new
                        {
                            Id = 3,
                            BackgroundCssClass = "",
                            Deleted = false,
                            Name = "Kakor",
                            Url = "kakor",
                            Visible = true
                        },
                        new
                        {
                            Id = 4,
                            BackgroundCssClass = "bg-pastel-yellow",
                            Deleted = false,
                            Name = "Tårtor",
                            Url = "tartor",
                            Visible = true
                        },
                        new
                        {
                            Id = 5,
                            BackgroundCssClass = "",
                            Deleted = false,
                            Name = "Cheesecakes",
                            Url = "cheesecakes",
                            Visible = true
                        });
                });

            modelBuilder.Entity("BagarBasse.Shared.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BagarBasse.Shared.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "ProductId", "ProductTypeId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("BagarBasse.Shared.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "En av BagarBasses äldsta och mest sålda desserter, vår klassiska red velvet cupcake är en rödfärgad kaka med chokladsmak toppad med vispad vaniljglasyr.",
                            Image = "images/1-1.webp",
                            Ingredients = "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Cider Vinegar, Vanilla Extract, Food Dye, AP Flour",
                            Title = "Red Velvet Cupcakes",
                            Visible = true
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Våra världsberömda vaniljcupcakes, förminskade ner till en (eller två!) tugga: lätt och smör vaniljkaka toppad med en signaturvirvel av vaniljsmörkräm.",
                            Image = "images/2-1.webp",
                            Ingredients = "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites",
                            Title = "Klassiska Vanilj Mini Cupcakes",
                            Visible = true
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Liten i storleken, enorm i smaken: Våra minichokladcupcakes är gjorda med vår lätta och fuktiga kaksmet och toppade med vanilj eller chokladsmörkräm.",
                            Image = "images/3-1.webp",
                            Ingredients = "AP Flour, Granulated Sugar, Canola oil, Cocoa Powder, Baking Powder, Baking Soda, Salt, Milk, Eggs, Vanilla Extract, Chocolate Callets 65%, Confectionary Sugar, Sprinkles",
                            Title = "Klassiska Choklad Mini Cupcakes",
                            Visible = true
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Återskapa vår favorit-SATC-scen med en krossvärd vaniljcupcake toppad med rosa vaniljsmörkräm och en tusensköna",
                            Image = "images/4-1.webp",
                            Ingredients = "Cake Flour, Granulated Sugar, Butter, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Vanilla Extract, Confectionary Sugar, Food Dye, Sprinkles",
                            Title = "Carrie Cupcakes",
                            Visible = true
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Ingenting säger firande som konfetti, inifrån och ut. Våra klassiska vaniljcupcakes är laddade med konfetti, toppade med vaniljsmörkräm och duschade med mer konfetti!",
                            Image = "images/5-1.webp",
                            Ingredients = "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Chocolate Callets 65%, Confectionary Sugar, Sprinkles, Egg Whites, Food Dye",
                            Title = "Konfetti Cupcake Blandning",
                            Visible = true
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Ett sortiment av BagarBasses berömda chokladcupcakes: lätt som en fjäder chokladkaka toppad med vanilj eller chokladsmörkräm och diverse strössel.",
                            Image = "images/6-1.webp",
                            Ingredients = "Granulated Sugar, AP Flour, Cocoa Powder, Baking Powder, Baking Soda, Salt, Eggs, Milk, Vanilla Extract, Canola Oil, Water, Confectionary Sugar, Milk, Sprinkles, Food Dye",
                            Title = "Klassiska Choklad Cupcakes",
                            Visible = true
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Älskar du choklad? Vi har gjort ett cupcake-sortiment just för dig. Njut av fyra Devil's Food-cupcakes med chokladmockasmörkräm, fyra Chokladtryffelcupcakes fyllda med vit chokladganache och doppad i chokladganache, och fyra Chokladcupcakes med en krämig jordnötssmörkräm och toppad med hackade jordnötter.",
                            Image = "images/7-1.webp",
                            Ingredients = "Butter, All Purpose Flour, Egg, Salt, Sugar, Vanilla, Canola Oil, Milk, Coca Powder, Baking Powder, Confectioner’S Sugar, Peanut Butter, Peanuts, Heavy Cream",
                            Title = "Chokladälskarens Cupcake Blandning",
                            Visible = true
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Vad gör vår vaniljcupcake till en bästsäljare? En oemotståndligt lätt och smörig smula toppad med vanilj eller chokladsmörkräm, alltid i vår signaturvirvel.",
                            Image = "images/8-1.webp",
                            Ingredients = "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Chocolate Callets 65%, Confectionary Sugar, Sprinkles, Egg Whites, Food Dye",
                            Title = "Klassiska Vanilj Cupcakes",
                            Visible = true
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Deleted = false,
                            Description = "Dela dina känslor med tre hjärtformade utskurna kakor, täckta med rött, vitt och rosa socker.",
                            Image = "images/10-1.webp",
                            Ingredients = "Flour, Salt, Baking Soda, Butter, Sugar, Eggs, Vanilla Extract, Sanding Sugar, Food Dye",
                            Title = "Hjärtformade Kakor",
                            Visible = true
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 2,
                            Deleted = false,
                            Description = "Dela dina känslor med tre hjärtformade utskurna kakor, täckta med rött, vitt och rosa socker.",
                            Image = "images/14-1.webp",
                            Ingredients = "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites",
                            Title = "Dela kärleken med våra världsberömda minichoklad- och vaniljcupcakes, alla toppade med ett sortiment av vår vanilj- och chokladsmörkräm och alla hjärtans dag-dekorationer.",
                            Visible = true
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 2,
                            Deleted = false,
                            Description = "Vår klassiska konfetti-tårta blir rosa till Alla hjärtans dag, dekorerad med hjärtkinnar och inskriven med \"Be Mine\" på toppen.",
                            Image = "images/15-1.webp",
                            Ingredients = "Sugar, Butter, Vanilla, Cake Flour, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Confetti, Food Dye, Confectioner's Sugar",
                            Title = "Alla Hjärtans Dags Tårta",
                            Visible = true
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 2,
                            Deleted = false,
                            Description = "Våra klassiska vanilj-, choklad- och röd sammetscupcakes toppade med vackra blommönster gjorda med röd, vit eller rosa vaniljsmörkräm – den perfekta Alla hjärtans dag-presenten!",
                            Image = "images/16-1.webp",
                            Ingredients = "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites",
                            Title = "Rosencupcakes",
                            Visible = true
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "Det stämmer – vi förvandlade vår berömda bananpudding till en snart känd kaka. Vår Banana Pudding Cookie är en mjuk och söt godbit fylld med vita chokladchips, vaniljrån och vår världsberömda bananpuddingmix. Njut av 6 kakor i varje förpackning - tillräckligt att dela!",
                            Image = "images/9-1.webp",
                            Ingredients = "Vanilla wafers, bananas, butter, all purpose flour, egg, salt, sugar, vanilla, milk powder, baking soda, brown sugar, white chocolate chips",
                            Title = "Banan Pudding Kakor",
                            Visible = true
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "Denna kaka innehåller våra mjukgräddade, bananpudding-packade kakor med en läcker twist - vår berömda Red Velvet-kaka!",
                            Image = "images/11-1.webp",
                            Ingredients = "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites",
                            Title = "Red Velvet Banan Pudding Kakor",
                            Visible = true
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "Vår mjuka och sega version av den klassiska chokladkakan – men gör den chunky!",
                            Image = "images/12-1.webp",
                            Ingredients = "AP Flour, Baking Soda, Salt, Butter, Granulated Sugar, Brown Sugar, Vanilla Extract, Eggs, Chocolate Callets 65%",
                            Title = "Chocolate Chunk Cookies",
                            Visible = true
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "Fyll din kakburk med två av våra favoritklassiker: ett dussin vardera av våra chokladbitar och havregrynsrussinkakor.",
                            Image = "images/13-1.webp",
                            Ingredients = "AP Flour, Baking Soda, Salt, Butter, Granulated Sugar, Brown Sugar, Vanilla Extract, Eggs, Chocolate Callets 65%, Cinnamon, Oats, Raisins",
                            Title = "Blandade Kakor",
                            Visible = true
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 4,
                            Deleted = false,
                            Description = "Vi gör vår smöriga, älskade vaniljkaka extra festlig med konfetti hopvikt i varje lager, täcker sedan tårtan med smörkräm och pryder den med mer konfetti utanför.",
                            Image = "images/17-1.webp",
                            Ingredients = "Cake Flour, Granulated Sugar, Butter, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Vanilla Extract, Confectionary Sugar, Chocolate Callets 65%, Sprinkles",
                            Title = "Konfettitårta",
                            Visible = true
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 4,
                            Deleted = false,
                            Description = "Den unika kombinationen av banan, ananas och pekannötter smaksätter denna klassiska södra lagerkaka, som har en konsistens som liknar vår extra fuktiga morotskaka. Vi avslutar denna storsäljare med färskostglasyr och ett stänk pekannötter.",
                            Image = "images/18-1.webp",
                            Ingredients = "AP Flour, Baking Soda, Salt, Cinnamon, Bananas, Eggs, Granulated Sugar, Canola Oil, Pineapple, Vanilla Extract, Pecans, Cream Cheese, Confectionary Sugar",
                            Title = "Kolibritårta",
                            Visible = true
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 4,
                            Deleted = false,
                            Description = "Tre lager superrik chokladkaka och silkeslen chokladsmörkräm betyder ren, överseende lycka.",
                            Image = "images/19-1.webp",
                            Ingredients = "AP Flour, Granulated Sugar, Canola oil, Cocoa Powder, Baking Powder, Baking Soda, Salt, Milk, Eggs, Vanilla Extract, Confectionary Sugar, Food Dye, Sprinkles",
                            Title = "Chokladtårta",
                            Visible = true
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 4,
                            Deleted = false,
                            Description = "Vi laddar vår superfuktiga morotskaka med nyrivna morötter, saftig ananas, riven kokos, russin och valnötter och toppar den sedan med syrlig färskostfrosting och mer hackade nötter.",
                            Image = "images/20-1.webp",
                            Ingredients = "AP Flour, Cinnamon, Baking Powder, Baking Soda, Salt, Eggs, Granulated Sugar, Canola Oil, Carrots, Pineapple, Raisins, Coconut Sweetened, Walnuts, Cream Cheese",
                            Title = "Morotstårta",
                            Visible = true
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 5,
                            Deleted = false,
                            Description = "Hur förbättrar du vår klassiska cheesecake med vaniljstång? Toppa den med smörig kola och rostade pekannötter!",
                            Image = "images/21-1.webp",
                            Ingredients = "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Milk, Graham Cracker, Butter, Caramel, Pecans",
                            Title = "Karamel Pekan Cheesecake",
                            Visible = true
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 5,
                            Deleted = false,
                            Description = "Smaksatt med vaniljbönor från översta hyllan ovanpå en graham cracker skorpa, är denna rika cheesecake en klassiker av en utsökt god anledning.",
                            Image = "images/22-1.webp",
                            Ingredients = "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Milk, Graham Cracker, Butter",
                            Title = "Vanilj Cheesecake",
                            Visible = true
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 5,
                            Deleted = false,
                            Description = "Smaka på sommarens sötma året runt med vår key lime cheesecake, smaksatt med färsk key lime juice och avslutad med en graham cracker crust och en klick vispgrädde.",
                            Image = "images/23-1.webp",
                            Ingredients = "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Graham Cracker, Butter, Salt, Key Lime Juice",
                            Title = "Key Lime Cheesecake",
                            Visible = true
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 5,
                            Deleted = false,
                            Description = "Juicy blåbär toppar vår tidlösa cheesecake med vaniljstång, avslutad med en graham cracker crust.",
                            Image = "images/24-1.webp",
                            Ingredients = "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Milk, Graham Cracker, Butter, Blueberries, Lemon Zest, Cornstarch, Water, Brown Sugar",
                            Title = "Blåbärs Cheesecake",
                            Visible = true
                        });
                });

            modelBuilder.Entity("BagarBasse.Shared.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Styck"
                        },
                        new
                        {
                            Id = 2,
                            Name = "2-pack"
                        },
                        new
                        {
                            Id = 3,
                            Name = "4-pack"
                        },
                        new
                        {
                            Id = 4,
                            Name = "6-pack"
                        },
                        new
                        {
                            Id = 5,
                            Name = "12-pack"
                        },
                        new
                        {
                            Id = 6,
                            Name = "24-pack"
                        });
                });

            modelBuilder.Entity("BagarBasse.Shared.Models.ProductVariant", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("ProductId", "ProductTypeId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductVariants");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 149.9m,
                            Price = 129.9m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 2,
                            ProductTypeId = 5,
                            Deleted = false,
                            OriginalPrice = 120.0m,
                            Price = 120.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 3,
                            ProductTypeId = 5,
                            Deleted = false,
                            OriginalPrice = 120.0m,
                            Price = 120.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 149.9m,
                            Price = 120.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 5,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 149.9m,
                            Price = 120.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 6,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 149.9m,
                            Price = 120.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 480.0m,
                            Price = 480.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 8,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 149.9m,
                            Price = 120.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 9,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 80.0m,
                            Price = 80.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 10,
                            ProductTypeId = 6,
                            Deleted = false,
                            OriginalPrice = 300.0m,
                            Price = 249.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 11,
                            ProductTypeId = 1,
                            Deleted = false,
                            OriginalPrice = 450.0m,
                            Price = 450.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 12,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 259.0m,
                            Price = 259.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 13,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 150m,
                            Price = 150m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 14,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 150m,
                            Price = 150m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 15,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 100m,
                            Price = 100m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 16,
                            ProductTypeId = 6,
                            Deleted = false,
                            OriginalPrice = 300m,
                            Price = 300m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 17,
                            ProductTypeId = 1,
                            Deleted = false,
                            OriginalPrice = 380.0m,
                            Price = 380.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 18,
                            ProductTypeId = 1,
                            Deleted = false,
                            OriginalPrice = 360.0m,
                            Price = 360.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 19,
                            ProductTypeId = 1,
                            Deleted = false,
                            OriginalPrice = 340.0m,
                            Price = 340.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 20,
                            ProductTypeId = 1,
                            Deleted = false,
                            OriginalPrice = 310.0m,
                            Price = 310.0m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 21,
                            ProductTypeId = 1,
                            Deleted = false,
                            OriginalPrice = 65m,
                            Price = 65m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 22,
                            ProductTypeId = 1,
                            Deleted = false,
                            OriginalPrice = 65m,
                            Price = 65m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 23,
                            ProductTypeId = 1,
                            Deleted = false,
                            OriginalPrice = 65m,
                            Price = 65m,
                            Visible = true
                        },
                        new
                        {
                            ProductId = 24,
                            ProductTypeId = 1,
                            Deleted = false,
                            OriginalPrice = 65m,
                            Price = 65m,
                            Visible = true
                        });
                });

            modelBuilder.Entity("BagarBasse.Shared.Models.OrderItem", b =>
                {
                    b.HasOne("BagarBasse.Shared.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BagarBasse.Shared.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BagarBasse.Shared.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("BagarBasse.Shared.Models.Product", b =>
                {
                    b.HasOne("BagarBasse.Shared.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BagarBasse.Shared.Models.ProductVariant", b =>
                {
                    b.HasOne("BagarBasse.Shared.Models.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BagarBasse.Shared.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("BagarBasse.Shared.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BagarBasse.Shared.Models.Product", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
