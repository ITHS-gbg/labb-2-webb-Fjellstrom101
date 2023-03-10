using BagarBasse.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BagarBasse.DataAccess;

public class DataContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
                Description = "En av BagarBasses äldsta och mest sålda desserter, vår klassiska red velvet cupcake är en rödfärgad kaka med chokladsmak toppad med vispad vaniljglasyr.",
                Ingredients = "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Cider Vinegar, Vanilla Extract, Food Dye, AP Flour",
                Images = new List<string>
                {
                    "images/1-1.webp",
                    "images/1-2.webp"
                },
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Title = "Klassiska Vanilj Mini Cupcakes",
                Description = "Våra världsberömda vaniljcupcakes, förminskade ner till en (eller två!) tugga: lätt och smör vaniljkaka toppad med en signaturvirvel av vaniljsmörkräm.",
                Ingredients = "Granulated Sugar, Cocoa Powder, Cake Flour, Baking Soda, Salt, Butter, Eggs, Milk, Sour Cream, Vanilla Extract, Food Dye, AP Flour, Canola Oil, Cocoa Powder, Baking Powder, Confectionary Sugar, Sprinkles, Egg Whites",
                Images = new List<string>
                {
                    "images/2-1.webp"
                },
                CategoryId = 1
            },
            new Product
            {
                Id = 3,
                Title = "Klassiska Choklad Mini Cupcakes",
                Description = "Liten i storleken, enorm i smaken: Våra minichokladcupcakes är gjorda med vår lätta och fuktiga kaksmet och toppade med vanilj eller chokladsmörkräm.",
                Ingredients = "AP Flour, Granulated Sugar, Canola oil, Cocoa Powder, Baking Powder, Baking Soda, Salt, Milk, Eggs, Vanilla Extract, Chocolate Callets 65%, Confectionary Sugar, Sprinkles",
                Images = new List<string>
                {
                    "images/3-1.webp"
                },
                CategoryId = 1
            },
            new Product
            {
                Id = 4,
                Title = "Carrie Cupcakes",
                Description = "Återskapa vår favorit-SATC-scen med en krossvärd vaniljcupcake toppad med rosa vaniljsmörkräm och en tusensköna",
                Ingredients = "Cake Flour, Granulated Sugar, Butter, Baking Powder, Baking Soda, Salt, Milk, Sour Cream, Egg Whites, Vanilla Extract, Confectionary Sugar, Food Dye, Sprinkles",
                Images = new List<string>
                {
                    "images/4-1.webp",
                    "images/4-2.webp"
                },
                CategoryId = 1
            }
        );

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Products { get; set; }
}