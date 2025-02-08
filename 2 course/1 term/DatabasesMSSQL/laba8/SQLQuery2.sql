use UNIVER;

declare @capacity int = (select cast(sum(AUDITORIUM_CAPACITY) as int) from AUDITORIUM),
		@total int,
		@avgCapacity int,
		@totalLessThanAvg int,
		@procent numeric(4,2);

if @capacity > 200
begin
	set @total = (select cast(count(*) as int) from AUDITORIUM);
	set @avgCapacity = (select avg(AUDITORIUM_CAPACITY) from AUDITORIUM);
	set @totalLessThanAvg = (select cast(count(*) as int) from AUDITORIUM where AUDITORIUM_CAPACITY < @avgCapacity);
	set @procent = @totalLessThanAvg * 100 / @total;
	select  @capacity 'Общая вместимость',
			@total 'Всего аудиторий',
			@avgCapacity 'Средняя вместимость',
			@totalLessThanAvg 'Количество аудиторий, вместимость которых меньше средней',
			@procent 'Процент таких аудиторий'
end

else print 'Общая вместимость < 200'