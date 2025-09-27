using Microsoft.EntityFrameworkCore;
using ProductsManager.Application.Entity;
using ProductsManager.Application.Interface;
using ProductsManager.Application.Service;
using ProductsManager.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source = Products.db"));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductEntity, ProductEntity>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/", () => "Hello world!");

app.Run();
