Here's a README.md file based on the provided solution for the Banking Control Panel application:

# Banking Control Panel

The Banking Control Panel is an ASP.NET Core Blazor Server application that allows managing clients, users, and addresses. It uses Entity Framework Core for data access and supports in-memory database configuration for testing and development purposes.

## Features

- Client management: Add, update, delete, and view clients
- User management: Add, update, delete, and view users
- Address management: Manage addresses associated with clients
- Login functionality: Users can log in to access the application
- Role-based access control: Admins have additional permissions

## Prerequisites

- .NET Core SDK 6.0 or higher
- Entity Framework Core tools (for migrations)

## Installation

1. Clone the repository:

```bash
git clone https://github.com/abdulqadir-53/BankingControlPanel.git
```

2. Navigate to the project directory:

```bash
cd BankingControlPanel
```

3. Restore dependencies:

```bash
dotnet restore
```

4. Build the project:

```bash
dotnet build
```

5. Run the application:

```bash
dotnet run
```

The application will start running on `https://localhost:5001`.

## Configuration

### In-Memory Database

To configure the application to use an in-memory database for testing and development, follow these steps:

1. Ensure that the `Microsoft.EntityFrameworkCore.InMemory` NuGet package is installed.

2. In the `Program.cs` file, configure the `DbContext` to use the in-memory database:

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("BankingControlPanelDB"));
```

3. Run the application, and the in-memory database will be used automatically.

### Migrations

If you are using a persistent database (e.g., SQL Server), you can run migrations to create the necessary database schema:

1. Install the required EF Core tools:

```bash
dotnet tool install --global dotnet-ef
```

2. Apply migrations:

```bash
dotnet ef database update
```

This will create the database schema based on your `ApplicationDbContext` configuration.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please create a new issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
