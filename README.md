# .NET Core REST API Server

## Table of Contents

1. [Project Description](#project-description)
2. [Features](#features)
3. [Prerequisites](#prerequisites)
4. [Installation](#installation)
5. [Running the Application](#running-the-application)
6. [API Endpoints](#api-endpoints)

## Project Description

This project is a REST API server built using .NET Core. It provides a robust and scalable backend for managing various resources and serves as a template for building API services.

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 5.0 or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other compatible database
- [Postman](https://www.postman.com/) (optional, for testing the API)

## Installation

1. **Clone the repository**
    ```bash
    git clone https://suraj_pinjan@bitbucket.org/zogato/alembicdump_server.git
    cd alembicdump_server
    git checkout dev
    ```

2. **Configure the database**
    - Update the `appsettings.json` file with your database connection string.

3. **Restore dependencies**
    ```bash
    dotnet restore
    ```

4. **Restore DB**
create DB LW_PRD in your sql server DB.
run SQLDBSCRIPT.sql file in DB.

## Running the Application

1. **Run the application**
    ```bash
    dotnet run
    ```

2. **Access the API documentation**
    - Navigate to `http://localhost:5000/swagger` in your browser to view the Swagger UI.

## API Endpoints

Here are some of the key endpoints available in this API.

- **POST /run**: Creates the sql query with the Data in the request

## Testing
Test the API and the query build functionality using POSTMAN. Restore DOTNET_SERVER.postman_collection.json file in postman.

1. **Run tests**
    ```bash
    dotnet test
    ```

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature-branch`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature-branch`)
5. Create a new Pull Request