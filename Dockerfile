FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY ["RealEstate.API/RealEstate.API.csproj", "RealEstate.API/"]
COPY ["RealEstate.Application/RealEstate.Application.csproj", "RealEstate.Application/"]
COPY ["RealEstate.Domain/RealEstate.Domain.csproj", "RealEstate.Domain/"]
COPY ["RealEstate.Infrastructure/RealEstate.Infrastructure.csproj", "RealEstate.Infrastructure/"]

RUN dotnet restore "RealEstate.API/RealEstate.API.csproj"

# Copy the remaining source code
COPY . .

# Publish the API project
WORKDIR "/src/RealEstate.API"
RUN dotnet publish "RealEstate.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Use shell form to expand the PORT environment variable provided by Render
ENTRYPOINT dotnet RealEstate.API.dll --urls "http://0.0.0.0:${PORT}"
