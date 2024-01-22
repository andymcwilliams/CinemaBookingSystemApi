# CinemaBookingSystemApi

https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio-code

```
dotnet aspnet-codegenerator controller -name MoviesController -async -api -m Movie -dc CinemaBookingSystemContext -outDir Controllers
```


![challenge](img/challenge.jpg)

# Build and Run

```dotnet run --launch-profile https```

The default browser is launched to https://localhost:<port>/swagger/index.html, where <port> is the randomly chosen port number displayed in the output. There is no endpoint at https://localhost:<port>, so the browser returns HTTP 404 Not Found. Append /swagger to the URL, https://localhost:<port>/swagger.