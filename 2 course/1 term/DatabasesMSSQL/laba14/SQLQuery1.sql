use UNIVER
go

drop table TR_AUDIT

create table TR_AUDIT
	(
	ID int identity,
	STMT varchar(20)
		check (STMT in ('INS', 'DEL', 'UPDINS', 'UPDDEL')),
	TRNAME varchar(50),
	CC varchar(300)
	)

drop trigger TR_TEACHER_INS

go

create trigger TR_TEACHER_INS 
	on TEACHER after insert
		as 
			declare @a1 varchar(10), @a2 char(100), @a3 char(1), @a4 varchar(20), @in varchar(300);
			print 'Операция вставки';
			set @a1 = (select [TEACHER] from INSERTED);
			set @a2 = (select [TEACHER_NAME] from INSERTED);
			set @a3 = (select [GENDER] from INSERTED);
			set @a4 = (select [PULPIT] from INSERTED);
			set @in = @a1 + '' + @a2 + '' + @a3 + ' ' + @a4;
			insert into TR_AUDIT(STMT, TRNAME, CC) values('INS', 'TR_TEACHER_INS', @in);
			return;

insert into  TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
                   values('ГРН', 'Гурин Николай Иванович', 'м', 'исит');

select * from TR_AUDIT


go




--2




drop trigger TR_TEACHER_DEL

go

create trigger TR_TEACHER_DEL 
	on TEACHER after DELETE
		as 
			declare @a1 varchar(10), @a2 char(100), @a3 char(1), @a4 varchar(20), @in varchar(300);
			print 'Операция удаления';
			set @a1 = (select [TEACHER] from DELETED);
			set @a2 = (select [TEACHER_NAME] from DELETED);
			set @a3 = (select [GENDER] from DELETED);
			set @a4 = (select [PULPIT] from DELETED);
			set @in = @a1 + '' + @a2 + '' + @a3 + ' ' + @a4;
			insert into TR_AUDIT(STMT, TRNAME, CC) values('DEL', 'TR_TEACHER_DEL', @in);
			return;

go

delete TEACHER where TEACHER_NAME = 'Гурин Николай Иванович'
select * from TR_AUDIT




--3




drop trigger TR_TEACHER_UPD

go

create trigger TR_TEACHER_UPD 
	on TEACHER after update
		as 
			declare @a1upd varchar(10), @a2upd char(100), @a3upd char(1), @a4upd varchar(20), @inupd varchar(300);
			declare @a1del varchar(10), @a2del char(100), @a3del char(1), @a4del varchar(20), @indel varchar(300);
			print 'Операция обновления';

			set @a1upd = (select [TEACHER] from INSERTED);
			set @a2upd = (select [TEACHER_NAME] from INSERTED);
			set @a3upd = (select [GENDER] from INSERTED);
			set @a4upd = (select [PULPIT] from INSERTED);
			set @inupd = @a1upd + '' + @a2upd + '' + @a3upd + ' ' + @a4upd;

			set @a1del = (select [TEACHER] from DELETED);
			set @a2del = (select [TEACHER_NAME] from DELETED);
			set @a3del = (select [GENDER] from DELETED);
			set @a4del = (select [PULPIT] from DELETED);
			set @indel = @a1del + '' + @a2del + '' + @a3del + ' ' + @a4del;

			insert into TR_AUDIT(STMT, TRNAME, CC) values('UPDINS', 'TR_TEACHER_UPD', @inupd), 
														 ('UPDDEL', 'TR_TEACHER_UPD', @indel);
			return;

go

update TEACHER set TEACHER = 'ЖЛК' where TEACHER = 'ЖИЛЯК'
select * from TR_AUDIT





--4 


drop trigger TR_TEACHER

go
create trigger TR_TEACHER 
	on TEACHER after insert, update, delete

	as  declare @a1 varchar(10), @a2 char(100), @a3 char(1), @a4 varchar(20), @in varchar(300);
		declare @a1upd varchar(10), @a2upd char(100), @a3upd char(1), @a4upd varchar(20), @inupd varchar(300);
		declare @a1del varchar(10), @a2del char(100), @a3del char(1), @a4del varchar(20), @indel varchar(300);
	declare @ins int = (select count(*) from inserted),
				  @del int = (select count(*) from deleted); 
	if  @ins > 0 and  @del = 0  
	begin 
		 print 'Событие: INSERT';
		 set @a1 = (select [TEACHER] from INSERTED);  
		 set @a2 = (select [TEACHER_NAME] from INSERTED);
		 set @a3 = (select [GENDER] from INSERTED);
		 set @a4 = (select [PULPIT] from DELETED);
		 set @in = @a1 + '' + @a2 + '' + @a3 + ' ' + @a4;
		insert into TR_AUDIT(STMT, TRNAME, CC) values('INS', 'TR_TEACHER_INS4', @in);
	end; 
	else		  	 
	if @ins = 0 and  @del > 0  
	begin 
		print 'Событие: DELETE';
		set @a1 = (select [TEACHER] from DELETED);
			set @a2 = (select [TEACHER_NAME] from DELETED);
			set @a3 = (select [GENDER] from DELETED);
			set @a4 = (select [PULPIT] from DELETED);
			set @in = @a1 + '' + @a2 + '' + @a3 + ' ' + @a4;
			insert into TR_AUDIT(STMT, TRNAME, CC) values('DEL', 'TR_TEACHER_DEL4', @in);
	end; 
	else	  
	if @ins > 0 and  @del > 0  
	begin 
		print 'Событие: UPDATE'; 
		set @a1upd = (select [TEACHER] from INSERTED);
			set @a2upd = (select [TEACHER_NAME] from INSERTED);
			set @a3upd = (select [GENDER] from INSERTED);
			set @a4upd = (select [PULPIT] from INSERTED);
			set @inupd = @a1upd + '' + @a2upd + '' + @a3upd + ' ' + @a4upd;

			set @a1del = (select [TEACHER] from DELETED);
			set @a2del = (select [TEACHER_NAME] from DELETED);
			set @a3del = (select [GENDER] from DELETED);
			set @a4del = (select [PULPIT] from DELETED);
			set @indel = @a1del + '' + @a2del + '' + @a3del + ' ' + @a4del;

			insert into TR_AUDIT(STMT, TRNAME, CC) values('UPDINS', 'TR_TEACHER_UPD4', @inupd), 
														 ('UPDDEL', 'TR_TEACHER_UPD4', @indel);
	end;  
	return;  

go

insert into TEACHER (TEACHER, TEACHER_NAME, GENDER, PULPIT) values
			('МР2','Мороз Елена Станиславовна','ж','ИСиТ')
update TEACHER set TEACHER = 'МР4' where TEACHER = 'МР2'
delete TEACHER where TEACHER = 'МР4'

select * from TR_AUDIT

delete TR_AUDIT



--5

DROP table TR_AUDIT2

create table TR_AUDIT2
	(
	ID int identity,
	STMT varchar(20)
		check (STMT in ('INS', 'DEL', 'UPDINS', 'UPDDEL')),
	TRNAME varchar(50),
	CC varchar(300)
	)
GO

DROP TRIGGER TR_TEACHER_INS2

GO

	create trigger TR_TEACHER_INS2
	on TEACHER after insert
		as 
			declare @a1 varchar(10), @a2 char(100), @a3 char(1), @a4 varchar(20), @in varchar(300);
			print 'Операция вставки';
			set @a1 = (select [TEACHER] from INSERTED);
			set @a2 = (select [TEACHER_NAME] from INSERTED);
			set @a3 = (select [GENDER] from INSERTED);
			set @a4 = (select [PULPIT] from INSERTED);
			set @in = @a1 + '' + @a2 + '' + @a3 + ' ' + @a4;
			insert into TR_AUDIT2(STMT, TRNAME, CC) values('BRUH', 'TR_TEACHER_INS', @in);
			return;

insert into  TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT)
                   values('ГРН', 'Гурин Николай Иванович', 'м', 'исит');

select * from TR_AUDIT2


--6 

drop trigger TR_TEACHER_DEL1
drop trigger TR_TEACHER_DEL2
drop trigger TR_TEACHER_DEL3

GO 

create trigger TR_TEACHER_DEL1 on TEACHER after DELETE  
       as 
		declare @a nvarchar(50) = (select TEACHER from deleted)
		insert into TR_AUDIT values ('DEL','TR_TEACHER_DEL1',@a)
		PRINT 'TR_TEACHER_DEL1';
 return;  
go 

create trigger TR_TEACHER_DEL2 on TEACHER after DELETE  
       as 
		declare @a nvarchar(50) = (select TEACHER from deleted)
		insert into TR_AUDIT values ('DEL','TR_TEACHER_DEL2',@a)
		PRINT 'TR_TEACHER_DEL2';
 return;  
go 

create trigger TR_TEACHER_DEL3 on TEACHER after DELETE  
       as 
		declare @a nvarchar(50) = (select TEACHER from deleted)
		insert into TR_AUDIT values ('DEL','TR_TEACHER_DEL3',@a)
		PRINT 'TR_TEACHER_DEL3';
 return;  
go 


exec  SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL1', @order = 'None', @stmttype = 'DELETE';
exec  SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL2', @order = 'Last', @stmttype = 'DELETE';
exec  SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL3', @order = 'First', @stmttype = 'DELETE';


insert into TEACHER (TEACHER, TEACHER_NAME, GENDER, PULPIT) values
('ПРЕПОД','Препод Препод Преподович','М','Исит')
delete TEACHER where TEACHER = 'ПРЕПОД'

select * from TR_AUDIT

select t.name, e.type_desc 
from sys.triggers  t join  sys.trigger_events e  
on t.object_id = e.object_id  
where OBJECT_NAME(t.parent_id) = 'TEACHER' and e.type_desc = 'DELETE' ;  


--7 


drop trigger TR7

go
create trigger TR7 on TEACHER after insert, delete, update as
begin
	declare @count int = (select count(*) from TEACHER)
	if (@count>5)
		begin
			raiserror('Тут больше 5 строчек а это плохо',10,1)
			rollback
		end
	return
end
go

insert into TEACHER (TEACHER, TEACHER_NAME, GENDER, PULPIT) values
('ПРЕПОД','Препод Препод Преподович','М','Исит')


--8 


drop trigger InsteadOf8

go
create trigger InsteadOf8 on FACULTY instead of delete 
as
	raiserror(N'Удаление запрещено!',10,1)
	return

go

select * from TEACHER

delete FACULTY where FACULTY = 'ИЭФ'



--9



drop trigger TR_UNIVERSITY
enable TRIGGER TR_UNIVERSITY ON database

go
create trigger TR_UNIVERSITY on database for DDL_DATABASE_LEVEL_EVENTS as
	declare @t1 varchar(50), @t2 varchar(50), @t3 varchar(50)
	set @t1 = EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]','varchar(50)')
	set @t2 = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]','varchar(50)')
	set @t3 = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]','varchar(50)')

	print 'Тип события: ' + @t1;
	print 'Тип события: ' + @t2;
	print 'Тип события: ' + @t3;

	raiserror ('Чето изменилось',10,1)
rollback
return
go

drop table JustATable;

create table JustATable
(
id int primary key,
mememe varchar(300)
);

select * from JustATable;
drop table JustATable;