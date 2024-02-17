using Microsoft.EntityFrameworkCore;
using CinemaBookingSystemApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var configBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json");

if (builder.Environment.IsDevelopment())
{
    configBuilder.AddJsonFile("appsettings.Development.json");
}

var config = configBuilder.Build();

var useInMemoryDB = config.GetValue<bool>("useInMemoryDB");
var connectionString = config.GetConnectionString("CinemaBookingSystemConnection");

if(useInMemoryDB){
    builder.Services.AddDbContext<CinemaBookingSystemContext>(opt =>
    opt.UseInMemoryDatabase("CinemaBookingSystem"));
} else {
    builder.Services.AddDbContext<CinemaBookingSystemContext>(opt =>
    opt.UseSqlServer(connectionString));
}

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
