using AutoMapper;
using GeekShopping.ProdutAPI.Config;
using GeekShopping.ProdutAPI.Model.Context;
using GeekShopping.ProdutAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder
    .Services.AddDbContext<MySQLContext>
    (options => options
    .UseMySql(connection, ServerVersion.AutoDetect(connection)));
   // new MySqlServerVersion(
        //new Version(5,5,37))));
// Add services to the container.
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.
    AddSwaggerGen
    (
    c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping", Version = "v1" });
        }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Garante que o Swagger UI saiba onde está o seu documento "v1"
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeekShopping v1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
