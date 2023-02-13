using FilmsMinimalAPI.Model;
using FilmsMinimalAPI.Services;
using FilmsMinimalAPI.Services.FilmServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FilmContext>(opt => opt.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = cinema; Trusted_Connection = true; MultipleActiveResultSets = true; Encrypt = false;"));

builder.Services.AddScoped<IFilmService, FilmService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var service = new FilmService();
app.MapGet("/film", service.GetAll);


app.MapPost("/film", service.Create);

app.Run();

