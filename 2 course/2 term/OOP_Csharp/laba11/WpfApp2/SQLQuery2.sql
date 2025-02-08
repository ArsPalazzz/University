create database CourseDb
use CourseDb;

CREATE TABLE DISCIPLINE (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(MAX) NOT NULL,
	QuantityHours INT NOT NULL CHECK (QuantityHours > 0),
	Lector NVARCHAR(MAX) NOT NULL,
	Quantity INT NOT NULL CHECK (Quantity > 0),
	IsSelected BIT NOT NULL
);



drop table Student;

CREATE TABLE Student (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  Name NVARCHAR(MAX) NOT NULL,
  Surname NVARCHAR(MAX) NOT NULL,
  Age int NOT NULL CHECK (Age >= 17 AND Age <= 60),
  IsSelected bit
);

insert into Student (Name, Surname, Age) values ('Ars', 'Palaz', 19);

select * from Student;

drop table CourseTable;

CREATE TABLE CourseTable (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  idDiscipline int NOT NULL foreign key references DISCIPLINE(id),
  idStudent int NOT NULL foreign key references Student(id),
  Name NVARCHAR(MAX) NOT NULL,
  Lector NVARCHAR(MAX) NOT NULL,
  Surname NVARCHAR(MAX) NOT NULL
);


ALTER TABLE CourseTable
ADD Name NVARCHAR(MAX),
    Lector NVARCHAR(MAX),
    Surname NVARCHAR(MAX);
insert into CourseTable values (1, 1);
delete from CourseTable where id = 1;
select * from CourseTable;

