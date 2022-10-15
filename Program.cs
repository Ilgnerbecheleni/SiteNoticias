using Microsoft.EntityFrameworkCore;
using SiteNoticias.Data;
using SiteNoticias.Repositorios;
using SiteNoticias.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<PerfilServico>();

builder.Services.AddScoped<PerfilRepositorio>();

//------------------------------------------------

builder.Services.AddScoped<CategoriaServico>();

builder.Services.AddScoped<CategoriaRepositorio>();



builder.Services.AddDbContext<ContextoBD>(

options =>

options.UseMySql(

builder.Configuration.GetConnectionString("ConexaoBanco"),

ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoBanco"))

));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
