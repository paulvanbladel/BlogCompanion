# Port Adapter Demystified - Demo Project

This is a demonstration project showcasing the Ports and Adapters (Hexagonal Architecture) pattern.

## Getting Started

### Running the Project

To start the application from the command line, navigate to the project root and run:

```bash
dotnet run --project src/PortAdapterDemystified.Adapters.Web/PortAdapterDemystified.Adapters.Web.csproj
```

Or navigate to the web project directory:

```bash
cd src/PortAdapterDemystified.Adapters.Web
dotnet run
```

The application will start and typically listen on `http://localhost:5245` (check the console output for the actual port).

### Testing the API

A `.http` file is included for testing the API endpoints:

**Location:** `src/PortAdapterDemystified.Adapters.Web/PortAdapterDemystified.Adapters.Web.http`

You can use this file with:
- **Visual Studio Code** with the REST Client extension
- **Visual Studio** (built-in support)
- **JetBrains Rider** (built-in support)

#### Alternative Testing Options

You can also test using:

**Swagger UI:** Navigate to `http://localhost:5245/swagger` (when running in Development mode)

**cURL:**
```bash
curl -X POST http://localhost:5245/quote \
  -H "Content-Type: application/json" \
  -d '{"amount": 100000, "riskScore": 75}'
```

## Project Structure

- **Domain** - Core business logic and domain models
- **Application** - Use cases and application services
- **Adapters.Web** - Web API adapter (entry point)
