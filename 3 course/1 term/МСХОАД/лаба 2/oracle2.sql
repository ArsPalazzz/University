-- Представление для отображения информации о лицензиях и их владельцах
CREATE OR REPLACE VIEW LicenseInfo AS
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
CREATE OR REPLACE VIEW LicenseHistory AS
SELECT
    LH.record_id,
    LH.action,
    LH.date_of_action,
    LH.username,
    L.license_name
FROM License_History LH
INNER JOIN Licenses L ON LH.license_id = L.license_id;

-- Индекс на поле license_name в таблице Licenses
CREATE INDEX IX_LicenseName ON Licenses (license_name);

-- Индекс на поле licensees_id в таблице Licenses
CREATE INDEX IX_LicenseesID ON Licenses (licensees_id);

-- Создание последовательности для генерации уникальных идентификаторов лицензий
CREATE SEQUENCE LicenseIDSeq
    START WITH 1
    INCREMENT BY 1;

-- Пример функции для расчета суммарной стоимости лицензии
CREATE OR REPLACE FUNCTION CalculateLicenseCost (p_license_id NUMBER) RETURN NUMBER IS
    p_cost NUMBER(10, 2);
BEGIN
    SELECT total_license_cost INTO p_cost FROM Licenses WHERE license_id = p_license_id;
    RETURN p_cost;
END CalculateLicenseCost;

-- Пример процедуры для добавления новой лицензии
CREATE OR REPLACE PROCEDURE AddLicense(
    p_name IN NVARCHAR2,
    p_type IN NVARCHAR2,
    p_issue_date IN DATE,
    p_expiration_date IN DATE,
    p_description IN NVARCHAR2,
    p_status IN NVARCHAR2,
    p_licensee_id IN NUMBER,
    p_total_cost IN NUMBER
) IS
BEGIN
    INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, total_license_cost)
    VALUES (LicenseIDSeq.NEXTVAL, p_name, p_type, p_issue_date, p_expiration_date, p_description, p_status, p_licensee_id, p_total_cost);
    COMMIT;
END AddLicense;








-- Insert data into Licensees table
INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (1, 'John', 'Doe', 'ABC Corp', 'john.doe@ex.com', 'Add Details 1');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (2, 'Jane', 'Smith', 'XYZ Inc', 'jane.smith@ex.com', 'Add Details 2');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (3, 'Bob', 'Johnson', 'LMN Ltd', 'bob.johnson@ex.com', 'Add Details 3');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (4, 'Alice', 'Williams', 'PQR Co', 'alice.williams@ex.com', 'Add Details 4');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (5, 'Charlie', 'Brown', 'EFG Inc', 'charlie.brown@ex.com', 'Add Details 5');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (6, 'Eva', 'Miller', 'HIJ Corporation', 'eva.miller@ex.com', 'Add Details 6');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (7, 'Sam', 'White', 'STU Enterprises', 'sam.white@ex.com', 'Add Details 7');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (8, 'Olivia', 'Smith', 'XYZ Inc', 'olivia.smith@ex.com', 'Add Details 8');

-- Insert data into Licenses table
INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (1, 'License 1', 'Type A', TO_DATE('2023-01-01', 'YYYY-MM-DD'), TO_DATE('2023-12-31', 'YYYY-MM-DD'), 'Description 1', 'Active', 1, 101, 100.00, 'john.doe@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (2, 'License 2', 'Type B', TO_DATE('2023-02-01', 'YYYY-MM-DD'), TO_DATE('2023-11-30', 'YYYY-MM-DD'), 'Description 2', 'Inactive', 2, 102, 150.00, 'jane.smith@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (3, 'License 3', 'Type C', TO_DATE('2023-03-01', 'YYYY-MM-DD'), TO_DATE('2023-10-31', 'YYYY-MM-DD'), 'Description 3', 'Active', 3, 103, 120.00, 'bob.johnson@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (4, 'License 4', 'Type A', TO_DATE('2023-04-01', 'YYYY-MM-DD'), TO_DATE('2023-09-30', 'YYYY-MM-DD'), 'Description 4', 'Inactive', 4, 104, 90.00, 'alice.williams@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (5, 'License 5', 'Type B', TO_DATE('2023-05-01', 'YYYY-MM-DD'), TO_DATE('2023-08-31', 'YYYY-MM-DD'), 'Description 5', 'Active', 5, 105, 130.00, 'charlie.brown@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (6, 'License 6', 'Type C', TO_DATE('2023-06-01', 'YYYY-MM-DD'), TO_DATE('2023-07-31', 'YYYY-MM-DD'), 'Description 6', 'Inactive', 6, 106, 110.00, 'eva.miller@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (7, 'License 7', 'Type A', TO_DATE('2023-07-01', 'YYYY-MM-DD'), TO_DATE('2023-06-30', 'YYYY-MM-DD'), 'Description 7', 'Active', 7, 107, 80.00, 'sam.white@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (8, 'License 8', 'Type B', TO_DATE('2023-08-01', 'YYYY-MM-DD'), TO_DATE('2023-05-31', 'YYYY-MM-DD'), 'Description 8', 'Inactive', 8, 108, 70.00, 'olivia.smith@example.com');

-- Insert data into License_keys table
INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (101, 1, 'Key 1', 'Active');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (102, 2, 'Key 2', 'Inactive');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (103, 3, 'Key 3', 'Active');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (104, 4, 'Key 4', 'Inactive');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (105, 5, 'Key 5', 'Active');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (106, 6, 'Key 6', 'Inactive');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (107, 7, 'Key 7', 'Active');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (108, 8, 'Key 8', 'Inactive');







INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (1, 'John', 'Doe', 'ABC Corp', 'john.doe@example.com', 'Details 1');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (2, 'Jane', 'Smith', 'XYZ Inc', 'jane.smith@ex.com', 'Details 2');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (3, 'Bob', 'Johnson', 'LMN Ltd', 'bob.johnson@ex.com', 'Details 3');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (4, 'Alice', 'Williams', 'PQR Co', 'alice.willia@ex.com', 'Details 4');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (5, 'Charlie', 'Brown', 'EFG Inc', 'char.brown@ex.com', 'Details 5');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (6, 'Eva', 'Miller', 'HIJ Corporation', 'eva.miller@ex.com', 'Details 6');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (7, 'Sam', 'White', 'STU Enterprises', 'sam.white@ex.com', 'Details 7');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
  (8, 'Olivia', 'Smith', 'XYZ Inc', 'olivia.smith@ex.com', 'Details 8');
  
  
  
  
  
  
  
  
  
  
  
  -- Insert data into License_keys table based on existing Licenses
INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (101, 1, 'Key 1', 'Active');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (102, 2, 'Key 2', 'Inactive');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (103, 3, 'Key 3', 'Active');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (104, 4, 'Key 4', 'Inactive');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (105, 5, 'Key 5', 'Active');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (106, 6, 'Key 6', 'Inactive');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (107, 7, 'Key 7', 'Active');

INSERT INTO License_keys (id_of_key, id_of_license, key_of_name, status)
VALUES
  (108, 8, 'Key 8', 'Inactive');

  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  select * from Licenses
  
  
  
  -- Insert data into Licenses table
INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (1, 'License 1', 'Type A', TO_DATE('2023-01-01', 'YYYY-MM-DD'), TO_DATE('2023-12-31', 'YYYY-MM-DD'), 'Description 1', 'Active', 1, 101, 100.00, 'john.doe@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (2, 'License 2', 'Type B', TO_DATE('2023-02-01', 'YYYY-MM-DD'), TO_DATE('2023-11-30', 'YYYY-MM-DD'), 'Description 2', 'Inactive', 2, 102, 150.00, 'jane.smith@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (3, 'License 3', 'Type C', TO_DATE('2023-03-01', 'YYYY-MM-DD'), TO_DATE('2023-10-31', 'YYYY-MM-DD'), 'Description 3', 'Active', 3, 103, 120.00, 'bob.johnson@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (4, 'License 4', 'Type A', TO_DATE('2023-04-01', 'YYYY-MM-DD'), TO_DATE('2023-09-30', 'YYYY-MM-DD'), 'Description 4', 'Inactive', 4, 104, 90.00, 'alice.williams@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (5, 'License 5', 'Type B', TO_DATE('2023-05-01', 'YYYY-MM-DD'), TO_DATE('2023-08-31', 'YYYY-MM-DD'), 'Description 5', 'Active', 5, 105, 130.00, 'charlie.brown@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (6, 'License 6', 'Type C', TO_DATE('2023-06-01', 'YYYY-MM-DD'), TO_DATE('2023-07-31', 'YYYY-MM-DD'), 'Description 6', 'Inactive', 6, 106, 110.00, 'eva.miller@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (7, 'License 7', 'Type A', TO_DATE('2023-07-01', 'YYYY-MM-DD'), TO_DATE('2023-06-30', 'YYYY-MM-DD'), 'Description 7', 'Active', 7, 107, 80.00, 'sam.white@example.com');

INSERT INTO Licenses (license_id, license_name, license_type, date_of_issue, expiration_date, description, status, licensees_id, id_of_key, total_license_cost, licensee_contact)
VALUES
  (8, 'License 8', 'Type B', TO_DATE('2023-08-01', 'YYYY-MM-DD'), TO_DATE('2023-05-31', 'YYYY-MM-DD'), 'Description 8', 'Inactive', 8, 108, 70.00, 'olivia.smith@example.com');
