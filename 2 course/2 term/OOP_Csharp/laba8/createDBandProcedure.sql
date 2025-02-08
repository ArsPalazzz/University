use University;

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'University')
                begin
                 create database University
                end 


CREATE PROCEDURE [dbo].[sp_InsertAuthor]
                    @NAME nvarchar(100),
                    @AGE int, 
					@BIRTHDAY date,
                    @SEX nchar(1) 
                AS insert
                into Authors(NAME, AGE, BIRTHDAY, SEX)
                VALUES(@NAME, @AGE, @BIRTHDAY, @SEX)
                SELECT SCOPE_IDENTITY()
                GO 

CREATE PROCEDURE [dbo].[sp_InsertBook]
                    @AuthorId int,
                    @NameBook nvarchar(20),
                    @Index int
                AS insert
                into Books(AuthorId, NameBook, [Index])
                VALUES(@AuthorId, @NameBook, @Index)
                SELECT SCOPE_IDENTITY()
                GO

select * from Authors;

drop table Books;
drop table Authors;

drop procedure [dbo].[sp_InsertBook];


begin
	use University
	create table Authors(
		ID int primary key identity(100, 1), 
		NAME nvarchar(100) not null,
		AGE int check(AGE between 17 and 40) not null,
		BIRTHDAY date not null,
		SEX nchar(1) check(SEX in ('ì', 'æ')) not null,
		FOTO varbinary(max) default null
	)
end;



  create table [Books](  
                    ID int primary key identity(1,1),  
                    AuthorId int foreign key references[Authors](ID),
                      NameBook nvarchar(20) not null, 
                    [Index] int check([Index] between 100000 and 999999) not null 
               ) ;