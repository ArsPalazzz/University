USE UNIVER;

exec sp_helpindex 'AUDITORIUM_TYPE' -- перечень индексов, связанных с заданной таблицей

create table #task1
	(	
		first int, 
		second varchar(100)
	)

set nocount on -- не выводить сообщения о вводе строк
declare @i int = 0
while @i < 1000
begin
	insert #task1(first, second) values (floor(20000*rand()), replicate('строка', 10))
	if (@i % 100 = 0) print @i;
	set @i = @i + 1
end

select * from #task1 where first between 1500 and 2500 order by first -- 0.0110487

checkpoint;  -- фиксация БД
dbcc dropcleanbuffers --очистить буферный кэш

create clustered index #task1_cl on #task1(first asc)

select * from #task1 where first between 1500 and 2500 order by first -- 0.0033396

drop index #task1_cl on #task1
drop table #task1;