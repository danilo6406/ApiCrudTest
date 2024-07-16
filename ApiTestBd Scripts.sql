CREATE DATABASE ApiTestDb;
GO

USE ApiTestDb;
GO

CREATE TABLE Stores (
    StoreID INT PRIMARY KEY,
    StoreName VARCHAR(50)
);
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(50)
);
GO

CREATE TABLE StoreProductMapping (
    MappingID INT PRIMARY KEY,
    StoreID INT,
    ProductID INT,
    Stock INT,
    FOREIGN KEY (StoreID) REFERENCES Stores(StoreID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO