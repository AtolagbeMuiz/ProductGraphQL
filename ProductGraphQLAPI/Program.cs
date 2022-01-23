global using GraphQL.Types;
using GraphQL.Server;
using Microsoft.AspNetCore.Mvc;
using ProductGraphQLAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductProvider, ProductProvider>();

builder.Services.AddTransient<ISchema, ProductSchema>();
builder.Services.AddTransient<ProductType>();
builder.Services.AddTransient<ProductQuery>();
builder.Services.AddGraphQL(opt => opt.EnableMetrics = false).AddSystemTextJson();
//builder.Services.AddGraphQL().AddSystemTextJson().AddSchema<ProductSchema>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.MapGet("/api/products", ([FromServices] IProductProvider productProvider) =>
{
    return productProvider.GetProducts();
}).WithName("GetProducts");

app.UseGraphQLAltair();
app.UseGraphQL<ISchema>();

app.Run();
