USE master;

SELECT
    name AS LogicalName,
    physical_name AS PhysicalPath
FROM sys.master_files
WHERE database_id = DB_ID('5sem');





create table Licensees (
	licensee_id int primary key,
	name nvarchar(10),
	surname nvarchar(10),
	organization nvarchar(20),
	contact nvarchar(30),
	add_details nvarchar(20)
);


create table Licenses (
	license_id int primary key,
	license_name nvarchar(20),
	license_type nvarchar(20),
	date_of_issue date,
	expiration_date date,
	description nvarchar(30),
	status nvarchar(20),
	licensees_id int,
	id_of_key int,
	total_license_cost decimal(10,2),
	licensee_contact nvarchar(30),
	foreign key (licensees_id) references Licensees (licensee_id)
);


create table License_keys (
	id_of_key int primary key,
	id_of_license int,
	key_of_name nvarchar(20),
	status nvarchar(20),
             foreign key (id_of_license) references Licenses (license_id)
);




create table License_Rules (
	rule_id int primary key,
	license_id int,
	text_rules nvarchar(20),
	data_create date,
	data_change date,
             foreign key (license_id) references Licenses(license_id)
);

create table License_History (
	record_id int primary key,
	license_id int,
	action nvarchar(10),
	date_of_action date,
	username nvarchar(10),
             foreign key (license_id) references Licenses(license_id)
);




-- Добавление данных в таблицу Licensees
INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES (1, 'John', 'Doe', 'Company A', 'john.doe@example.com', 'Additional Info');

-- Добавление данных в таблицу Licenses
INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES (1, 'License 1', 'Type A', '2023-01-01', '2023-12-31', 'Description 1', 'Active', 1, 101, 500.00, 'john.doe@example.com');

-- Добавление данных в таблицу License_keys
INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES (101, 1, 'Key 101', 'Active');

-- Добавление данных в таблицу License_Rules
INSERT INTO License_Rules (rule_id, license_id, text_rules, data_create, data_change)
VALUES (1, 1, 'Rule 1', '2023-01-01', '2023-01-05');




-- Начало транзакции
BEGIN;

INSERT INTO License_History (record_id, license_id, action, date_of_action, username)
VALUES (1, 1, 'Update', '2023-01-05', 'Admin');


COMMIT;




-- Обновление данных в таблице Licensees
UPDATE Licensees SET organization = 'New Organization' WHERE licensee_id = 1;




-- Начало транзакции
BEGIN TRANSACTION;



-- Обновление данных в таблице Licenses
UPDATE Licenses SET description = 'Updated Description' WHERE license_id = 1;

-- Завершение транзакции (фиксация изменений)
COMMIT;








-- Удаление данных из таблицы License_keys
DELETE FROM License_keys WHERE id_of_key = 101;

-- Удаление данных из таблицы License_Rules
DELETE FROM License_Rules WHERE rule_id = 1;

-- Удаление данных из таблицы License_History
DELETE FROM License_History WHERE record_id = 1;

-- Удаление данных из таблицы Licenses
DELETE FROM Licenses WHERE license_id = 1;






-- Начало транзакции
BEGIN TRANSACTION;



-- Удаление данных из таблицы Licensees
DELETE FROM Licensees WHERE licensee_id = 1;

-- Завершение транзакции (фиксация изменений)
COMMIT;








-- Представление для отображения информации о лицензиях и их владельцах
CREATE VIEW IF NOT EXISTS LicenseInfo AS
SELECT
    L.license_id,
    L.license_name,
    L.license_type,
    L.date_of_issue,
    L.expiration_date,
    L.description,
    L.status,
    Le.name AS licensee_name,
    Le.surname AS licensee_surname,
    Le.organization AS licensee_organization
FROM Licenses L
INNER JOIN Licensees Le ON L.licensees_id = Le.licensee_id;

-- Представление для отображения истории действий с лицензиями
CREATE VIEW IF NOT EXISTS LicenseHistory AS
SELECT
    LH.record_id,
    LH.action,
    LH.date_of_action,
    LH.username,
    L.license_name
FROM License_History LH
INNER JOIN Licenses L ON LH.license_id = L.license_id;

-- Индекс на поле license_name в таблице Licenses
CREATE INDEX IF NOT EXISTS IX_LicenseName ON Licenses (license_name);

-- Индекс на поле licensees_id в таблице Licenses
CREATE INDEX IF NOT EXISTS IX_LicenseesID ON Licenses (licensees_id);




-- Триггер для отслеживания изменений в таблице Licenses и записи их в истории
CREATE TRIGGER IF NOT EXISTS trg_Licenses_Update
AFTER UPDATE ON Licenses
BEGIN
    INSERT INTO License_History (license_id, action, date_of_action, username)
    SELECT NEW.license_id, 'Update', CURRENT_DATE, 'Admin';
END;

-- Триггер для отслеживания удалений из таблицы Licenses и записи их в истории
CREATE TRIGGER IF NOT EXISTS trg_Licenses_Delete
AFTER DELETE ON Licenses
BEGIN
    INSERT INTO License_History (license_id, action, date_of_action, username)
    SELECT OLD.license_id, 'Delete', CURRENT_DATE, 'Admin';
END;






-- Удаление триггеров
DROP TRIGGER IF EXISTS trg_Licenses_Update;
DROP TRIGGER IF EXISTS trg_Licenses_Delete;

-- Удаление представлений
DROP VIEW IF EXISTS LicenseInfo;
DROP VIEW IF EXISTS LicenseHistory;

-- Удаление индексов
DROP INDEX IF EXISTS IX_LicenseName;
DROP INDEX IF EXISTS IX_LicenseesID;

-- Удаление таблиц
DROP TABLE IF EXISTS License_keys;
DROP TABLE IF EXISTS License_Rules;
DROP TABLE IF EXISTS License_History;
DROP TABLE IF EXISTS Licenses;
DROP TABLE IF EXISTS Licensees;


