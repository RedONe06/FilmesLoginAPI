using API_Filme.Data;
using API_Filme.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<FilmeDbContext>(opts => opts
.UseLazyLoadingProxies()
.UseMySql(builder.Configuration.GetConnectionString("FilmeConnection"), new MySqlServerVersion(new Version(8, 0))));

builder.Services.AddScoped<CinemaService, CinemaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
