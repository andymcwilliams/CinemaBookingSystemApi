using CinemaBookingSystemApi.Models;

namespace CinemaBookingSystemApi.Requests;

public record CreateMovieRequest
{
    public required string Name { get; set; }

    public Movie ToModel(){
        return new Movie{
            Name = Name
        };
    }
}