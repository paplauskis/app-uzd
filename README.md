### To run the app:

Clone the repository:

```git clone https://github.com/paplauskis/app-uzd.git```

```cd app-uzd```

Restore dependencies:

```dotnet restore```

Build the project:

```dotnet build```

Configure the database connection in appsettings.json.

Apply database migrations (if applicable):

```dotnet ef database update```

Run the application:
```dotnet run```
