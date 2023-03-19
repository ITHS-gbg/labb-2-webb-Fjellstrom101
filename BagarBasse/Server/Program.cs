using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BagarBasse.DataAccess;
using BagarBasse.Server;
using BagarBasse.Server.Data;
using BagarBasse.Server.Extensions;
using BagarBasse.Server.Models;
using BagarBasse.Server.Services.CartService;
using BagarBasse.Server.Services.CategoryService;
using BagarBasse.Server.Services.OrderService;
using BagarBasse.Server.Services.ProductService;
using BagarBasse.Server.Services.ProfileService;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var userConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var storeConnectionString = builder.Configuration.GetConnectionString("StoreConnection") ?? throw new InvalidOperationException("Connection string 'StoreConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(userConnectionString));

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(storeConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(
        options =>
        {
            options.IdentityResources["openid"].UserClaims.Add("name");
            options.ApiResources.Single().UserClaims.Add("name");
            options.IdentityResources["openid"].UserClaims.Add("role");
            options.ApiResources.Single().UserClaims.Add("role");
        });
//.AddProfileService<ProfileService>();

JwtSecurityTokenHandler
    .DefaultInboundClaimTypeMap.Remove("role");



builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();



//Add Custom Services

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddTransient<IProfileService, ProfileService>();

builder.Services.Configure<IdentityOptions>(options =>
    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);


//builder.Services.AddAuthorizationBuilder()
//    .AddPolicy("user", policy =>
//        policy
//            .RequireRole("user"));




var app = builder.Build();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




// Map Extensions
app.MapProductApi();
app.MapCategoryApi();
app.MapCartApi();
app.MapOrderApi();


app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();






app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
