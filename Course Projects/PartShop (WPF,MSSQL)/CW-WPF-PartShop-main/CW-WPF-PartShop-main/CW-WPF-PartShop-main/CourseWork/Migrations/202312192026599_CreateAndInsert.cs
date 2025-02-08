namespace CourseWork.Migrations
{
    using CourseWork.Services;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAndInsert : DbMigration
    {
        public override void Up()
        {
            // Создание таблицы Categories
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CategoryId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 20),
                    Description = c.String(nullable: false),
                })
                .PrimaryKey(t => t.CategoryId);

            // Создание таблицы Providers
            CreateTable(
                "dbo.Providers",
                c => new
                {
                    ProviderId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Email = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ProviderId);

            // Создание таблицы Deliveries
            CreateTable(
                "dbo.Deliveries",
                c => new
                {
                    DeliveryId = c.Int(nullable: false, identity: true),
                    Description = c.String(nullable: false),
                    Price = c.Double(nullable: false),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.DeliveryId);

            // Создание таблицы Users
            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Login = c.String(nullable: false, maxLength: 20),
                    Password = c.String(nullable: false),
                    Is_admin = c.Boolean(nullable: false),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Email = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            // Создание таблицы Orders
            CreateTable(
                "dbo.Orders",
                c => new
                {
                    OrderId = c.Int(nullable: false, identity: true),
                    OrderDate = c.DateTime(nullable: false),
                    UserId = c.Int(nullable: false),
                    DeliveryId = c.Int(nullable: false),
                    OrderState = c.String(nullable: false),
                })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Deliveries", t => t.DeliveryId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.DeliveryId);

            // Создание таблицы Cards
            CreateTable(
                "dbo.Cards",
                c => new
                {
                    CardId = c.Int(nullable: false, identity: true),
                    CardNumber = c.String(nullable: false),
                    UserId = c.Int(nullable: false),
                    CvvCode = c.Int(nullable: false),
                    Balance = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            // Создание таблицы Marks
            CreateTable(
                "dbo.Marks",
                c => new
                {
                    MarkId = c.Int(nullable: false, identity: true),
                    MarkName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.MarkId);

            // Создание таблицы Parts
            CreateTable(
                "dbo.Parts",
                c => new
                {
                    PartId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Quantity = c.Int(nullable: false),
                    ProviderId = c.Int(nullable: false),
                    Price = c.Double(nullable: false),
                    Description = c.String(nullable: false),
                    ImageLink = c.String(),
                    CategoryId = c.Int(nullable: false),
                    FullDescription = c.String(nullable: false),
                    MarkId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Providers", t => t.ProviderId, cascadeDelete: true)
                .ForeignKey("dbo.Marks", t => t.MarkId, cascadeDelete: true)
                .Index(t => t.ProviderId)
                .Index(t => t.CategoryId)
                .Index(t => t.MarkId);

            // Создание таблицы Carts
            CreateTable(
                "dbo.Carts",
                c => new
                {
                    CartId = c.Int(nullable: false, identity: true),
                    PartId = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.PartId);

            // Создание таблицы PartsInOrder
            CreateTable(
                "dbo.PartsInOrder",
                c => new
                {
                    OrderId = c.Int(nullable: false),
                    PartId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.OrderId, t.PartId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.PartId);

            // Создание таблицы OrderedParts
            CreateTable(
                "dbo.OrderedParts",
                c => new
                {
                    PartId = c.Int(nullable: false),
                    OrderId = c.Int(nullable: false),
                    Amount = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.PartId, t.OrderId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.PartId)
                .Index(t => t.OrderId);









            //insert data into Users

            string hashPassword = SecurePassService.Hash("admin1");
            Sql($"INSERT INTO dbo.Users (Login, Password, Is_admin, FirstName, LastName, Email) VALUES ('Admin', '{hashPassword}', 1, 'Arseniy', 'Palaznik', 'admin@gmail.com')");


            hashPassword = SecurePassService.Hash("vladik1");
            Sql($"INSERT INTO dbo.Users (Login, Password, Is_admin, FirstName, LastName, Email) VALUES ('MegaVladon', '{hashPassword}', 0, 'Vladislav', 'Vakulenchik', 'palaznika608@gmail.com')");
            hashPassword = SecurePassService.Hash("tani1");
            Sql($"INSERT INTO dbo.Users (Login, Password, Is_admin, FirstName, LastName, Email) VALUES ('Ryuko', '{hashPassword}', 0, 'Tatsiana', 'Shishova', 'tanya@gmail.com')");
            hashPassword = SecurePassService.Hash("lesha1");
            Sql($"INSERT INTO dbo.Users (Login, Password, Is_admin, FirstName, LastName, Email) VALUES ('Archer', '{hashPassword}', 0, 'Alexey', 'Leonets', 'lesha@gmail.com')");
            hashPassword = SecurePassService.Hash("halwaa1");
            Sql($"INSERT INTO dbo.Users (Login, Password, Is_admin, FirstName, LastName, Email) VALUES ('Halwa', '{hashPassword}', 0, 'Andrei', 'Halaleenko', 'halwa@gmail.com')");



            // Вставка данных в таблицу Categories

            Sql($"INSERT INTO Categories (Name, Description) VALUES ('Filters', 'Vehicle filtration systems')");
            Sql($"INSERT INTO Categories (Name, Description) VALUES ('Suspension and Steer', 'Suspension and steering components')");
            Sql($"INSERT INTO Categories (Name, Description) VALUES ('Braking System', 'Components related to braking system')");
            Sql($"INSERT INTO Categories (Name, Description) VALUES ('Ignition and Electr', 'Ignition and electrical components')");
            Sql($"INSERT INTO Categories (Name, Description) VALUES ('Belts and Rollers', 'Engine belts and rollers')");
            Sql($"INSERT INTO Categories (Name, Description) VALUES ('Windshield Wiper', 'Wiper system components')");
            Sql($"INSERT INTO Categories (Name, Description) VALUES ('Sensors and Electr', 'Sensors and electrical components')");
            Sql($"INSERT INTO Categories (Name, Description) VALUES ('Hydraulics and Pneum', 'Hydraulic and pneumatic components')");
            Sql($"INSERT INTO Categories (Name, Description) VALUES ('Cylinder Block Parts', 'Parts related to the engine cylinder block')");
            Sql($"INSERT INTO Categories (Name, Description) VALUES ('Fuel System', 'Components related to the fuel system')");


          



            // Вставка данных в таблицу Providers
            Sql($"INSERT INTO Providers (Name, Email) VALUES ('Bosch', 'bosch@example.com')");
            Sql($"INSERT INTO Providers (Name, Email) VALUES ('Denso', 'denso@example.com')");
            Sql($"INSERT INTO Providers (Name, Email) VALUES ('NGK', 'ngk@example.com')");
            Sql($"INSERT INTO Providers (Name, Email) VALUES ('NAPA Auto Parts', 'napa@example.com')");
            Sql($"INSERT INTO Providers (Name, Email) VALUES ('ZF Friedrichshafen AG', 'zf@example.com')");
            Sql($"INSERT INTO Providers (Name, Email) VALUES ('ACDelco', 'acdelco@example.com')");
            Sql($"INSERT INTO Providers (Name, Email) VALUES ('Magna International', 'magna@example.com')");


            // Вставка данных в таблицу Deliveries
            
            Sql($"INSERT INTO Deliveries (Description, Price, Name) VALUES ('Standard Ground Shipping', 9.99, 'Ground Shipping')");
            Sql($"INSERT INTO Deliveries (Description, Price, Name) VALUES ('Express 2-Day Shipping', 19.99, 'Express 2-Day Shipping')");
            Sql($"INSERT INTO Deliveries (Description, Price, Name) VALUES ('Overnight Shipping', 29.99, 'Overnight Shipping')");
            Sql($"INSERT INTO Deliveries (Description, Price, Name) VALUES ('Economy Shipping', 7.99, 'Economy Shipping')");
            Sql($"INSERT INTO Deliveries (Description, Price, Name) VALUES ('International Shipping', 39.99, 'International Shipping')");
            Sql($"INSERT INTO Deliveries (Description, Price, Name) VALUES ('Local Pickup', 0.00, 'Local Pickup')");
            Sql($"INSERT INTO Deliveries (Description, Price, Name) VALUES ('Free Shipping', 0.00, 'Free Shipping')");


           
           

            Sql($"INSERT INTO Cards (CardNumber, UserId, CvvCode, Balance) VALUES ('4929123456789012', 1, 499, 1500.50)");
            Sql($"INSERT INTO Cards (CardNumber, UserId, CvvCode, Balance) VALUES ('5532123456789013', 2, 192, 2200.75)");
            Sql($"INSERT INTO Cards (CardNumber, UserId, CvvCode, Balance) VALUES ('6011123456789014', 3, 505, 3100.25)");
            Sql($"INSERT INTO Cards (CardNumber, UserId, CvvCode, Balance) VALUES ('4888123456789015', 4, 291, 4200.00)");
            Sql($"INSERT INTO Cards (CardNumber, UserId, CvvCode, Balance) VALUES ('3765123456789016', 5, 229, 5200.80)");




            // Вставка данных в таблицу Marks
           

            Sql($"INSERT INTO Marks (MarkName) VALUES ('Toyota')");
            Sql($"INSERT INTO Marks (MarkName) VALUES ('Honda')");
            Sql($"INSERT INTO Marks (MarkName) VALUES ('Ford')");
            Sql($"INSERT INTO Marks (MarkName) VALUES ('Chevrolet')");
            Sql($"INSERT INTO Marks (MarkName) VALUES ('Nissan')");
            Sql($"INSERT INTO Marks (MarkName) VALUES ('BMW')");
            Sql($"INSERT INTO Marks (MarkName) VALUES ('Mercedes-Benz')");
            Sql($"INSERT INTO Marks (MarkName) VALUES ('Audi')");
            Sql($"INSERT INTO Marks (MarkName) VALUES ('Volkswagen')");
            Sql($"INSERT INTO Marks (MarkName) VALUES ('Hyundai')");





            //Вставка данных в таблицу Parts
           

            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Engine Oil', 50, 1, 29.99, 'High-quality engine oil for optimal performance', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/engineOil.jpg', 1, 'Ensures proper lubrication and protection', 1)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Brake Pads', 30, 2, 39.99, 'Durable brake pads for safe stopping power', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/brakePads.png', 3, 'Designed for consistent and reliable braking', 2)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Air Filter', 20, 3, 14.99, 'High-efficiency air filter for clean airflow', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/airFilter.jpg', 1, 'Improves engine performance and fuel efficiency', 3)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Spark Plugs', 40, 4, 7.99, 'Premium spark plugs for efficient ignition', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/sparkPlugs.jpg', 4, 'Enhances fuel combustion and engine power', 4)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Shock Absorbers', 15, 5, 89.99, 'Quality shock absorbers for smooth rides', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/shockAbsorbers.jpg', 2, 'Provides excellent vehicle stability and control', 5)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Battery', 10, 6, 79.99, 'Reliable car battery for consistent power', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/battery.jpeg', 6, 'Ensures proper starting and electrical functions', 6)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Wiper Blades', 25, 7, 12.99, 'Durable wiper blades for clear visibility', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/wiperBlades.png', 5, 'Designed for efficient windshield cleaning', 7)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Ignition Coil', 12, 1, 29.99, 'High-performance ignition coil for reliable ignition', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/ignitionCoil.jpg', 4, 'Optimizes engine combustifon and efficiency', 8)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Transmission Fluid', 18, 2, 19.99, 'Quality transmission fluid for smooth gear shifts', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/transmissionFluid.webp', 1, 'Protects against wear and extends transmission life', 9)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Radiator', 8, 3, 59.99, 'Efficient radiator for engine cooling', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/radiator.jpg', 8, 'Prevents overheating and maintains optimal temperature', 10)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Alternator', 6, 4, 69.99, 'High-output alternator for electrical power generation', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/alternator.jpg', 6, 'Ensures proper charging of the vehicle battery', 1)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Fuel Filter', 22, 5, 8.99, 'Effective fuel filter for clean fuel delivery', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/fuelFilter.jpg', 7, 'Protects the fuel system and improves engine performance', 2)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Cabin Air Filter', 14, 6, 16.99, 'Premium cabin air filter for clean and fresh air', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/cabinAirFilter.jpg', 9, 'Filters dust, pollen, and pollutants from the air', 3)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Power Steering Pump', 11, 7, 49.99, 'Durable power steering pump for smooth steering', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/powerSteeringPump.jpg', 4, 'Ensures responsive and easy steering control', 4)");
            Sql($"INSERT INTO Parts (Name, Quantity, ProviderId, Price, Description, ImageLink, CategoryId, FullDescription, MarkId) VALUES ('Oxygen Sensor', 17, 1, 29.99, 'High-quality oxygen sensor for fuel efficiency', 'D:/Study/MorningCourseProject/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CW-WPF-PartShop-main/CourseWork/Resources/Images/oxygenSensor.webp', 8, 'Monitors and adjusts fuel-to-air ratio for optimal performance', 5)");




            //// Вставка данных в таблицу Carts
            

            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (1, 3)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (4, 2)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (7, 1)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (10, 4)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (13, 2)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (2, 3)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (5, 1)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (8, 2)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (11, 3)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (14, 2)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (3, 4)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (6, 1)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (9, 3)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (12, 2)");
            Sql($"INSERT INTO Carts (PartId, Quantity) VALUES (15, 1)");




            //// Вставка данных в таблицу Orders
          
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 1, 1, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 2, 2, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 3, 3, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 4, 4, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 5, 5, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 1, 6, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 2, 7, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 3, 1, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 4, 2, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 5, 3, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 1, 4, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 2, 5, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 3, 6, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 4, 7, 'Accepted')");
            Sql($"INSERT INTO Orders (OrderDate, UserId, DeliveryId, OrderState) VALUES (GETDATE(), 5, 1, 'Accepted')");





            //// Вставка данных в таблицу PartsInOrder
           
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (1, 1)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (2, 2)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (3, 3)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (4, 4)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (5, 5)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (1, 6)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (2, 7)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (3, 8)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (4, 9)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (5, 10)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (1, 11)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (2, 12)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (3, 13)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (4, 14)");
            Sql($"INSERT INTO PartsInOrder (OrderId, PartId) VALUES (5, 15)");


            //// Вставка данных в таблицу OrderedParts
           
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (1, 1, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (2, 2, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (3, 3, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (4, 4, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (5, 5, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (6, 1, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (7, 2, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (8, 3, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (9, 4, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (10, 5, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (11, 1, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (12, 2, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (13, 3, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (14, 4, 5)");
            Sql($"INSERT INTO OrderedParts (PartId, OrderId, Amount) VALUES (15, 5, 5)");



        }

        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.Orders", "CartId", "dbo.Carts");
            DropForeignKey("dbo.Carts", "PartId", "dbo.Parts");
            DropForeignKey("dbo.Parts", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.Parts", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderedParts", "PartId", "dbo.Parts");
            DropForeignKey("dbo.OrderedParts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Parts", "MarkId", "dbo.Marks");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "DeliveryId" });
            DropIndex("dbo.Cards", new[] { "UserId" });
            DropIndex("dbo.Parts", new[] { "MarkId" });
            DropIndex("dbo.Parts", new[] { "CategoryId" });
            DropIndex("dbo.Parts", new[] { "ProviderId" });
            DropIndex("dbo.Carts", new[] { "PartId" });
            DropIndex("dbo.PartsInOrder", new[] { "PartId" });
            DropIndex("dbo.PartsInOrder", new[] { "OrderId" });
            DropIndex("dbo.OrderedParts", new[] { "OrderId" });
            DropIndex("dbo.OrderedParts", new[] { "PartId" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Cards");
            DropTable("dbo.Marks");
            DropTable("dbo.Parts");
            DropTable("dbo.Providers");
            DropTable("dbo.Categories");
            DropTable("dbo.Carts");
            DropTable("dbo.PartsInOrder");
            DropTable("dbo.OrderedParts");
        }
    }
}
