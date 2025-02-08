create table Licensees (
	licensee_id int primary key,
	name nvarchar2(10),
	surname nvarchar2(10),
	organization nvarchar2(20),
	contact nvarchar2(30),
	add_details nvarchar2(20)
);

CREATE TABLE UsagePlacesTable (
    usage_place_id INT PRIMARY KEY,
    licensee_id INT,
    place_name NVARCHAR2(50),
    location NVARCHAR2(50),
    description NVARCHAR2(100),
    CONSTRAINT fk_licensee
        FOREIGN KEY (licensee_id)
        REFERENCES Licensees (licensee_id)
);

create table Licenses (
	license_id int primary key,
	license_name nvarchar2(20),
	license_type nvarchar2(20),
	date_of_issue date,
	expiration_date date,
	description nvarchar2(30),
	status nvarchar2(20),
	licensees_id int,
    id_of_key int,
	total_license_cost decimal(10,2),
	licensee_contact nvarchar2(30),
	foreign key (licensees_id) references Licensees (licensee_id)
);

create table License_keys (
	id_of_key int primary key,
	id_of_license int,
	foreign key (id_of_license) references Licenses (license_id),
	key_of_name nvarchar2(20),
	status nvarchar2(20)
);

create table License_Rules (
	rule_id int primary key,
	license_id int,
	foreign key (license_id) references Licenses(license_id),
	text_rules nvarchar2(20),
	data_create date,
	data_change date
);

create table License_History (
	record_id int primary key,
	license_id int,
	foreign key (license_id) references Licenses(license_id),
	action nvarchar2(10),
	date_of_action date,
	username nvarchar2(10)
);

















-- Вставка данных в таблицу Licensees
INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
(1, 'John', 'Doe', 'ABC Inc.', 'john.doe@abc.com', 'Additional Info 1');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
(2, 'Jane', 'Smith', 'XYZ Ltd.', 'jane.smith@xyz.com', 'Additional Info 2');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
(3, 'Mike', 'Johnson', '123 Corp.', 'mike.johnson@123corp.com', 'Additional Info 3');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
(4, 'Emily', 'Davis', 'Software Solutions', 'emily.davis@softsol.com', 'Additional Info 4');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
(5, 'Alex', 'Brown', 'Tech Innovations', 'alex.brown@techinnov.com', 'Additional Info 5');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
(6, 'Eva', 'Williams', 'Data Systems', 'eva.williams@datasys.com', 'Additional Info 6');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
(7, 'Mark', 'Taylor', 'Future Tech', 'mark.taylor@futuretech.com', 'Additional Info 7');

INSERT INTO Licensees (licensee_id, name, surname, organization, contact, add_details)
VALUES
(8, 'Sophia', 'Clark', 'Innovate IT', 'sophia.clark@innovateit.com', 'Additional Info 8');

-- Вставка данных в таблицу UsagePlacesTable
INSERT INTO UsagePlacesTable (usage_place_id, licensee_id, place_name, location, description)
VALUES
(101, 1, 'Office A', 'City Center', 'Main office location for ABC Inc.');

INSERT INTO UsagePlacesTable (usage_place_id, licensee_id, place_name, location, description)
VALUES
(102, 2, 'Lab B', 'Tech Park', 'Research and development lab for XYZ Ltd.');

INSERT INTO UsagePlacesTable (usage_place_id, licensee_id, place_name, location, description)
VALUES
(103, 3, 'Branch C', 'Downtown', 'Branch office for 123 Corp.');

INSERT INTO UsagePlacesTable (usage_place_id, licensee_id, place_name, location, description)
VALUES
(104, 4, 'Data Center', 'Industrial Zone', 'Central data center for Software Solutions');

INSERT INTO UsagePlacesTable (usage_place_id, licensee_id, place_name, location, description)
VALUES
(105, 5, 'Innovation Hub', 'Tech District', 'Innovative projects at Tech Innovations');

INSERT INTO UsagePlacesTable (usage_place_id, licensee_id, place_name, location, description)
VALUES
(106, 6, 'Data Warehouse', 'Business Park', 'Data storage and analysis at Data Systems');

INSERT INTO UsagePlacesTable (usage_place_id, licensee_id, place_name, location, description)
VALUES
(107, 7, 'Future Lab', 'Tech Campus', 'Research facility at Future Tech');

INSERT INTO UsagePlacesTable (usage_place_id, licensee_id, place_name, location, description)
VALUES
(108, 8, 'IT Hub', 'Innovation Zone', 'IT development center at Innovate IT');
