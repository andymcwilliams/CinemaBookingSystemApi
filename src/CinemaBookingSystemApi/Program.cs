using Microsoft.EntityFrameworkCore;
using CinemaBookingSystemApi;
using CinemaBookingSystemApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
});

var configBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json");

var config = configBuilder.Build();

var useInMemoryDB = config.GetValue<bool>("useInMemoryDB");
var connectionString = Environment.GetEnvironmentVariable("CinemaBookingSystemConnection");

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

app.UseSwagger();
app.UseSwaggerUI();

var logger = app.Services.GetRequiredService<ILogger<Program>>();

app.ConfigureExceptionHandler(logger);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
