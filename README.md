# Challenge Rest API
The Challenge API is a open-source project written in .NET Core and Angular

The goal of this project is implement the most common used technologies with the technica community the best way to develop the Web Rest API with .NET Core

# Technologies implemented:
* ASP.NET Core 5.0 (with .NET Core 5.0)
* ASP.NET WebApi Core
* Entity Framework Core 5.0
* SQL Server
* AutoMapper
* Flunt
* FluentValidator
* MediatR
* Swagger UI
* Migrations - Core EF

# Architecture:
* Full architecture with responsibility separation concerns, SOLID and Clean Code
* Domain Driven Design (Layers and Domain Model Pattern)
* Domain Events
* Domain Notification
* Repository and Generic Repository
* Dependency Injection

# Security
Authorization tokens JWT Bearer

# How to use:
You will need the latest Visual Code and the latest .NET Core SDK. Tools can be downloaded from https://dotnet.microsoft.com/download. Also you can run the WebApi in Visual Code (Windows, Linux or MacOS).

- You must create the database named Tivia
- Example for compiling the web api project: C:\dev\NetCore5.0\Estacionamento\Estacionamento.WebApi> dotnet run
- Example for run the project web: C:\dev\NetCore5.0\Estacionamento\produto.web> yarn start

if you want to test get, post, and other methods in swagger just generate the token and click on the lock and paste the word "bearer token"

When compiling the project, open it in the browser using the https://localhost:5001/swagger/index.html link where it will display all the end points and ViewModels needed to run the API.
