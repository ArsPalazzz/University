create database PartShopEf;

use PartShopEf;

-- Создание таблицы Categories
CREATE TABLE Categories
(
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(20) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL
);

-- Создание таблицы Providers
CREATE TABLE Providers
(
    ProviderId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(MAX) NOT NULL
);

-- Создание таблицы Deliveries
CREATE TABLE Deliveries
(
    DeliveryId INT PRIMARY KEY IDENTITY(1,1),
    Description NVARCHAR(MAX) NOT NULL,
    Price FLOAT NOT NULL,
    Name NVARCHAR(MAX) NOT NULL
);

-- Создание таблицы Users
CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Login NVARCHAR(20) NOT NULL,
    Password NVARCHAR(MAX) NOT NULL,
    Is_admin BIT NOT NULL,
    FirstName NVARCHAR(MAX),
    LastName NVARCHAR(MAX),
    Email NVARCHAR(MAX) NOT NULL
);

-- Создание таблицы Orders
CREATE TABLE Orders
(
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    OrderDate DATETIME NOT NULL,
    UserId INT NOT NULL,
    DeliveryId INT NOT NULL,
    OrderState NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (DeliveryId) REFERENCES Deliveries(DeliveryId)
);

-- Создание таблицы Cards
CREATE TABLE Cards
(
    CardId INT PRIMARY KEY IDENTITY(1,1),
    CardNumber NVARCHAR(MAX) NOT NULL,
    UserId INT NOT NULL,
    CvvCode INT NOT NULL,
    Balance FLOAT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Создание таблицы Marks
CREATE TABLE Marks
(
    MarkId INT PRIMARY KEY IDENTITY(1,1),
    MarkName NVARCHAR(MAX) NOT NULL
);

-- Создание таблицы Parts
CREATE TABLE Parts
(
    PartId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(MAX) NOT NULL,
    Quantity INT NOT NULL,
    ProviderId INT NOT NULL,
    Price FLOAT NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    ImageLink NVARCHAR(MAX),
    CategoryId INT NOT NULL,
    FullDescription NVARCHAR(MAX) NOT NULL,
    MarkId INT NOT NULL,
    FOREIGN KEY (ProviderId) REFERENCES Providers(ProviderId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId),
    FOREIGN KEY (MarkId) REFERENCES Marks(MarkId)
);

-- Создание таблицы Carts
CREATE TABLE Carts
(
    CartId INT PRIMARY KEY IDENTITY(1,1),
    PartId INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (PartId) REFERENCES Parts(PartId)
);

-- Создание таблицы PartsInOrder
CREATE TABLE PartsInOrder
(
    OrderId INT NOT NULL,
    PartId INT NOT NULL,
    PRIMARY KEY (OrderId, PartId),
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (PartId) REFERENCES Parts(PartId)
);

-- Создание таблицы OrderedParts
CREATE TABLE OrderedParts
(
    PartId INT NOT NULL,
    OrderId INT NOT NULL,
    Amount INT NOT NULL,
    PRIMARY KEY (PartId, OrderId),
    FOREIGN KEY (PartId) REFERENCES Parts(PartId),
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
);









-- Хэширование паролей
DECLARE @hashPasswordAdmin NVARCHAR(256);
DECLARE @hashPasswordVladik NVARCHAR(256);
DECLARE @hashPasswordTani NVARCHAR(256);
DECLARE @hashPasswordLesha NVARCHAR(256);
DECLARE @hashPasswordHalwa NVARCHAR(256);

SET @hashPasswordAdmin = HASHBYTES('SHA2_256', 'admin1');
SET @hashPasswordVladik = HASHBYTES('SHA2_256', 'vladik1');
SET @hashPasswordTani = HASHBYTES('SHA2_256', 'tani1');
SET @hashPasswordLesha = HASHBYTES('SHA2_256', 'lesha1');
SET @hashPasswordHalwa = HASHBYTES('SHA2_256', 'halwaa1');

-- Вставка пользователей с хэшированными паролями
INSERT INTO dbo.Users (Login, Password, Is_admin, FirstName, LastName, Email)
VALUES ('Admin', @hashPasswordAdmin, 1, 'Arseniy', 'Palaznik', 'admin@gmail.com');

INSERT INTO dbo.Users (Login, Password, Is_admin, FirstName, LastName, Email)
VALUES ('MegaVladon', @hashPasswordVladik, 0, 'Vladislav', 'Vakulenchik', 'palaznika608@gmail.com');

INSERT INTO dbo.Users (Login, Password, Is_admin, FirstName, LastName, Email)
VALUES ('Ryuko', @hashPasswordTani, 0, 'Tatsiana', 'Shishova', 'tanya@gmail.com');

INSERT INTO dbo.Users (Login, Password, Is_admin, FirstName, LastName, Email)
VALUES ('Archer', @hashPasswordLesha, 0, 'Alexey', 'Leonets', 'lesha@gmail.com');

INSERT INTO dbo.Users (Login, Password, Is_admin, FirstName, LastName, Email)
VALUES ('Halwa', @hashPasswordHalwa, 0, 'Andrei', 'Halaleenko', 'halwa@gmail.com');








-- Вставка данных в таблицу Categories
INSERT INTO Categories (Name, Description) VALUES ('Filters', 'Vehicle filtration systems');
INSERT INTO Categories (Name, Description) VALUES ('Suspension and Steer', 'Suspension and steering components');
INSERT INTO Categories (Name, Description) VALUES ('Braking System', 'Components related to braking system');
INSERT INTO Categories (Name, Description) VALUES ('Ignition and Electr', 'Ignition and electrical components');
INSERT INTO Categories (Name, Description) VALUES ('Belts and Rollers', 'Engine belts and rollers');
INSERT INTO Categories (Name, Description) VALUES ('Windshield Wiper', 'Wiper system components');
INSERT INTO Categories (Name, Description) VALUES ('Sensors and Electr', 'Sensors and electrical components');
INSERT INTO Categories (Name, Description) VALUES ('Hydraulics and Pneum', 'Hydraulic and pneumatic components');
INSERT INTO Categories (Name, Description) VALUES ('Cylinder Block Parts', 'Parts related to the engine cylinder block');
INSERT INTO Categories (Name, Description) VALUES ('Fuel System', 'Components related to the fuel system');

-- Вставка данных в таблицу Providers
INSERT INTO Providers (Name, Email) VALUES ('Bosch', 'bosch@example.com');
INSERT INTO Providers (Name, Email) VALUES ('Denso', 'denso@example.com');
INSERT INTO Providers (Name, Email) VALUES ('NGK', 'ngk@example.com');
INSERT INTO Providers (Name, Email) VALUES ('NAPA Auto Parts', 'napa@example.com');
INSERT INTO Providers (Name, Email) VALUES ('ZF Friedrichshafen AG', 'zf@example.com');
INSERT INTO Providers (Name, Email) VALUES ('ACDelco', 'acdelco@example.com');
INSERT INTO Providers (Name, Email) VALUES ('Magna International', 'magna@example.com');

-- Вставка данных в таблицу Deliveries
INSERT INTO Deliveries (Description, Price, Name) VALUES ('Standard Ground Shipping', 9.99, 'Ground Shipping');
INSERT INTO Deliveries (Description, Price, Name) VALUES ('Express 2-Day Shipping', 19.99, 'Express 2-Day Shipping');
INSERT INTO Deliveries (Description, Price, Name) VALUES ('Overnight Shipping', 29.99, 'Overnight Shipping');
INSERT INTO Deliveries (Description, Price, Name) VALUES ('Economy Shipping', 7.99, 'Economy Shipping');
INSERT INTO Deliveries (Description, Price, Name) VALUES ('International Shipping', 39.99, 'International Shipping');
INSERT INTO Deliveries (Description, Price, Name) VALUES ('Local Pickup', 0.00, 'Local Pickup');
INSERT INTO Deliveries (Description, Price, Name) VALUES ('Free Shipping', 0.00, 'Free Shipping');




-- Вставка данных в таблицу Cards
INSERT INTO Cards (CardNumber, UserId, CvvCode, Balance) VALUES ('4929123456789012', 1, 499, 1500.50);
INSERT INTO Cards (CardNumber, UserId, CvvCode, Balance) VALUES ('5532123456789013', 2, 192, 2200.75);
INSERT INTO Cards (CardNumber, UserId, CvvCode, Balance) VALUES ('6011123456789014', 3, 505, 3100.25);
INSERT INTO Cards (CardNumber, UserId, CvvCode, Balance) VALUES ('4888123456789015', 4, 291, 4200.00);
INSERT INTO Cards (CardNumber, UserId, CvvCode, Balance) VALUES ('3765123456789016', 5, 229, 5200.80);

-- Вставка данных в таблицу Marks
INSERT INTO Marks (MarkName) VALUES ('Toyota');
INSERT INTO Marks (MarkName) VALUES ('Honda');
INSERT INTO Marks (MarkName) VALUES ('Ford');
INSERT INTO Marks (MarkName) VALUES ('Chevrolet');
INSERT INTO Marks (MarkName) VALUES ('Nissan');
INSERT INTO Marks (MarkName) VALUES ('BMW');
INSERT INTO Marks (MarkName) VALUES ('Mercedes-Benz');
INSERT INTO Marks (MarkName) VALUES ('Audi');
INSERT INTO Marks (MarkName) VALUES ('Volkswagen');
INSERT INTO Marks (MarkName) VALUES ('Hyundai');

-- Вставка данных в таблицу Parts
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Engine Oil', 50, 1, 29.99, 'High-quality engine oil for optimal performance', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/engineOil.jpg', 1, 'Ensures proper lubrication and protection', 1);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Brake Pads', 30, 2, 39.99, 'Durable brake pads for safe stopping power', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/brakePads.png', 3, 'Designed for consistent and reliable braking', 2);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Air Filter', 20, 3, 14.99, 'High-efficiency air filter for clean airflow', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/airFilter.jpg', 1, 'Improves engine performance and fuel efficiency', 3);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Spark Plugs', 40, 4, 7.99, 'Premium spark plugs for efficient ignition', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/sparkPlugs.jpg', 4, 'Enhances fuel combustion and engine power', 4);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Shock Absorbers', 15, 5, 89.99, 'Quality shock absorbers for smooth rides', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/shockAbsorbers.jpg', 2, 'Provides excellent vehicle stability and control', 5);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Battery', 10, 6, 79.99, 'Reliable car battery for consistent power', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/battery.jpeg', 6, 'Ensures proper starting and electrical functions', 6);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Wiper Blades', 25, 7, 12.99, 'Durable wiper blades for clear visibility', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/wiperBlades.png', 5, 'Designed for efficient windshield cleaning', 7);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Ignition Coil', 12, 1, 29.99, 'High-performance ignition coil for reliable ignition', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/ignitionCoil.jpg', 4, 'Optimizes engine combustion and efficiency', 8);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Transmission Fluid', 18, 2, 19.99, 'Quality transmission fluid for smooth gear shifts', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/transmissionFluid.webp', 1, 'Protects against wear and extends transmission life', 9);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Radiator', 8, 3, 59.99, 'Efficient radiator for engine cooling', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/radiator.jpg', 8, 'Prevents overheating and maintains optimal temperature', 10);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Alternator', 6, 4, 69.99, 'High-output alternator for electrical power generation', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/alternator.jpg', 6, 'Ensures proper charging of the vehicle battery', 1);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Fuel Filter', 22, 5, 8.99, 'Effective fuel filter for clean fuel delivery', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/fuelFilter.jpg', 7, 'Protects the fuel system and improves engine performance', 2);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Cabin Air Filter', 14, 6, 16.99, 'Premium cabin air filter for clean and fresh air', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/cabinAirFilter.jpg', 9, 'Filters dust, pollen, and pollutants from the air', 3);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Power Steering Pump', 11, 7, 49.99, 'Durable power steering pump for smooth steering', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/powerSteeringPump.jpg', 4, 'Ensures responsive and easy steering control', 4);
INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Oxygen Sensor', 17, 1, 29.99, 'High-quality oxygen sensor for fuel efficiency', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/oxygenSensor.webp', 8, 'Monitors and adjusts fuel-to-air ratio for optimal performance', 5);



-- Вставка данных в таблицу Carts
INSERT INTO Carts (PartId, Quantity) VALUES (1, 3);
INSERT INTO Carts (PartId, Quantity) VALUES (4, 2);
INSERT INTO Carts (PartId, Quantity) VALUES (7, 1);
INSERT INTO Carts (PartId, Quantity) VALUES (10, 4);
INSERT INTO Carts (PartId, Quantity) VALUES (13, 2);
INSERT INTO Carts (PartId, Quantity) VALUES (2, 3);
INSERT INTO Carts (PartId, Quantity) VALUES (5, 1);
INSERT INTO Carts (PartId, Quantity) VALUES (8, 2);
INSERT INTO Carts (PartId, Quantity) VALUES (11, 3);
INSERT INTO Carts (PartId, Quantity) VALUES (14, 2);
INSERT INTO Carts (PartId, Quantity) VALUES (3, 4);
INSERT INTO Carts (PartId, Quantity) VALUES (6, 1);
INSERT INTO Carts (PartId, Quantity) VALUES (9, 3);
INSERT INTO Carts (PartId, Quantity) VALUES (12, 2);
INSERT INTO Carts (PartId, Quantity) VALUES (15, 1);

-- Вставка данных в таблицу Orders
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 1, 1, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 2, 2, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 3, 3, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 4, 4, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 5, 5, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 1, 6, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 2, 7, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 3, 1, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 4, 2, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 5, 3, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 1, 4, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 2, 5, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 3, 6, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 4, 7, 'Accepted');
INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 5, 1, 'Accepted');

-- Вставка данных в таблицу PartsInOrder
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (1, 1);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (2, 2);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (3, 3);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (4, 4);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (5, 5);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (1, 6);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (2, 7);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (3, 8);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (4, 9);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (5, 10);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (1, 11);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (2, 12);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (3, 13);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (4, 14);
INSERT INTO PartsInOrder (OrderId, PartId) VALUES (5, 15);

-- Вставка данных в таблицу OrderedParts
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (1, 1, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (2, 2, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (3, 3, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (4, 4, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (5, 5, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (6, 1, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (7, 2, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (8, 3, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (9, 4, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (10, 5, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (11, 1, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (12, 2, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (13, 3, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (14, 4, 5);
INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (15, 5, 5);
