using ComputerAccessories.Data;
using ComputerAccessories.IRepositories;
using ComputerAccessories.IServices;
using ComputerAccessories.Model;
using ComputerAccessories.Repositories;
using ComputerAccessories.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AppDbContext>( options => options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddScoped<IMouseService, MouseService>();
builder.Services.AddScoped<IMouseRepository, MouseRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
