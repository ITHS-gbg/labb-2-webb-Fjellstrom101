using BagarBasse.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BagarBasse.DataAccess;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductVariant>()
            .HasKey(p => new { p.ProductId, p.ProductTypeId });
        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ProductId, oi.ProductTypeId });


        modelBuilder.Entity<ProductType>().HasData(
            new ProductType() { Id = 1, Name = "Styck" },
            new ProductType() { Id = 2, Name = "2-pack" },
            new ProductType() { Id = 3, Name = "4-pack" },
            new ProductType() { Id = 4, Name = "6-pack" },
            new ProductType() { Id = 5, Name = "12-pack" },
            new ProductType() { Id = 6, Name = "24-pack" }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Cupcakes",
                Url = "cupcakes"
            },
            new Category
            {
                Id = 2,
                Name = "♥ Alla Hjärtans Dag ♥",
                Url = "allahjartansdag",
                BackgroundCssClass = "bg-pastel-pink"
            },
            new Category
            {
                Id = 3,
                Name = "Kakor",
                Url = "kakor"
            },
            new Category
            {
                Id = 4,
                Name = "Tårtor",
                Url = "tartor",
                BackgroundCssClass = "bg-pastel-yellow"
            },
            new Category
            {
                Id = 5,
                Name = "Cheesecakes",
                Url = "cheesecakes"
            }
        );
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "Red Velvet Cupcakes",
                Description =
                    "En av BagarBasses äldsta och mest sålda desserter, vår klassiska red velvet cupcake är en rödfärgad kaka med chokladsmak toppad med vispad vaniljglasyr.",
                Ingredients =
                    "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Cider Vinegar, Vanilla Extract, Food Dye, AP Flour",
                CategoryId = 1,
                Image = "images/1-1.webp"
            },
            new Product
            {
                Id = 2,
                Title = "Klassiska Vanilj Mini Cupcakes",
                Description =
                    "Våra världsberömda vaniljcupcakes, förminskade ner till en (eller två!) tugga: lätt och smör vaniljkaka toppad med en signaturvirvel av vaniljsmörkräm.",
                Ingredients =
                    "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites",
                CategoryId = 1,
                Image = "images/2-1.webp"
            },
            new Product
            {
                Id = 3,
                Title = "Klassiska Choklad Mini Cupcakes",
                Description =
                    "Liten i storleken, enorm i smaken: Våra minichokladcupcakes är gjorda med vår lätta och fuktiga kaksmet och toppade med vanilj eller chokladsmörkräm.",
                Ingredients =
                    "AP Flour, Granulated Sugar, Canola oil, Cocoa Powder, Baking Powder, Baking Soda, Salt, Milk, Eggs, Vanilla Extract, Chocolate Callets 65%, Confectionary Sugar, Sprinkles",
                CategoryId = 1,
                Image = "images/3-1.webp"
            },
            new Product
            {
                Id = 4,
                Title = "Carrie Cupcakes",
                Description =
                    "Återskapa vår favorit-SATC-scen med en krossvärd vaniljcupcake toppad med rosa vaniljsmörkräm och en tusensköna",
                Ingredients =
                    "Cake Flour, Granulated Sugar, Butter, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Vanilla Extract, Confectionary Sugar, Food Dye, Sprinkles",
                CategoryId = 1,
                Image = "images/4-1.webp"
            },
            new Product
            {
                Id = 5,
                Title = "Konfetti Cupcake Blandning",
                Description =
                    "Ingenting säger firande som konfetti, inifrån och ut. Våra klassiska vaniljcupcakes är laddade med konfetti, toppade med vaniljsmörkräm och duschade med mer konfetti!",
                Ingredients =
                    "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Chocolate Callets 65%, Confectionary Sugar, Sprinkles, Egg Whites, Food Dye",
                CategoryId = 1,
                Image = "images/5-1.webp"
            },
            new Product
            {
                Id = 6,
                Title = "Klassiska Choklad Cupcakes",
                Description =
                    "Ett sortiment av BagarBasses berömda chokladcupcakes: lätt som en fjäder chokladkaka toppad med vanilj eller chokladsmörkräm och diverse strössel.",
                Ingredients =
                    "Granulated Sugar, AP Flour, Cocoa Powder, Baking Powder, Baking Soda, Salt, Eggs, Milk, Vanilla Extract, Canola Oil, Water, Confectionary Sugar, Milk, Sprinkles, Food Dye",
                CategoryId = 1,
                Image = "images/6-1.webp"
            },
            new Product
            {
                Id = 7,
                Title = "Chokladälskarens Cupcake Blandning",
                Description =
                    "Älskar du choklad? Vi har gjort ett cupcake-sortiment just för dig. Njut av fyra Devil's Food-cupcakes med chokladmockasmörkräm, fyra Chokladtryffelcupcakes fyllda med vit chokladganache och doppad i chokladganache, och fyra Chokladcupcakes med en krämig jordnötssmörkräm och toppad med hackade jordnötter.",
                Ingredients =
                    "Butter, All Purpose Flour, Egg, Salt, Sugar, Vanilla, Canola Oil, Milk, Coca Powder, Baking Powder, Confectioner’S Sugar, Peanut Butter, Peanuts, Heavy Cream",
                CategoryId = 1,
                Image = "images/7-1.webp"
            },
            new Product
            {
                Id = 8,
                Title = "Klassiska Vanilj Cupcakes",
                Description =
                    "Vad gör vår vaniljcupcake till en bästsäljare? En oemotståndligt lätt och smörig smula toppad med vanilj eller chokladsmörkräm, alltid i vår signaturvirvel.",
                Ingredients =
                    "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Chocolate Callets 65%, Confectionary Sugar, Sprinkles, Egg Whites, Food Dye",
                CategoryId = 1,
                Image = "images/8-1.webp"
            },
            new Product
            {
                Id = 10,
                Title = "Hjärtformade Kakor",
                Description =
                    "Dela dina känslor med tre hjärtformade utskurna kakor, täckta med rött, vitt och rosa socker.",
                Ingredients = "Flour, Salt, Baking Soda, Butter, Sugar, Eggs, Vanilla Extract, Sanding Sugar, Food Dye",
                CategoryId = 2,
                Image = "images/10-1.webp"
            },
            new Product
            {
                Id = 14,
                Title =
					"Små Bitar Av Kärlek - Blandade Cupcakes",
                Description =
					"Dela kärleken med våra världsberömda minichoklad- och vaniljcupcakes, alla toppade med ett sortiment av vår vanilj- och chokladsmörkräm och alla hjärtans dag-dekorationer.",
                Ingredients =
                    "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites",
                CategoryId = 2,
                Image = "images/14-1.webp"
            },
            new Product
            {
                Id = 15,
                Title = "Alla Hjärtans Dags Tårta",
                Description =
                    "Vår klassiska konfetti-tårta blir rosa till Alla hjärtans dag, dekorerad med hjärtkinnar och inskriven med \"Be Mine\" på toppen.",
                Ingredients =
                    "Sugar, Butter, Vanilla, Cake Flour, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Confetti, Food Dye, Confectioner's Sugar",
                CategoryId = 2,
                Image = "images/15-1.webp"
            },
            new Product
            {
                Id = 16,
                Title = "Rosencupcakes",
                Description =
                    "Våra klassiska vanilj-, choklad- och röd sammetscupcakes toppade med vackra blommönster gjorda med röd, vit eller rosa vaniljsmörkräm – den perfekta Alla hjärtans dag-presenten!",
                Ingredients =
                    "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites",
                CategoryId = 2,
                Image = "images/16-1.webp"
            },
            new Product
            {
                Id = 9,
                Title = "Banan Pudding Kakor",
                Description =
                    "Det stämmer – vi förvandlade vår berömda bananpudding till en snart känd kaka. Vår Banana Pudding Cookie är en mjuk och söt godbit fylld med vita chokladchips, vaniljrån och vår världsberömda bananpuddingmix. Njut av 6 kakor i varje förpackning - tillräckligt att dela!",
                Ingredients =
                    "Vanilla wafers, bananas, butter, all purpose flour, egg, salt, sugar, vanilla, milk powder, baking soda, brown sugar, white chocolate chips",
                CategoryId = 3,
                Image = "images/9-1.webp"
            },
            new Product
            {
                Id = 11,
                Title = "Red Velvet Banan Pudding Kakor",
                Description =
                    "Denna kaka innehåller våra mjukgräddade, bananpudding-packade kakor med en läcker twist - vår berömda Red Velvet-kaka!",
                Ingredients =
                    "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites",
                CategoryId = 3,
                Image = "images/11-1.webp"
            },
            new Product
            {
                Id = 12,
                Title = "Chocolate Chunk Cookies",
                Description = "Vår mjuka och sega version av den klassiska chokladkakan – men gör den chunky!",
                Ingredients =
                    "AP Flour, Baking Soda, Salt, Butter, Granulated Sugar, Brown Sugar, Vanilla Extract, Eggs, Chocolate Callets 65%",
                CategoryId = 3,
                Image = "images/12-1.webp"
            },
            new Product
            {
                Id = 13,
                Title = "Blandade Kakor",
                Description =
                    "Fyll din kakburk med två av våra favoritklassiker: ett dussin vardera av våra chokladbitar och havregrynsrussinkakor.",
                Ingredients =
                    "AP Flour, Baking Soda, Salt, Butter, Granulated Sugar, Brown Sugar, Vanilla Extract, Eggs, Chocolate Callets 65%, Cinnamon, Oats, Raisins",
                CategoryId = 3,
                Image = "images/13-1.webp"
            },
            new Product
            {
                Id = 17,
                Title = "Konfettitårta",
                Description =
                    "Vi gör vår smöriga, älskade vaniljkaka extra festlig med konfetti hopvikt i varje lager, täcker sedan tårtan med smörkräm och pryder den med mer konfetti utanför.",
                Ingredients =
                    "Cake Flour, Granulated Sugar, Butter, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Vanilla Extract, Confectionary Sugar, Chocolate Callets 65%, Sprinkles",
                CategoryId = 4,
                Image = "images/17-1.webp"
            },
            new Product
            {
                Id = 18,
                Title = "Kolibritårta",
                Description =
                    "Den unika kombinationen av banan, ananas och pekannötter smaksätter denna klassiska södra lagerkaka, som har en konsistens som liknar vår extra fuktiga morotskaka. Vi avslutar denna storsäljare med färskostglasyr och ett stänk pekannötter.",
                Ingredients =
                    "AP Flour, Baking Soda, Salt, Cinnamon, Bananas, Eggs, Granulated Sugar, Canola Oil, Pineapple, Vanilla Extract, Pecans, Cream Cheese, Confectionary Sugar",
                CategoryId = 4,
                Image = "images/18-1.webp"
            },
            new Product
            {
                Id = 19,
                Title = "Chokladtårta",
                Description =
                    "Tre lager superrik chokladkaka och silkeslen chokladsmörkräm betyder ren, överseende lycka.",
                Ingredients =
                    "AP Flour, Granulated Sugar, Canola oil, Cocoa Powder, Baking Powder, Baking Soda, Salt, Milk, Eggs, Vanilla Extract, Confectionary Sugar, Food Dye, Sprinkles",
                CategoryId = 4,
                Image = "images/19-1.webp"
            },
            new Product
            {
                Id = 20,
                Title = "Morotstårta",
                Description =
                    "Vi laddar vår superfuktiga morotskaka med nyrivna morötter, saftig ananas, riven kokos, russin och valnötter och toppar den sedan med syrlig färskostfrosting och mer hackade nötter.",
                Ingredients =
                    "AP Flour, Cinnamon, Baking Powder, Baking Soda, Salt, Eggs, Granulated Sugar, Canola Oil, Carrots, Pineapple, Raisins, Coconut Sweetened, Walnuts, Cream Cheese",
                CategoryId = 4,
                Image = "images/20-1.webp"
            },
            new Product
            {
                Id = 21,
                Title = "Karamel Pekan Cheesecake",
                Description =
                    "Hur förbättrar du vår klassiska cheesecake med vaniljstång? Toppa den med smörig kola och rostade pekannötter!",
                Ingredients =
                    "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Milk, Graham Cracker, Butter, Caramel, Pecans",
                CategoryId = 5,
                Image = "images/21-1.webp"
            },
            new Product
            {
                Id = 22,
                Title = "Vanilj Cheesecake",
                Description =
                    "Smaksatt med vaniljbönor från översta hyllan ovanpå en graham cracker skorpa, är denna rika cheesecake en klassiker av en utsökt god anledning.",
                Ingredients =
                    "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Milk, Graham Cracker, Butter",
                CategoryId = 5,
                Image = "images/22-1.webp"
            },
            new Product
            {
                Id = 23,
                Title = "Key Lime Cheesecake",
                Description =
                    "Smaka på sommarens sötma året runt med vår key lime cheesecake, smaksatt med färsk key lime juice och avslutad med en graham cracker crust och en klick vispgrädde.",
                Ingredients =
                    "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Graham Cracker, Butter, Salt, Key Lime Juice",
                CategoryId = 5,
                Image = "images/23-1.webp"
            },
            new Product
            {
                Id = 24,
                Title = "Blåbärs Cheesecake",
                Description =
                    "Juicy blåbär toppar vår tidlösa cheesecake med vaniljstång, avslutad med en graham cracker crust.",
                Ingredients =
                    "Cream Cheese, Granulated Sugar, Vanilla Extract, Eggs, Lemon Juice, Heavy Cream, Milk, Graham Cracker, Butter, Blueberries, Lemon Zest, Cornstarch, Water, Brown Sugar",
                CategoryId = 5,
                Image = "images/24-1.webp"
            }
        );
        modelBuilder.Entity<ProductVariant>().HasData(
            new ProductVariant
            {
                ProductId = 1,
                ProductTypeId = 4,
                OriginalPrice = 149.9m,
                Price = 129.9M
            },
            new ProductVariant
            {
                ProductId = 2,
                ProductTypeId = 5,
                OriginalPrice = 120.0m,
                Price = 120.0m
            },
            new ProductVariant
            {
                ProductId = 3,
                ProductTypeId = 5,
                OriginalPrice = 120.0m,
                Price = 120.0m
            },
            new ProductVariant
            {
                ProductId = 4,
                ProductTypeId = 4,
                OriginalPrice = 149.9m,
                Price = 120.0m
            },
            new ProductVariant
            {
                ProductId = 5,
                ProductTypeId = 4,
                OriginalPrice = 149.9m,
                Price = 120.0m
            },
            new ProductVariant
            {
                ProductId = 6,
                ProductTypeId = 4,
                OriginalPrice = 149.9m,
                Price = 120.0m
            },
            new ProductVariant
            {
                ProductId = 7,
                ProductTypeId = 4,
                OriginalPrice = 480.0m,
                Price = 480.0m
            },
            new ProductVariant
            {
                ProductId = 8,
                ProductTypeId = 4,
                OriginalPrice = 149.9m,
                Price = 120.0m
            },
            new ProductVariant
            {
                ProductId = 9,
                ProductTypeId = 4,
                OriginalPrice = 80.0m,
                Price = 80.0m
            },
            new ProductVariant
            {
                ProductId = 10,
                ProductTypeId = 6,
                OriginalPrice = 300.0m,
                Price = 249.0m
            },
            new ProductVariant
            {
                ProductId = 11,
                ProductTypeId = 1,
                OriginalPrice = 450.0m,
                Price = 450.0m
            },
            new ProductVariant
            {
                ProductId = 12,
                ProductTypeId = 4,
                OriginalPrice = 259.0m,
                Price = 259.0m
            }, 
            new ProductVariant
            {
                ProductId = 13,
                ProductTypeId = 4,
                OriginalPrice = 150m,
                Price = 150m
            },
            new ProductVariant
            {
                ProductId = 14,
                ProductTypeId = 4,
                OriginalPrice = 150m,
                Price = 150m
            },
            new ProductVariant
            {
                ProductId = 15,
                ProductTypeId = 4,
                OriginalPrice = 100m,
                Price = 100m
            },
            new ProductVariant
            {
                ProductId = 16,
                ProductTypeId = 6,
                OriginalPrice = 300m,
                Price = 300m
            },
            new ProductVariant
            {
                ProductId = 17,
                ProductTypeId = 1,
                OriginalPrice = 380.0m,
                Price = 380.0m
            },
            new ProductVariant
            {
                ProductId = 18,
                ProductTypeId = 1,
                OriginalPrice = 360.0m,
                Price = 360.0m
            }
            ,
            new ProductVariant
            {
                ProductId = 19,
                ProductTypeId = 1,
                OriginalPrice = 340.0m,
                Price = 340.0m
            },
            new ProductVariant
            {
                ProductId = 20,
                ProductTypeId = 1,
                OriginalPrice = 310.0m,
                Price = 310.0m
            },
            new ProductVariant
            {
                ProductId = 21,
                ProductTypeId = 1,
                OriginalPrice = 65m,
                Price = 65m
            },
            new ProductVariant
            {
                ProductId = 22,
                ProductTypeId = 1,
                OriginalPrice = 65m,
                Price = 65m
            },
            new ProductVariant
            {
                ProductId = 23,
                ProductTypeId = 1,
                OriginalPrice = 65m,
                Price = 65m
            },
            new ProductVariant
            {
                ProductId = 24,
                ProductTypeId = 1,
                OriginalPrice = 65m,
                Price = 65m
            }
        );



        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
}