global using BagarBasse.Server.UnitOfWork;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BagarBasse.DataAccess;
using BagarBasse.Server.Extensions;
using BagarBasse.Server.Models;
using BagarBasse.Server.Services.AuthService;
using BagarBasse.Server.Services.CartService;
using BagarBasse.Server.Services.CategoryService;
using BagarBasse.Server.Services.OrderService;
using BagarBasse.Server.Services.ProductService;
using BagarBasse.Server.Services.UserInfoService;
using BagarBasse.Server.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var storeConnectionString = builder.Configuration.GetConnectionString("StoreConnection") ?? throw new InvalidOperationException("Connection string 'StoreConnection' not found.");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(storeConnectionString));


//JwtSecurityTokenHandler
//    .DefaultInboundClaimTypeMap.Remove("role");




builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();

//Add Custom Services

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserInfoService, UserInfoService>();
builder.Services.AddScoped<StoreUnitOfWork, StoreUnitOfWork>();

builder.Services.UseProductTypeApi();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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
app.MapProductTypeApi();
app.MapAuthApi();
app.MapUserApi();
app.MapUserInfoApi();


app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();






app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
