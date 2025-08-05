🏗️ Application Overview
a Personal Expense Tracker API - a RESTful web service that allows users to manage their personal expenses. It follows the layered architecture pattern commonly used in enterprise applications.

What the application does:
Stores expense records (description, amount, date, category),
Provides REST API endpoints to create, read, update, and delete expenses,
Uses a SQL Server database for persistence,
Provides automatic API documentation via Swagger.

ExpenseTrackerAPI/
  ├── Controllers/          # API endpoints (handles HTTP requests)
  ├── Data/                # Database context and configuration
  ├── DTOs/                # Data Transfer Objects (API contracts)
  ├── Models/              # Entity models (database structure)
  ├── Program.cs           # Application startup and configuration
  ├── appsettings.json     # Configuration settings
  └── ExpenseTrackerAPI.csproj  # Project dependencies