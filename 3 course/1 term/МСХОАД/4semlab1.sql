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

select * from Licensees; 


select * from Licenses
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

truncate table Licensees
select * from License_keys
select * from Licenses

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



delete FROM License_keys WHERE id_of_key IN (SELECT id_of_key FROM License_keys);
DROP TABLE License_keys CASCADE CONSTRAINTS;

select * from dba_tables where OWNER = 'TESTCORE';

delete FROM Licenses WHERE licensees_id IN (SELECT licensee_id FROM Licensees);
DROP TABLE Licensees CASCADE CONSTRAINTS;

drop table UsagePlacesTable;
drop table License_History;
drop table License_Rules;
drop table License_keys;
drop table Licensees;
drop table Licenses;
drop table LicenseOrders;