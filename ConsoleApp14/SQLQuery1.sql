CREATE DATABASE StationeryComp
GO

USE StationeryComp
GO

CREATE TABLE Products
(
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL,
	TypeId INT NOT NULL UNIQUE,
	[Count] INT NOT NULL,
	Cost MONEY NOT NULL
);
GO

CREATE TABLE Managers
(	
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL
);
GO 

CREATE TABLE ProductTypes
(	
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL
);
GO 

CREATE TABLE Offers
(
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	BuyerName NVARCHAR(MAX) NOT NULL,
	ManagerId INT NOT NULL,
	SoldProductId INT NOT NULL,
	SoldProductCount INT NOT NULL,
	SalesProductCost MONEY NOT NULL,
	OffersDate DATE NOT NULL
);
GO

INSERT INTO Products VALUES
('Prod1', 5,6,100),
('Prod2', 1,16,120),
('Prod3', 2,4,200),
('Prod4', 4,8,50),
('Prod5', 3,17,155),
('Prod6', 6,2,1000);
GO

INSERT INTO ProductTypes VALUES
('Type1'),
('Type2'),
('Type3'),
('Type4'),
('Type5'),
('Type6');
GO

INSERT INTO Managers VALUES
('Manager1'),
('Manager2'),
('Manager3');
GO

INSERT INTO Offers VALUES
('Buyer1',1,3,4,210,'2023-12-12'),
('Buyer2',3,1,11,123,'2024-01-21'),
('Buyer3',1,5,14,160,'2024-02-11'),
('Buyer4',2,6,3,1322,'2023-12-30'),
('Buyer5',1,2,4,130,'2024-01-10'),
('Buyer6',3,1,15,120,'2024-02-14'),
('Buyer7',1,4,14,60,'2024-02-17'),
('Buyer8',2,3,3,1322,'2023-12-10');