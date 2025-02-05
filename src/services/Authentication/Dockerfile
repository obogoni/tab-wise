# Development Stage: Use the full .NET SDK for dev purposes
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /source

# Copy the project file and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the source code into the container
COPY . .

# Expose the necessary port (for example, port 5000 for ASP.NET Core)
EXPOSE 5000

# Use dotnet watch to enable live reloading during development
CMD ["dotnet", "watch", "run"]
