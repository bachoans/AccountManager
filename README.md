# AccountManager
Account Manager - Assignment Summary
This is a full-stack Blazor WebAssembly project created as part of a company assignment. It includes features for managing accounts, subscriptions, and viewing change logs.


1. Blazor WebAssembly Client
Created pages to view, create, edit, and delete accounts.

Used forms with validation to collect data.

Showed list of accounts with actions: edit, delete, toggle active, and view change logs.

Used dropdowns to select:

Subscriptions

Subscription statuses

2. ASP.NET Core API (Server)
Built REST API using minimal and controller-based endpoints.

Created API endpoints for:

Accounts

Subscriptions

Subscription statuses

Account change logs

Handled all business logic inside services and repositories.

3. Database (EF Core)
Used Entity Framework Core with SQL Server.

Created entity classes and DbContext.

Ran migrations to create database schema.

Stored data for:

Accounts

Subscriptions

Subscription statuses

Logs of changes

4. Change Log System
Logged every change in account fields like name, country, or subscription.

Showed change logs per account on a separate page.

 Project Structure
AccountManager.Client - Blazor WebAssembly client app.

AccountManager.Server - ASP.NET Core Web API.

AccountManager.Data - Entity and repository layer.

AccountManager.Shared - Shared DTOs and services.

 Technologies Used
Blazor WebAssembly (.NET 8)

ASP.NET Core Web API

Entity Framework Core

SQL Server

RESTful API

Razor Components

Bootstrap (for styling)
