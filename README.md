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

### HTTP (HyperText Transport Protocol)
 - HTTP is the foundation of data communication on the web. It is a protocol that defines how messages are formatted and transmitted between clients (like web browsers or mobile apps) and servers (where websites and APIs are hosted).
 - Example: If a webpage fails to load and displays a “404 Not Found” error, a developer who understands HTTP knows that the server cannot locate the requested resource. This makes it easier to fix the broken link or update the resource path.
  #### How Client and Server Communicate Using HTTP?
  ![Ecommerce API Diagram](https://dotnettutorials.net/wp-content/uploads/2025/09/word-image-55469-1-6-768x454.png)
  - Example
You open a shopping app on your phone and view a product.

Your mobile app sends an HTTP Request to the server asking for product details.
The server replies with an HTTP Response containing the product name, price, and images.
The app then displays this information to you.
  #### Key Components of an HTTP Request
 An HTTP Request is the message sent by the client to the server asking for a resource or action. It consists of a request line, headers, an optional body, and sometimes query parameters in the URL 
 - Request Line: the first line of an HTTP request and specifies to the server the exact action the client wants to perform. It includes three main components: the HTTP method, the request URL, and the HTTP version.
   - Example: `GET /products/123 HTTP/1.1`
     - `GET`: The HTTP method indicating that the client wants to retrieve data.
     - `/products/123`: The request URL specifying the resource being requested (in this case, product with ID 123).
     - `HTTP/1.1`: The version of the HTTP protocol being used.
 - HTTP Methods: These are verbs that indicate the desired action to be performed on the resource. Common HTTP methods include:
   - `GET`: Retrieve data from the server (e.g., get a list of products).
   - `POST`: Send data to the server to create a new resource (e.g., add a new product).
   - `PUT`: Update an existing resource on the server (e.g., update product details).
   - `DELETE`: Remove a resource from the server (e.g., delete a product).
   - `PATCH`: Partially update an existing resource (e.g., update product price).
 - Request Headers: After the request line, the client usually sends one or more headers. These headers serve as additional instructions, providing more detailed descriptions of the request. Common headers include:
   - `Content-Type`: Specifies the format of the data being sent in the request body (e.g., `application/json` for JSON data).
   - `Authorization`: Contains credentials (like tokens) to authenticate the client with the server.
   - `Accept`: Indicates the types of responses the client can handle (e.g., `application/json`).
 - Request Body: Some HTTP requests (like `POST` and `PUT`) include a body that contains data being sent to the server. This body can be in various formats, such as JSON, XML, or form data. For example, when creating a new product, the request body might contain the product name, price, and description in JSON format.
 - Query Parameters: These are optional key-value pairs appended to the URL after a question mark (`?`)which are part of the URL itself. They provide additional information to the server about the request. For example, in the URL `/products?category=electronics&sort=price_asc`, `category` and `sort` are query parameters that filter and sort the products.
### Key Components of an HTTP Response 
An HTTP response is the message sent from the Server back to the Client after processing a request. The response informs the client whether the request was successful or not and may also include the requested content or an error message. It consists of a status line, headers, and an optional body.
 - Status Line: The first line of an HTTP response is the status line, which provides three key pieces of information: the HTTP version, a status code, and a reason phrase. For example: `HTTP/1.1 200 OK`
   - `HTTP/1.1`: Indicates the version of the HTTP protocol being used.
   - `200`: The status code indicating the result of the request (in this case, 200 means success).
   - `OK`: A brief description of the status code (in this case, "OK" means the request was successful).
 - Status Codes: These are three-digit numbers that indicate the outcome of the request. They are grouped into five categories:
   - `1xx (Informational)`: Request received, continuing process (e.g., 100 Continue).
   - `2xx (Success)`: The request was successfully received, understood, and accepted (e.g., 200 OK, 201 Created).
   - `3xx (Redirection)`: Further action needs to be taken to complete the request (e.g., 301 Moved Permanently, 302 Found).
   - `4xx (Client Error)`: The request contains bad syntax or cannot be fulfilled (e.g., 400 Bad Request, 401 Unauthorized, 404 Not Found).
   - `5xx (Server Error)`: The server failed to fulfill a valid request (e.g., 500 Internal Server Error, 503 Service Unavailable).
 - Response Headers: Following the status line, the server sends one or more headers that provide additional information about the response. Common headers include:
   - `Content-Type`: Specifies the format of the data being sent in the response body (e.g., `application/json` for JSON data).
   - `Content-Length`: Indicates the size of the response body in bytes.
   - `Set-Cookie`: Used to send cookies from the server to the client for session management.
 - Response Body: The response body contains the actual data being sent back to the client. This can be in various formats such as JSON, XML, HTML, or plain text. For example, when a client requests product details, the response body might contain a JSON object with product information like name, price, and description.~
---

### Creating ASP.NET Core Web API Project
1. **Install .NET SDK**: Ensure you have the .NET SDK installed on your machine. You can download it from the official [.NET website](https://dotnet.microsoft.com/download).
2. **checkout the list of available templates**: Open a terminal or command prompt and run the following command to see the list of available project templates:
   ```bash
   dotnet new --list
   ```
3. **Create a New Project**: Open a terminal or command prompt and run the following command to create a new ASP.NET Core Web API project:
   ```bash
   dotnet new webapi -n EcommerceApi
   cd EcommerceApi
   ```
4. **Build  the Project**: To build  the project, use the following commands:
   ```bash
   dotnet build
   ```
     ![Ecommerce API Diagram](https://dotnettutorials.net/wp-content/uploads/2021/04/word-image-14715-13.png)
5. **Run the Project**: To run the project, use the following command:
   ```bash
    dotnet run
    ```
    ![Ecommerce API Diagram](https://dotnettutorials.net/wp-content/uploads/2021/04/word-image-14715-17.png)

6. **Test the API using the .http file**: Create a `.http` file in the project root to test your API endpoints. For example:
    ```http
    ### Get all products
    GET https://localhost:5001/api/products
    Accept: application/json
  
    ### Get a product by ID
    GET https://localhost:5001/api/products/1
    Accept: application/json
  
    ### Create a new product
    POST https://localhost:5001/api/products
    Content-Type: application/json
  
    {
        "name": "New Product",
        "price": 19.99,
        "description": "A description of the new product"
    }
  
    ### Update a product
    PUT https://localhost:5001/api/products/1
    Content-Type: application/json
  
    {
        "name": "Updated Product",
        "price": 29.99,
        "description": "An updated description of the product"
    }
  
    ### Delete a product
    DELETE https://localhost:5001/api/products/1
    ```
### Default ASP.NET Core Web API Project Structure in Visual Studio code


## Status / Progress
- [x] Project scaffolded (`dotnet new webapi`)
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
