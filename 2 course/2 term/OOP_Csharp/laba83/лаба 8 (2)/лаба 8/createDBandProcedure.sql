use University;

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'University')
                begin
                 create database University
                end 




begin
	use University
	create table Students(
		ID int primary key identity(1, 1), 
		NAME nvarchar(100) not null,
		AGE int check(AGE between 16 and 50) not null,
		BIRTHDAY date not null,
		SEX nchar(1) check(SEX in ('м', 'ж')) not null,
		FOTO varbinary(max) default null
	)
end;

create login univer WITH password = '123';





CREATE LOGIN myuser WITH PASSWORD='123'

select suser_sname(owner_sid) as 'Owner', state_desc, *
from sys.databases;

select * from master.sys.server_principals;
CREATE LOGIN univertst WITH PASSWORD='123'




drop procedure [dbo].[sp_InsertStudents]

CREATE PROCEDURE [dbo].[sp_InsertStudents]
                    @NAME nvarchar(50),
                    @AGE int, 
					@BIRTHDAY date,
                    @SEX nchar(1) 
                AS insert
                into Students(NAME, AGE, BIRTHDAY, SEX)
                VALUES(@NAME, @AGE, @BIRTHDAY, @SEX)
                SELECT SCOPE_IDENTITY()
                GO 

CREATE PROCEDURE [dbo].[sp_InsertMark]
                    @SubjectName nvarchar(50),
                    @Mark int,
					@Student_id int
                AS insert
                into Mark(SubjectName, Mark, Student_id)
                VALUES(@SubjectName, @Mark, @Student_id)
                SELECT SCOPE_IDENTITY()
                GO


drop table Students

select * from Students;
select * from Mark;

insert into Students(NAME, AGE, BIRTHDAY, SEX) values 
                  ('Палазник Арсений Викторович',  23, '04-06-2000', 'м'),
             ('Шишова Татьяна Сергеевна', 20, '10-07-1998',  'ж'),  
               ('Вакуленчик Владислав Сергеевич', 19, '12-07-1997',  'м'), 
                ('Леонец Алексей Олегович', 18, '12-02-2000', 'м'),
				  ('Халалеенко Андрей НеЗнаюКтович', 18, '12-02-2000', 'м') ;

          insert into Mark(SubjectName, Mark, Student_id) values
                    ('OOP', 6, 1),
                    ('DB', 7, 2),
                    ('DPI', 8, 3),
                 ('KMS', 5, 4),
				  ('CMS', 7, 5);