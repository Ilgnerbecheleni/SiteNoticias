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

//--------------------------------------------------

builder.Services.AddScoped<UsuarioServico>();

builder.Services.AddScoped<UsuarioRepositorio>();

//--------------------------------------------------
builder.Services.AddScoped<NoticiaServico>();

builder.Services.AddScoped<NoticiaRepositorio>();

//--------------------------------------------------
builder.Services.AddScoped<ComentarioServico>();

builder.Services.AddScoped<ComentarioRepositorio>();



builder.Services.AddDbContext<ContextoBD>(

options =>

options.UseMySql(

builder.Configuration.GetConnectionString("ConexaoBanco"),

ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoBanco"))

));

builder.Services.AddCors();





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

app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
