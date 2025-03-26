How to Set Up and Run the Application
Prerequisites
.NET 8 SDK

SQL Server or SQL Express

Visual Studio 2022 or newer (recommended)

Setup Steps

1. Clone the repository

git clone https://github.com/bachoans/AccountManager.git

2. Update database connection string

Go to AccountManager.Server/appsettings.json and set your database connection string:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=AccountManager;Trusted_Connection=True;TrustServerCertificate=True;"
}

3. Apply migrations and seed data Open the Package Manager Console and run:

Update-Database

This will create the database and insert sample Subscriptions and Subscription Statuses.

4. Run both projects

Set both AccountManager.Client and AccountManager.Server to start.
