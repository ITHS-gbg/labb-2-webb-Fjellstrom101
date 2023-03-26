global using BagarBasse.Server.UnitOfWork;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BagarBasse.DataAccess;
using BagarBasse.OrderDataAccess.Context;
using BagarBasse.OrderDataAccess.UnitOfWork;
using BagarBasse.Server.Extensions;
using BagarBasse.Server.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var storeConnectionString = builder.Configuration.GetConnectionString("StoreConnection") ??
                            throw new InvalidOperationException("Connection string 'StoreConnection' not found.");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(storeConnectionString));

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("User", policy =>
        policy
            .RequireRole("Customer","Admin"))
    .AddPolicy("Admin", policy =>
        policy
            .RequireRole("Admin"));

//JwtSecurityTokenHandler
//    .DefaultInboundClaimTypeMap.Remove("role");


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.UseProductApi();
builder.Services.UseCategoryApi();
builder.Services.UseCartApi();
builder.Services.UseOrderApi();
builder.Services.UseAuthApi();
builder.Services.UseUserApi();
builder.Services.UseUserInfoApi();
builder.Services.UseProductTypeApi();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add Custom Services
builder.Services.AddScoped<IMongoContext, MongoContext>();
builder.Services.AddScoped<StoreUnitOfWork, StoreUnitOfWork>();
builder.Services.AddScoped<OrderUnitOfWork, OrderUnitOfWork>();


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
app.UseSwagger();
app.UseSwaggerUI();

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


app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.MapProductApi();
app.MapCategoryApi();
app.MapCartApi();
app.MapOrderApi();
app.MapProductTypeApi();
app.MapAuthApi();
app.MapUserApi();
app.MapUserInfoApi();

app.MapGet("/hello", () => "Hello world!").RequireAuthorization("Admin");

app.Run();