drop type LicenseeType;



-- Создание объектного типа данных для лицензиатов
CREATE TYPE LicenseeType2 AS OBJECT (
    licensee_id INT,
    name NVARCHAR2(10),
    surname NVARCHAR2(10),
    organization NVARCHAR2(20),
    contact NVARCHAR2(30),
    add_details NVARCHAR2(20),
    
    -- Конструктор объектного типа
    CONSTRUCTOR FUNCTION LicenseeType2(
        p_licensee_id INT,
        p_name NVARCHAR2,
        p_surname NVARCHAR2,
        p_organization NVARCHAR2,
        p_contact NVARCHAR2,
        p_add_details NVARCHAR2
    ) RETURN SELF AS RESULT,
    
    -- Метод сравнения типа MAP
    MEMBER FUNCTION compare(licensee2 IN LicenseeType2) RETURN NUMBER,
    
    
     -- Метод сравнения для сортировки
    ORDER MEMBER FUNCTION compareForOrder(licensee2 IN LicenseeType2) RETURN NUMBER,
    
    -- Метод экземпляра-функция
    MEMBER FUNCTION GetLicenseeInfo RETURN NVARCHAR2,
    
    -- Метод экземпляра-процедура
    MEMBER PROCEDURE PrintLicenseeInfo
);

-- Создание тела объектного типа данных для лицензиатов
CREATE TYPE BODY LicenseeType2 AS
    -- Реализация конструктора
    CONSTRUCTOR FUNCTION LicenseeType2(
        p_licensee_id INT,
        p_name NVARCHAR2,
        p_surname NVARCHAR2,
        p_organization NVARCHAR2,
        p_contact NVARCHAR2,
        p_add_details NVARCHAR2
    ) RETURN SELF AS RESULT IS
    BEGIN
        SELF.licensee_id := p_licensee_id;
        SELF.name := p_name;
        SELF.surname := p_surname;
        SELF.organization := p_organization;
        SELF.contact := p_contact;
        SELF.add_details := p_add_details;
        RETURN;
    END;
    
    
     -- Метод сравнения для сортировки
    ORDER MEMBER FUNCTION compareForOrder(licensee2 IN LicenseeType2) RETURN NUMBER IS
    BEGIN
        -- Реализация сравнения для сортировки (например, по имени)
        RETURN DBMS_LOB.COMPARE(DBMS_LOB.SUBSTR(self.name, 100), DBMS_LOB.SUBSTR(licensee2.name, 100));
    END;
    
    -- Метод сравнения типа MAP
    MEMBER FUNCTION compare(licensee2 IN LicenseeType2) RETURN NUMBER IS
    BEGIN
        -- Ваша реализация сравнения двух объектов LicenseeType
        IF self.licensee_id = licensee2.licensee_id THEN
            RETURN 0; -- Объекты равны
        ELSE
            RETURN 1; -- Объекты разные
        END IF;
    END;

    -- Реализация метода экземпляра-функции
    MEMBER FUNCTION GetLicenseeInfo RETURN NVARCHAR2 IS
    BEGIN
        RETURN 'Licensee Info: ' || self.name || ' ' || self.surname || ', Organization: ' || self.organization;
    END;

    -- Реализация метода экземпляра-процедуры
    MEMBER PROCEDURE PrintLicenseeInfo IS
    BEGIN
        DBMS_OUTPUT.PUT_LINE('Licensee Info: ' || self.name || ' ' || self.surname || ', Organization: ' || self.organization);
    END;
END;







drop type UsagePlaceType




-- Создание объектного типа данных для мест использования
CREATE TYPE UsagePlaceType2 AS OBJECT (
    usage_place_id INT,
    licensee_id INT,
    place_name NVARCHAR2(50),
    location NVARCHAR2(50),
    description NVARCHAR2(100),
    
    -- Конструктор объектного типа
    CONSTRUCTOR FUNCTION UsagePlaceType2(
        p_usage_place_id INT,
        p_licensee_id INT,
        p_place_name NVARCHAR2,
        p_location NVARCHAR2,
        p_description NVARCHAR2
    ) RETURN SELF AS RESULT,
    
    -- Метод сравнения типа MAP
    MEMBER FUNCTION compare(usagePlace2 IN UsagePlaceType2) RETURN NUMBER,
    
    
     -- Метод сравнения для сортировки
    ORDER MEMBER FUNCTION compareForOrder(usagePlace2 IN UsagePlaceType2) RETURN NUMBER,
    
    -- Метод экземпляра-функция
    MEMBER FUNCTION GetUsagePlaceInfo RETURN NVARCHAR2,
    
    -- Метод экземпляра-процедура
    MEMBER PROCEDURE PrintUsagePlaceInfo
);



SELECT * FROM USER_DEPENDENCIES WHERE REFERENCED_NAME = 'UsagePlaceType';









drop type UsagePlaceType;
-- Создание объектного типа данных для мест использования
-- Создание объектного типа данных для мест использования
-- Создание тела объектного типа данных для мест использования
CREATE TYPE BODY UsagePlaceType2 AS
    -- Реализация конструктора
    CONSTRUCTOR FUNCTION UsagePlaceType(
        p_usage_place_id INT,
        p_licensee_id INT,
        p_place_name NVARCHAR2,
        p_location NVARCHAR2,
        p_description NVARCHAR2
    ) RETURN SELF AS RESULT IS
    BEGIN
        SELF.usage_place_id := p_usage_place_id;
        SELF.licensee_id := p_licensee_id;
        SELF.place_name := p_place_name;
        SELF.location := p_location;
        SELF.description := p_description;
        RETURN;
    END;

    -- Метод сравнения типа MAP
    MEMBER FUNCTION compare(usagePlace2 IN UsagePlaceType) RETURN NUMBER IS
    BEGIN
        -- Ваша реализация сравнения двух объектов UsagePlaceType
        IF self.usage_place_id = usagePlace2.usage_place_id THEN
            RETURN 0; -- Объекты равны
        ELSE
            RETURN 1; -- Объекты разные
        END IF;
    END;
    
    
     -- Метод сравнения для сортировки
    ORDER MEMBER FUNCTION compareForOrder(usagePlace2 IN UsagePlaceType) RETURN NUMBER IS
    BEGIN
        -- Реализация сравнения для сортировки (например, по месту использования)
        RETURN DBMS_LOB.COMPARE(DBMS_LOB.SUBSTR(self.place_name, 100), DBMS_LOB.SUBSTR(usagePlace2.place_name, 100));
    END;

    -- Реализация метода экземпляра-функции
    MEMBER FUNCTION GetUsagePlaceInfo RETURN NVARCHAR2 IS
    BEGIN
        RETURN 'Usage Place Info: ' || self.place_name || ', Location: ' || self.location;
    END;

    -- Реализация метода экземпляра-процедуры
    MEMBER PROCEDURE PrintUsagePlaceInfo IS
    BEGIN
        DBMS_OUTPUT.PUT_LINE('Usage Place Info: ' || self.place_name || ', Location: ' || self.location);
    END;
END;








-- Пример использования объекта
DECLARE
    licensee1 LicenseeType2 := LicenseeType2(1, 'John', 'Doe', 'ABC Corp', 'john@example.com', 'Additional Details 1');
    licensee2 LicenseeType2 := LicenseeType2(2, 'Jane', 'Smith', 'XYZ Ltd', 'jane@example.com', 'Additional Details 2');
BEGIN
    -- Вызов метода сравнения
    DBMS_OUTPUT.PUT_LINE('Comparison Result: ' || licensee1.compare(licensee2));

    -- Вызов метода экземпляра-функции
    DBMS_OUTPUT.PUT_LINE('Licensee Info: ' || licensee1.GetLicenseeInfo);

    -- Вызов метода экземпляра-процедуры
    licensee1.PrintLicenseeInfo;
END;




-- Пример использования объекта
DECLARE
    place1 UsagePlaceType2 := UsagePlaceType2(1, 301, 'Place1', 'Location1', 'Description1');
    place2 UsagePlaceType2 := UsagePlaceType2(2, 302, 'Place2', 'Location2', 'Description2');
BEGIN
    -- Вызов метода сравнения
    DBMS_OUTPUT.PUT_LINE('Comparison Result: ' || place1.compare(place2));

    -- Вызов метода экземпляра-функции
    DBMS_OUTPUT.PUT_LINE('Usage Place Info: ' || place1.GetUsagePlaceInfo);

    -- Вызов метода экземпляра-процедуры
    place1.PrintUsagePlaceInfo;
END;




------------------------------3

select * from Licensees


DECLARE
    licensee_obj LicenseeType2; -- Инициализируем объект типа LicenseeType
BEGIN
    FOR licensee_rec IN (SELECT licensee_id, name, surname, organization, contact, add_details FROM Licensees) 
    LOOP
        -- Присваиваем значения полей объекта из записи курсора
        licensee_obj := LicenseeType(
            p_licensee_id => licensee_rec.licensee_id,
            p_name        => licensee_rec.name,
            p_surname     => licensee_rec.surname,
            p_organization => licensee_rec.organization,
            p_contact     => licensee_rec.contact,
            p_add_details => licensee_rec.add_details
        );

        -- Здесь можно выполнять дополнительные операции с объектом, если это необходимо
        -- Например, вывод информации о лицензии
        DBMS_OUTPUT.PUT_LINE('Licensee Info: ' || licensee_obj.GetLicenseeInfo);

        -- Далее, вы можете использовать объект licensee_obj по вашему усмотрению
    END LOOP;
END;


select * from UsagePlacesTable

DECLARE
    place_obj UsagePlaceType2; -- Инициализируем объект типа UsagePlaceType
BEGIN
    FOR place_rec IN (SELECT usage_place_id, licensee_id, place_name, location, description FROM UsagePlacesTable) 
    LOOP
        -- Присваиваем значения полей объекта из записи курсора
         place_obj := UsagePlaceType(
            p_usage_place_id => place_rec.usage_place_id,
            p_licensee_id    => place_rec.licensee_id,
            p_place_name     => place_rec.place_name,
            p_location       => place_rec.location,
            p_description    => place_rec.description
        );

        -- Здесь можно выполнять дополнительные операции с объектом, если это необходимо
        -- Например, вывод информации о месте использования
        DBMS_OUTPUT.PUT_LINE('Place Info: ' || place_obj.GetUsagePlaceInfo);

        -- Далее, вы можете использовать объект place_obj по вашему усмотрению
    END LOOP;
END;









-----------------------------4


drop view Licensees_View
CREATE OR REPLACE VIEW Licensees_View AS
SELECT
    LicenseeType(licensee_id, name, surname, organization, contact, add_details) AS licensee_obj
FROM Licensees;


drop view UsagePlace_View

 CREATE OR REPLACE VIEW UsagePlace_View AS
SELECT
    UsagePlaceType(usage_place_id, licensee_id, place_name, location, description) AS usagePlace_obj
FROM UsagePlacesTable;

SELECT usagePlace_obj.GetUsagePlaceInfo AS usage_place_info
FROM UsagePlace_View;

SELECT licensee_obj.GetLicenseeInfo AS licensee_info
FROM Licensees_View;


----------------------------------5



-- Создание таблицы с объектным типом данных
CREATE TABLE Licensee_Table OF LicenseeType;

INSERT INTO Licensee_Table
SELECT LicenseeType(licensee_id, name, surname, organization, contact, add_details)
FROM Licensees;

select * from Licensee_Table;

-- Создание индекса на атрибут Item_Price
CREATE INDEX idx_Licensees_Price ON Licensee_Table (name);

-- Пример запроса с использованием индекса на атрибут
SELECT * FROM Licensee_Table WHERE name like 'J%';

  ----UsagePlace----
  
-- Создание объектной таблицы
CREATE TABLE UsagePlace_Table OF UsagePlaceType;



-- Вставка данных в объектную таблицу из соответствующей таблицы
INSERT INTO UsagePlace_Table
SELECT UsagePlaceType(usage_place_id, licensee_id, place_name, location, description)
FROM UsagePlacesTable;

-- Вывод данных из объектной таблицы
SELECT * FROM UsagePlace_Table;

-- Создание индекса на атрибут Location
CREATE INDEX idx_Location ON UsagePlacesTable (Location);

-- Пример запроса с использованием индекса на атрибут Location
SELECT * FROM UsagePlacesTable WHERE Location like 'Tech%';









-- Создаем таблицу для примера
CREATE TABLE LicenseeTable2 AS
SELECT 1 AS licensee_id, 'John' AS name, 'Doe' AS surname, 'ABC Corp' AS organization, 'john.doe@example.com' AS contact, 'Additional Info' AS add_details FROM DUAL
UNION ALL
SELECT 2 AS licensee_id, 'Alice' AS name, 'Smith' AS surname, 'XYZ Ltd' AS organization, 'alice.smith@example.com' AS contact, 'Details' AS add_details FROM DUAL
UNION ALL
SELECT 3 AS licensee_id, 'Bob' AS name, 'Johnson' AS surname, '123 Inc' AS organization, 'bob.johnson@example.com' AS contact, 'More Info' AS add_details FROM DUAL;

-- Выборка данных, упорядоченных по имени с использованием метода сравнения для сортировки
SELECT licensee_obj.GetLicenseeInfo AS licensee_info
FROM LicenseeType2
ORDER BY licensee_obj.compareForOrder();




DECLARE
    licensee1 LicenseeType2 := LicenseeType2(1, 'John', 'Doe', 'ABC Corp', 'john@example.com', 'Additional Details 1');
    licensee2 LicenseeType2 := LicenseeType2(2, 'Jane', 'Smith', 'XYZ Ltd', 'jane@example.com', 'Additional Details 2');
BEGIN
    -- Вызов метода сравнения
    DBMS_OUTPUT.PUT_LINE('Comparison Result: ' || licensee1.compareForOrder(licensee2));

    -- Вызов метода экземпляра-функции
    --DBMS_OUTPUT.PUT_LINE('Licensee Info: ' || licensee1.GetLicenseeInfo);

    -- Вызов метода экземпляра-процедуры
    --licensee1.PrintLicenseeInfo;
END;