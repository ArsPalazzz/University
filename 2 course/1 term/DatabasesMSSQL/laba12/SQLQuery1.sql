use UNIVER
set nocount on
go

CREATE PROCEDURE PSUBJECT 
as 
begin
	declare @k int = (select count(*) from SUBJECT);
	select SUBJECT [���], SUBJECT_NAME [����������], PULPIT [�������] from SUBJECT;
	return @k;
end;

declare @y int = 0;
exec @y = PSUBJECT;
print('���������� ����� = ') + cast(@y as varchar(3));

drop procedure PSUBJECT;