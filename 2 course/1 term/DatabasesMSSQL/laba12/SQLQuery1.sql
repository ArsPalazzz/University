use UNIVER
set nocount on
go

CREATE PROCEDURE PSUBJECT 
as 
begin
	declare @k int = (select count(*) from SUBJECT);
	select SUBJECT [Код], SUBJECT_NAME [Дисциплина], PULPIT [Кафедра] from SUBJECT;
	return @k;
end;

declare @y int = 0;
exec @y = PSUBJECT;
print('Количество строк = ') + cast(@y as varchar(3));

drop procedure PSUBJECT;