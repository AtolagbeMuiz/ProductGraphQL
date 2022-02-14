global using GraphQL;
global using GraphQL.Types;
global using ProductGraphQLAPI.Models;
global using ProductGraphQLAPI.GraphQLCore;
global using ProductGraphQLAPI.GraphQLCore.Query;
using GraphQL.Server;
using Microsoft.AspNetCore.Mvc;
using ProductGraphQLAPI.GraphQLCore.Mutation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProductProvider, ProductProvider>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddSingleton<ISchema, ProductSchema>();

//Query Dependencies
builder.Services.AddSingleton<ProductType>();
builder.Services.AddSingleton<ProductQuery>();

//Mutation Dependencies
builder.Services.AddSingleton<ProductInput>();
builder.Services.AddSingleton<ProductMutation>();

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
