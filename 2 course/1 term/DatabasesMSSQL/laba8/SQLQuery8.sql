create table #MyTable([Исходное значение] int, Увеличение nvarchar(50), Уменьшение nvarchar(50));
set nocount on; --не выводить сообщения о вводе строк
declare @i int = 1;
while @i <11
	begin
		if @i = 5
			return
		else
			begin
				insert into #MyTable values
				(cast(@i as int), cast(@i as nvarchar(10)) + ' + 1 = ' + cast((@i + 1) as nvarchar(10)),cast(@i as nvarchar(10)) + ' - 1 = ' + cast((@i - 1) as nvarchar(10)))
				print 'Значение ' + cast(@i as nvarchar(10))
				set @i +=1;
			end
	end
select * from #MyTable
order by [Исходное значение] desc
go

drop table #MyTable;