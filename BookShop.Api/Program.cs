using BookShop.Api.DataAccess;
using BookShop.Api.Repositories;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Api.Services;
using BookShop.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookShopDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(BookShopDbContext)));
    }
);

builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(routes =>
{
    routes.WithHeaders().AllowAnyHeader();
    routes.WithOrigins("https://localhost:7270");
    routes.WithMethods().AllowAnyMethod();
});

app.Run();
