using Microsoft.EntityFrameworkCore;
using CinemaBookingSystemApi.Models;

namespace CinemaBookingSystemApi;

public class CinemaBookingSystemContext : DbContext
{
    public CinemaBookingSystemContext(DbContextOptions<CinemaBookingSystemContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; } = null!;
}