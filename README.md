# Stock Management Web API

## Description

This is a .NET Web API project. It serves as a starting point for building a RESTful API using .NET Core.

## Project Structure

- **Solution File**: `first-dotnet-web-api-project.sln`
- **Project Directory**: `api/`
  - **Project File**: `api.csproj`
  - **Configuration Files**: `appsettings.json`, `appsettings.Development.json`
  - **Source Files**: `Program.cs`
  - **HTTP Request File**: `api.http`
  - **Git Ignore File**: `.gitignore`
  - **Object Directory**: `obj/`

## Installation

1. Clone the repository:

   ```sh
   git clone <repository-url>
   cd first-dotnet-web-api-project
   ```

2. Open the solution in Visual Studio:
   ```sh
   code first-dotnet-web-api-project.sln
   ```

## Usage

1. Restore the dependencies:

   ```sh
   dotnet restore
   ```

2. Build the project:

   ```sh
   dotnet build
   ```

3. Run the project:

   ```sh
   dotnet run --project api/api.csproj
   ```

4. Test the API using the `api.http` file or any API testing tool (e.g., Postman, curl).

## Database Configuration

This project uses SQL Server as the database. The connection string can be found and modified in the `appsettings.json` file.

### appsettings.json

\`\`\`json
{
"ConnectionStrings": {
"DefaultConnection": "Server=localhost;Database=your-database-name;User Id=your-username;Password=your-password;"
},
"Logging": {
"LogLevel": {
"Default": "Information",
"Microsoft": "Warning",
"Microsoft.Hosting.Lifetime": "Information"
}
},
"AllowedHosts": "\*"
}
\`\`\`

Ensure that you update the `DefaultConnection` string with your actual database server, database name, username, and password.

## Docker Setup

You can run this project using Docker. Follow the steps below to build and run the Docker container.

1. Create a `Dockerfile` in the root directory:

   \`\`\`dockerfile
   FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
   WORKDIR /app
   EXPOSE 80

   FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
   WORKDIR /src
   COPY ["api/api.csproj", "api/"]
   RUN dotnet restore "api/api.csproj"
   COPY . .
   WORKDIR "/src/api"
   RUN dotnet build "api.csproj" -c Release -o /app/build

   FROM build AS publish
   RUN dotnet publish "api.csproj" -c Release -o /app/publish

   FROM base AS final
   WORKDIR /app
   COPY --from=publish /app/publish .
   ENTRYPOINT ["dotnet", "api.dll"]
   \`\`\`

2. Build the Docker image:

   ```sh
   docker build -t first-dotnet-web-api .
   ```

3. Run the Docker container:

   ```sh
   docker run -d -p 8080:80 --name first-dotnet-web-api first-dotnet-web-api
   ```

4. Access the API at `http://localhost:8080`.

## Contributing

1. Fork the repository.
2. Create a new feature branch:
   ```sh
   git checkout -b feature/your-feature-name
   ```
3. Commit your changes:
   ```sh
   git commit -m 'Add some feature'
   ```
4. Push to the branch:
   ```sh
   git push origin feature/your-feature-name
   ```
5. Open a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
