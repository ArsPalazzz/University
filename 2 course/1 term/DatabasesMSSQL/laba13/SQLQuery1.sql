use UNIVER

drop function Count_Students

go
create function Count_Students (@faculty nvarchar(20)) returns int
as
begin
	declare @kolich int;
	set @kolich = (select count(*) from FACULTY
						  join GROUPS on FACULTY.FACULTY = GROUPS.FACULTY 
						  join STUDENT on GROUPS.IDGROUP = STUDENT.IDGROUP
						  where  FACULTY.FACULTY = @faculty)
	return @kolich
end
go

print 'Количество студентов на ФИТе: ' + cast(dbo.Count_Students('ИТ') as nvarchar(20))
select FACULTY, dbo.Count_Students(FACULTY) from FACULTY



-------------



go
alter function COUNT_STUDENTS (@faculty nvarchar(20)= null, @prof nvarchar(200) = null) returns int
as
begin
	declare @counter int = 0
	set @counter =
	(select count(STUDENT.IDSTUDENT) from FACULTY
			join GROUPS on FACULTY.FACULTY = GROUPS.FACULTY
			join STUDENT on GROUPS.IDGROUP = STUDENT.IDGROUP
			join PROFESSION on FACULTY.FACULTY = PROFESSION.FACULTY
	where FACULTY.FACULTY = @faculty and PROFESSION.PROFESSION_NAME = @prof)
	return @counter
end
go

select FACULTY.FACULTY, PROFESSION.PROFESSION_NAME,
	   dbo.COUNT_STUDENTS(FACULTY.FACULTY, PROFESSION.PROFESSION_NAME)
	   from FACULTY
	   join PROFESSION on FACULTY.FACULTY = PROFESSION.FACULTY

print 'Количество студентов: ' + 
cast(dbo.Count_students('ХТиТ', 'Конструирование и производство изделий из композиционных материалов') as nvarchar(20))


--2

drop function FSUBJECTS;

go

create function FSUBJECTS (@p nvarchar(20)) returns nvarchar(300) as
begin
	declare @word nvarchar(10), @string nvarchar(200) = ' ';

	declare fsubj cursor local static
	for select SUBJECT from SUBJECT where PULPIT = @p

	open fsubj
	fetch fsubj into @word
	set @string  = @string + rtrim(@word)
	fetch fsubj into @word
	while @@FETCH_STATUS = 0
		begin
			fetch fsubj into @word
			set @string  =@string  + ', ' + rtrim(@word)
		end
	close fsubj
	return @string
end
go

select PULPIT, dbo.FSUBJECTS(PULPIT) [Дисциплины] from SUBJECT group by PULPIT



--3


drop function FFACPUL

go 
create function FFACPUL (@ff nvarchar(20), @pp nvarchar(20)) returns table 
as return
select FACULTY.FACULTY, PULPIT.PULPIT from FACULTY
	   left join PULPIT on FACULTY.FACULTY = PULPIT.FACULTY
where FACULTY.FACULTY = isnull(@ff,FACULTY.FACULTY)
	  and PULPIT.PULPIT = isnull(@pp,PULPIT.PULPIT)
go

select * from dbo.FFACPUL (null,null)
select * from dbo.FFACPUL ('ЛХФ',null)
select * from dbo.FFACPUL (null,'ЛВ')
select * from dbo.FFACPUL ('ЛХФ','ЛВ')


--4


drop function FCTEACHER

go
create function FCTEACHER (@p nvarchar(20)) returns int as 
begin 
	declare @counter int = (select count(*) from TEACHER
							where PULPIT = isnull(@p,PULPIT)) --isnull - Заменяет значение NULL указанным замещающим значением.
	return @counter
end
go

select PULPIT, dbo.FCTEACHER(PULPIT)[Общее количество преподавателей] from TEACHER group by PULPIT
select dbo.FCTEACHER(null) [Общее количество преподавателей]

