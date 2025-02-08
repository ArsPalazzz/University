--Основное отличие временных таблиц от постоянных в том, что они хранятся в си-стемной базе данных TEMPDB и не могут иметь внешние ключи. 
--Локальные временные таблицы имеют имена, начинающиеся с символа # и до-ступны только пользователю, ее создавшему
--Глобальные временные таблицы имеют имена, начинающиеся с символов ## и до-ступны всем пользователям, подключенным к серверу

create table #MyTable([Исходное значение] int, Увеличение nvarchar(50), Уменьшение nvarchar(50));
set nocount on; --не выводить сообщения о вводе строк
declare @i int = 1;
while @i <11
	begin
		insert into #MyTable values
		(cast(@i as int), cast(@i as nvarchar(10)) + ' + 1 = ' + cast((@i + 1) as nvarchar(10)),cast(@i as nvarchar(10)) + ' - 1 = ' + cast((@i - 1) as nvarchar(10)))
		set @i +=1;
	end
select * from #MyTable
order by [Исходное значение] desc
go

drop table #MyTable;