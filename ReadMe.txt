# Agri Energy Connect Web Application

## NB: THE SQL SCRIPT IS STORED IN A CALLED SQL SCRIPT  IN THE Agri Energy Connect Web Application FOLDER - IT WILL ALSO BE DRAWN UP BELOW
## Introduction

Agri Energy Connect is a web application designed to facilitate communication and collaboration between farmers and employees of an agricultural company. This application allows farmers to manage their products and employees to view and filter product information.

## Features

### Farmer Section

1. **Add Product**: Farmers can add new products to the system, providing details such as product name, category, and production date.
2. **View Product List**: Farmers can view a list of products they have added, along with their details.

### Employee Section

1. **Filter Products**: Employees can filter products based on their category.
2. **View Product List**: Employees can view a list of products, including details such as product name, production date, and the farmer who added the product.
3. **Add Farmer**: Employees can add new farmers to the system.

## Technologies Used

- **Frontend**: ASP.NET Web Forms, HTML, CSS
- **Backend**: C#, SQL Server
- **Database**: SQL Server

## Setup Instructions

1. **Clone the Repository**: Clone this repository to your local machine using `git clone`.
2. **Database Setup**: Set up a SQL Server database and execute the provided SQL scripts to create the necessary tables (`Farmer`, `Product`).
3. **Connection String**: Update the connection string in the web application code (`Web.config`) to point to your SQL Server database.
4. **Run the Application**: Build and run the web application using Visual Studio or any other compatible IDE.

## Usage

1. **Farmers**: After logging in, farmers can add new products or view existing products in their dashboard.
2. **Employees**: After logging in, employees can filter products based on category, view product lists, and add new farmers.












## SCRIPT

CREATE DATABASE AGRI2
USE AGRI2

-- Create Farmer table
CREATE TABLE Farmer (
    FarmerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Username NVARCHAR(50) UNIQUE,
    PasswordHash NVARCHAR(255),
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(255)
);

-- Create Employee table
CREATE TABLE Employee (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Username NVARCHAR(50) UNIQUE,
    PasswordHash NVARCHAR(255)
);

-- Create Product table
CREATE TABLE Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    FarmerID INT,
    Name NVARCHAR(100),
    Category NVARCHAR(50),
    ProductionDate DATE,
    FOREIGN KEY (FarmerID) REFERENCES Farmer(FarmerID)
);



-- Populate Farmer table with sample data
INSERT INTO Farmer (FirstName, LastName, Username, PasswordHash, Email, PhoneNumber, Address) VALUES
('John', 'Doe', 'johndoe', 'kops', 'johndoe@example.com', '123-456-7890', '123 Main St, City, Country'),
('Jane', 'Smith', 'janesmith', 'kops', 'janesmith@example.com', '987-654-3210', '456 Elm St, City, Country');

-- Populate Employee table with sample data
INSERT INTO Employee (FirstName, LastName, Username, PasswordHash) VALUES
('Admin', 'Admin', 'admin', 'HASHED_PASSWORD_HERE');

-- Populate Product table with sample data
INSERT INTO Product (FarmerID, Name, Category, ProductionDate) VALUES
(1, 'Organic Tomatoes', 'Vegetables', '2024-04-01'),
(1, 'Free-range Eggs', 'Poultry', '2024-03-15'),
(2, 'Grass-fed Beef', 'Meat', '2024-02-20'),
(2, 'Organic Apples', 'Fruits', '2024-04-10');



