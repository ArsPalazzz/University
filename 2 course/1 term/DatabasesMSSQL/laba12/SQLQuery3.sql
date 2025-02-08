create table #SUBJECT
(
	subj nvarchar(20),
	subj_name nvarchar(300),
	pulp nvarchar(20)
)

go
alter procedure PSUBJECT @p varchar(20) = null as
begin
	select SUBJECT [Код], SUBJECT_NAME [Дисциплина], PULPIT [Кафедра] from SUBJECT where PULPIT = @p;
end
go

go
insert #SUBJECT exec PSUBJECT @p = 'ИСИТ'
insert #SUBJECT exec PSUBJECT @p = 'ЛУ'
select * from #SUBJECT
go

drop table #SUBJECT;