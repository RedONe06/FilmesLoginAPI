using API_Filme.Data;
using API_Filme.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using API_Gerente.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddDbContext<FilmeDbContext>(opts => opts
.UseLazyLoadingProxies()
.UseMySql(builder.Configuration.GetConnectionString("FilmeConnection"), new MySqlServerVersion(new Version(8, 0))));


builder.Services.AddScoped<CinemaService, CinemaService>();
builder.Services.AddScoped<FilmeService, FilmeService>();
builder.Services.AddScoped<EnderecoService, EnderecoService>();
builder.Services.AddScoped<GerenteService, GerenteService>();
builder.Services.AddScoped<SessaoService, SessaoService>();
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(token =>
{
    token.RequireHttpsMetadata = false;
    token.SaveToken = true;
    token.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("hello world hello world hello world")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();
app.UseAuthentication();

app.Run();
