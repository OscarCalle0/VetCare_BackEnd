# Use the .NET SDK base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the solution file and project file
COPY VetCare_BackEnd.sln ./
COPY VetCare_BackEnd.csproj ./

# Restore the project dependencies
RUN dotnet restore VetCare_BackEnd.csproj

# Copy the rest of the code and build the project
COPY . ./
RUN dotnet publish VetCare_BackEnd.csproj -c Release -o out

# Create a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the compiled files from the build stage
COPY --from=build /app/out ./

# Set the entry point for the application
ENTRYPOINT ["dotnet", "VetCare_BackEnd.dll"]