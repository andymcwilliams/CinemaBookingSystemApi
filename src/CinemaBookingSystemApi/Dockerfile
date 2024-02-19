# Use the official .NET SDK image from Docker Hub
FROM mcr.microsoft.com/dotnet/sdk AS build-env

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY ./CinemaBookingSystemApi/*.csproj ./
RUN dotnet restore

# Copy the remaining source code and build the application
COPY ./CinemaBookingSystemApi ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "CinemaBookingSystemApi.dll"]

ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000