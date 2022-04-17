using MediatR;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;
using UserApi.UserData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DB service
var connectionString = builder
    .Configuration
    .GetConnectionString("UserContextConnectionString");

var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
builder.Services.AddDbContextPool<UserContext>(
    options => options.UseMySql(connectionString, serverVersion));


// Register Dependency Injection for UserData
builder.Services.AddScoped<IUserData, SqlUserData>();


builder.Services.AddMediatR(typeof(Program));


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
