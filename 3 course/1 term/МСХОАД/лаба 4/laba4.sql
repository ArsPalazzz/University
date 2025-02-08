use dbLab1
go

truncate table Licensees

select * from Licensees
select * from Licenses
select * from License_keys
select * from License_Rules
select * from License_History


CREATE TABLE LicenseOrders (
    order_id int PRIMARY KEY,
    licensee_id int,
    license_id int,
    order_date date,
    FOREIGN KEY (licensee_id) REFERENCES Licensees (licensee_id),
    FOREIGN KEY (license_id) REFERENCES Licenses (license_id)
);


select * from Licenses

-- Licensees
INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (1, 'John', 'Doe', 'ABC Corp', 'john.doe@example.com', 'Additional details 1'),
  (2, 'Jane', 'Smith', 'XYZ Inc', 'jane.smith@example.com', 'Additional details 2'),
  (3, 'Alice', 'Johnson', '123 Ltd', 'alice.johnson@example.com', 'Additional details 3'),
  (4, 'Bob', 'Williams', '456 Corp', 'bob.williams@example.com', 'Additional details 4'),
  (5, 'Eva', 'Brown', '789 LLC', 'eva.brown@example.com', 'Additional details 5'),
  (6, 'David', 'Miller', 'CCC Ltd', 'david.miller@example.com', 'Additional details 6'),
  (7, 'Olivia', 'Jones', 'DDD Corp', 'olivia.jones@example.com', 'Additional details 7');


  ALTER TABLE Licenses
ADD  device_id int;

-- Licenses
INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact, device_id)
VALUES
  (1, 'Windows', 'Enterprise', '2023-01-01', '2024-01-01', 'OS License', 'Active', 1, 1, 100.00, 'john.doe@example.com', 1),
  (2, 'Office', 'Professional', '2023-02-01', '2024-02-01', 'Office Suite License', 'Active', 2, 2, 150.00, 'jane.smith@example.com', 2),
  (3, 'Photoshop', 'Standard', '2023-03-01', '2024-03-01', 'Graphics Software License', 'Active', 3, 3, 200.00, 'alice.johnson@example.com', 3),
  (4, 'AutoCAD', 'Professional', '2023-04-01', '2024-04-01', 'CAD Software License', 'Active', 4, 4, 250.00, 'bob.williams@example.com', 1),
  (5, 'Antivirus', 'Business', '2023-05-01', '2024-05-01', 'Security Software License', 'Active', 5, 5, 120.00, 'eva.brown@example.com', 5),
  (6, 'WebStorm', 'Developer', '2023-06-01', '2024-06-01', 'IDE License', 'Active', 6, 6, 180.00, 'david.miller@example.com', 5),
  (7, 'Illustrator', 'Standard', '2023-07-01', '2024-07-01', 'Graphics Software License', 'Active', 7, 7, 220.00, 'olivia.jones@example.com', 9);

-- License_Keys
INSERT INTO License_Keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (1, 1, 'ABCDE-12345', 'Active'),
  (2, 2, 'FGHIJ-67890', 'Active'),
  (3, 3, 'KLMNO-54321', 'Active'),
  (4, 4, 'PQRST-98765', 'Active'),
  (5, 5, 'UVWXY-13579', 'Active'),
  (6, 6, 'ZABCD-24680', 'Active'),
  (7, 7, '12345-ABCDE', 'Active');

-- License_Rules
INSERT INTO License_Rules (rule_id, license_id, text_rules, data_create, data_change)
VALUES
  (1, 1, 'Rule for Windows', '2023-01-01', '2023-01-05'),
  (2, 2, 'Rule for Office', '2023-02-01', '2023-02-05'),
  (3, 3, 'Rule for Photoshop', '2023-03-01', '2023-03-05'),
  (4, 4, 'Rule for AutoCAD', '2023-04-01', '2023-04-05'),
  (5, 5, 'Rule for Antivirus', '2023-05-01', '2023-05-05'),
  (6, 6, 'Rule for WebStorm', '2023-06-01', '2023-06-05'),
  (7, 7, 'Rule for Illustrator', '2023-07-01', '2023-07-05');

-- License_History
INSERT INTO License_History (record_id, license_id, action, date_of_action, username)
VALUES
  (1, 1, 'Activation', '2023-01-02', 'admin'),
  (2, 2, 'Renewal', '2023-02-02', 'admin'),
  (3, 3, 'Activation', '2023-03-02', 'admin'),
  (4, 4, 'Renewal', '2023-04-02', 'admin'),
  (5, 5, 'Activation', '2023-05-02', 'admin'),
  (6, 6, 'Renewal', '2023-06-02', 'admin'),
  (7, 7, 'Activation', '2023-07-02', 'admin');

-- LicenseOrders
INSERT INTO LicenseOrders (order_id, licensee_id, license_id, order_date)
VALUES
  (1, 1, 1, '2023-01-10'),
  (2, 2, 2, '2023-02-10'),
  (3, 3, 3, '2023-03-10'),
  (4, 4, 4, '2023-04-10'),
  (5, 5, 5, '2023-05-10'),
  (6, 6, 6, '2023-06-10'),
  (7, 7, 7, '2023-07-10');






----------------------------------2-----------------------------------------

select * from LicenseOrders;
--temporary named underquery expression
-- Common Table Expression (CTE) DateMetrics - разбивает даты лицензий на компоненты года, месяца, квартала и полугодия


WITH DateMetrics AS (
    SELECT
        license_id,
        total_license_cost,
        DATEPART(YEAR, date_of_issue) AS IssueYear,
        DATEPART(MONTH, date_of_issue) AS IssueMonth,
        -- Определение квартала (1, 2, 3, 4)
        CEILING(DATEPART(MONTH, date_of_issue) / 3.0) AS IssueQuarter,
        -- Определение полугодия (1, 2)
        CASE 
            WHEN DATEPART(MONTH, date_of_issue) <= 6 THEN 1
            ELSE 2
        END AS IssueHalfYear
    FROM Licenses
)

-- Основной запрос агрегирует данные о стоимости лицензий для каждого месяца, квартала, полугодия и года, для каждой лицензии.
SELECT
    license_id,
    IssueYear,
    IssueQuarter,
    IssueHalfYear,
    IssueMonth,
    SUM(total_license_cost) AS MonthlyLicenseCost
FROM DateMetrics
GROUP BY ROLLUP (license_id, IssueYear, IssueQuarter, IssueHalfYear, IssueMonth)
ORDER BY license_id, IssueYear, IssueQuarter, IssueHalfYear, IssueMonth;




CREATE PROCEDURE GetPagedLicenses2
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @StartRow INT, @EndRow INT;
    SET @StartRow = (@PageNumber - 1) * @PageSize;
    SET @EndRow = @PageNumber * @PageSize;

    WITH RankedLicenses AS (
        SELECT
            license_id,
            license_name,
            license_type,
            date_of_issue,
            expiration_date,
            description,
            status,
            licensees_id,
            id_of_key,
            total_license_cost,
            licensee_contact,
            ROW_NUMBER() OVER (ORDER BY date_of_issue) % @PageSize AS RowNum
        FROM Licenses
    )

    SELECT
        license_id,
        license_name,
        license_type,
        date_of_issue,
        expiration_date,
        description,
        status,
        licensees_id,
        id_of_key,
        total_license_cost,
        licensee_contact
    FROM RankedLicenses
    WHERE RowNum > @StartRow AND RowNum <= @EndRow
    ORDER BY date_of_issue; -- Сортировка добавлена здесь
END;

EXEC GetPagedLicenses2 @PageNumber = 1, @PageSize = 5;
























drop procedure GetPagedLicenses1


CREATE PROCEDURE GetPagedLicenses1
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @StartRow INT, @EndRow INT;
    SET @StartRow = (@PageNumber - 1) * @PageSize;
    SET @EndRow = @PageNumber * @PageSize;

    WITH RankedLicenses AS (
        SELECT
            license_id,
            license_name,
            license_type,
            date_of_issue,
            expiration_date,
            description,
            status,
            licensees_id,
            id_of_key,
            total_license_cost,
            licensee_contact,
            ROW_NUMBER() OVER (ORDER BY date_of_issue) % @PageSize AS RowNum
        FROM Licenses
    )

    SELECT
        license_id,
        license_name,
        license_type,
        date_of_issue,
        expiration_date,
        description,
        status,
        licensees_id,
        id_of_key,
        total_license_cost,
        licensee_contact
    FROM RankedLicenses
    WHERE RowNum > @StartRow AND RowNum <= @EndRow;
END;

EXEC GetPagedLicenses1 @PageNumber = 1, @PageSize = 5;



--------------------------------3-----------------------------------



WITH LicenseSummary AS (
    SELECT
        l.license_id,
        COUNT(*) AS LicenseCount,
        SUM(l.total_license_cost) AS TotalLicenseCost
    FROM Licenses l
    GROUP BY l.license_id
),

TotalLicenses AS (
    SELECT COUNT(*) AS GrandTotalLicenses FROM LicenseSummary
),

TotalLicenseCost AS (
    SELECT SUM(TotalLicenseCost) AS GrandTotalLicenseCost FROM LicenseSummary
),

MaxLicenseCount AS (
    SELECT MAX(LicenseCount) AS BestLicenseCount FROM LicenseSummary
)

SELECT
    ls.license_id,
    ls.LicenseCount,
    ls.TotalLicenseCost,
    (ls.LicenseCount * 100.0 / tl.GrandTotalLicenses) AS LicenseCountPercentageOfTotal,
    (ls.TotalLicenseCost * 100.0 / tlc.GrandTotalLicenseCost) AS TotalLicenseCostPercentageOfTotal,
    (ls.LicenseCount * 100.0 / mlc.BestLicenseCount) AS LicenseCountPercentageOfBest,
    (ls.TotalLicenseCost * 100.0 / tlc.GrandTotalLicenseCost) AS TotalLicenseCostPercentageOfBest
FROM LicenseSummary ls
CROSS JOIN TotalLicenses tl
CROSS JOIN TotalLicenseCost tlc
CROSS JOIN MaxLicenseCount mlc
ORDER BY ls.TotalLicenseCost DESC;









-----------------------4-------------------------------


WITH RankedLicenses AS (
    SELECT
        license_id,
        license_name,
        license_type,
        date_of_issue,
        expiration_date,
        description,
        status,
        licensees_id,
        id_of_key,
        total_license_cost,
        licensee_contact,
        ROW_NUMBER() OVER (ORDER BY date_of_issue) AS RowNum
    FROM Licenses
)

SELECT
    license_id,
    license_name,
    license_type,
    date_of_issue,
    expiration_date,
    description,
    status,
    licensees_id,
    id_of_key,
    total_license_cost,
    licensee_contact
FROM RankedLicenses
WHERE RowNum BETWEEN 1 AND 5; -- Выбор первых 20 строк (первая страница)










CREATE PROCEDURE GetPagedLicenses
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @StartRow INT, @EndRow INT;
    SET @StartRow = (@PageNumber - 1) * @PageSize + 1;
    SET @EndRow = @StartRow + @PageSize - 1;

    WITH RankedLicenses AS (
        SELECT
            license_id,
            license_name,
            license_type,
            date_of_issue,
            expiration_date,
            description,
            status,
            licensees_id,
            id_of_key,
            total_license_cost,
            licensee_contact,
            ROW_NUMBER() OVER (ORDER BY date_of_issue) AS RowNum
        FROM Licenses
    )

    SELECT
        license_id,
        license_name,
        license_type,
        date_of_issue,
        expiration_date,
        description,
        status,
        licensees_id,
        id_of_key,
        total_license_cost,
        licensee_contact
    FROM RankedLicenses
    WHERE RowNum BETWEEN @StartRow AND @EndRow;
END;


EXEC GetPagedLicenses @PageNumber = 1, @PageSize = 5;






select * from Licenses


-------------------------5-----------------------------

--dublicate
insert into Licenses (
	license_id,  license_name,license_type,date_of_issue,expiration_date,description,status,licensees_id,id_of_key,total_license_cost,licensee_contact) 
	values (
	8, 'Antivirus', 'fg', '2024-02-02', '2025-02-02', 'sdfsd', 'act', 5, 5, 180.00, 'hihi@mail.ru') 

WITH RankedLicenses AS (
    SELECT
        license_id,
        license_name,
        license_type,
        date_of_issue,
        expiration_date,
        description,
        status,
        licensees_id,
        id_of_key,
        total_license_cost,
        licensee_contact,
        ROW_NUMBER() OVER (PARTITION BY license_name ORDER BY license_id) AS RowNum
    FROM Licenses
)

DELETE FROM RankedLicenses
WHERE RowNum > 1;



-----------------------------------6-----------------------------


SELECT
        license_id,
		license_name,
        DATEPART(YEAR, date_of_issue) AS IssueYear,
        DATEPART(MONTH, date_of_issue) AS IssueMonth,
        SUM(total_license_cost) AS TotalCost
    FROM Licenses
    WHERE date_of_issue >= DATEADD(MONTH, -10, GETDATE())
    GROUP BY license_id, license_name, DATEPART(YEAR, date_of_issue), DATEPART(MONTH, date_of_issue)















	----------------7----------------------



	-- Создание таблицы Devices
CREATE TABLE Devices (
    device_id int PRIMARY KEY,
    device_name nvarchar(20),
    device_type nvarchar(20)
);

-- Вставка данных в таблицу Devices
INSERT INTO Devices (device_id, device_name, device_type)
VALUES
    (1, 'Desktop', 'Desktop Computer'),
    (2, 'Laptop', 'Laptop Computer'),
    (3, 'Server', 'Server'),
    (4, 'Tablet', 'Tablet'),
    (5, 'Desktop', 'Desktop Computer'),
    (6, 'Laptop', 'Laptop Computer'),
    (7, 'Server', 'Server'),
    (8, 'Desktop', 'Desktop Computer'),
    (9, 'Desktop', 'Desktop Computer'),
    (10, 'Desktop', 'Desktop Computer'),
    (11, 'Desktop', 'Desktop Computer'),
    (12, 'Laptop', 'Laptop Computer'),
    (13, 'Server', 'Server'),
    (14, 'Desktop', 'Desktop Computer'),
    (15, 'Laptop', 'Laptop Computer');
    
   

select * from Licenses

select * from Devices

-- Создание нового запроса, учитывающего device_id вместо device_type
WITH RankedSoftware AS (
    SELECT
        d.device_type,
        l.license_type,
		--Подсчитывает количество использованных лицензий для каждого типа программного обеспечения и каждого вида устройства.
        COUNT(l.license_id) AS software_count,
		--Присваивает ранг каждому типу программного обеспечения в рамках каждого вида устройства в порядке убывания количества использованных лицензий.
        RANK() OVER (PARTITION BY d.device_type ORDER BY COUNT(l.software_co) DESC) AS rnk
    FROM
        Devices d
        JOIN Licenses l ON d.device_id = l.id_of_key
    GROUP BY
        d.device_type, l.license_type
)
SELECT
    device_type,
    license_type,
    software_count
FROM
    RankedSoftware
WHERE
    rnk = 1;





------------------------------------------



truncate table Licensees;
truncate table Licenses;
truncate table License_Rules;
truncate table License_History;
truncate table License_keys;
truncate table Devices;
truncate table LicenseOrders;

drop table Licensees;
drop table Licenses;
drop table License_Rules;
drop table License_History;
drop table License_keys;
drop table Devices;
drop table LicenseOrders;
