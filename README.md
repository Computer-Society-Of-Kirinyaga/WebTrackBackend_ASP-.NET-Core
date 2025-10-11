# 🚀ASP .NET crash course with an EcommerceApi
- ASP.NET Core Web API is a modern framework by Microsoft for building lightweight, fast, and cross-platform web services. It enables various applications, such as websites, mobile apps, and desktops, to communicate with a single backend using HTTP.
- This project is a crash course that demonstrates how to build a simple e-commerce API using ASP.NET Core Web API, Entity Framework Core, JWT authentication.
 
### Why do we need Web APIs?
  #### step 1: 
  -now in our ecommerce application we want to build an web application or even a mobile application.
  -for the website we use ASP.NET MVC and ofcourse the database to store our data eg. postresql or MySQL.
  -with just this two we have our fully fuctional system doing the crud operation
 #### step 2: the business eventually grows (website + android + iosApps)
  - so we now have 3 different applications and one database
  #### step3: problems now arise
  -  Hard to Maintain: If you need to update or fix business logic, you must do so in multiple applications, which is a complex and inefficient process.
  - Each application must implement the same business logic independently. This causes Code Duplication.
  - Writing the same logic in three places increases the chances of mistakes. If a piece of logic changes, you need to update it everywhere. This will add more errors to your application
 - In short, direct database communication is messy, unsafe, and hard to scale.
  
  #### The need for WebApis
  ![Ecommerce API Diagram](https://dotnettutorials.net/wp-content/uploads/2025/09/word-image-55469-4-4.png)
  - To solve these problems, we introduce a Web API as an intermediary between the applications and the database.
  - The Web API handles all business logic and database interactions, providing a single point of communication for all applications.
  - This makes the Web API act as a mediator between the frontend and the backend.

  #### Benefits of Using Web APIs
- Any application (Website, Android, iOS, desktop app, or IoT device) can consume the API as long as it understands HTTP protocols (such as HTTP Methods, HTTP Headers, and HTTP Status codes), regardless of the underlying programming language.
     - example: A mobile app built with Flutter can easily interact with a Web API developed in ASP.NET Core.
- The business logic is written once in the Web API. Multiple clients (Website, Android, iOS, future apps) can reuse the same API endpoints
    - example: An API endpoint for processing payments can be used by both the website and mobile apps.  

### What is Web API?
- A Web API (Web Application Programming Interface) is a bridge that enables two different software applications to communicate with each other over the internet.
  ![Ecommerce API Diagram](https://dotnettutorials.net/wp-content/uploads/2025/09/word-image-55469-5-4.png)

### What is ASP.NET Core Web API?
- it is Microsoft’s modern framework for building HTTP-based services (RESTful APIs) on top of the .NET Core platform. It enables developers to create lightweight, scalable, and secure APIs that multiple types of clients can consume.

### What is Rest?
- REST (Representational State Transfer) is not a technology or a framework, but an architectural style for designing Distributed Systems.
- The beauty of REST lies in its Platform Independence:

   - The client could be written in Java, .NET, Angular, React, or any other technology.
   - The server could be built using Node.js, ASP.NET Core, PHP, Python, or Java.
   - As long as they both follow REST principles and communicate via HTTP, they can exchange data seamlessly.
- REST treats Everything as a resource: books, users, orders, products, etc. Each resource is uniquely identified by a URI (Uniform Resource Identifier), and standard HTTP methods (GET, POST, PUT, DELETE, PATCH, etc.) are used to perform operations (CRUD – Create, Read, Update, Delete) on these resources.
 #### What are the REST Principles?
 ![Ecommerce API Diagram](https://dotnettutorials.net/wp-content/uploads/2025/09/word-image-55469-7-1.png) 

### Difference Between ASP.NET Web API and ASP.NET Core Web API
 ![Ecommerce API Diagram](https://dotnettutorials.net/wp-content/uploads/2025/09/word-image-55469-8-1.png) 
---

## Status / Progress
- [ ] Project scaffolded (`dotnet new webapi`)
- [ ] Basic endpoints working
- [ ] Database configured (EF Core)
- [ ] Entities & migrations added
- [ ] Authentication (JWT) implemented
- [ ] Authorization (roles/policies) implemented
- [ ] Swagger / API docs enabled
- [ ] Tests written (unit / integration)
- [ ] Dockerized
- [ ] CI/CD pipeline configured
- [ ] Production deployment

> *Update this checklist as you complete each step.*

---

## Table of Contents
- [Overview](#overview)
- [Quick Start](#quick-start)
- [Prerequisites](#prerequisites)
- [Project Structure](#project-structure)
- [Configuration](#configuration)
- [Database & Entities](#database--entities)
- [Authentication & Authorization](#authentication--authorization)
- [DTOs, Mapping & Validation](#dtos-mapping--validation)
- [Controllers & Endpoints](#controllers--endpoints)
- [Error Handling & Logging](#error-handling--logging)
- [Testing](#testing)
- [Docker & Deployment](#docker--deployment)
- [CI / CD](#ci--cd)
- [Security Considerations](#security-considerations)
- [Contributing](#contributing)
- [Roadmap](#roadmap)
- [Changelog](#changelog)
- [Contacts](#contacts)

---

## Overview
Write a short project description:
- Purpose, scope and high-level features.
- Short architecture note (e.g. `ASP.NET Core Web API`, `EF Core`, `JWT`, `Docker`).

---

## Quick Start
Short commands to spin up the project locally.

```bash
# create the project (example)
dotnet new webapi -n MyProject.Api
cd MyProject.Api

# restore packages
dotnet restore

# run (dev)
dotnet run

# or with watching
dotnet watch run
