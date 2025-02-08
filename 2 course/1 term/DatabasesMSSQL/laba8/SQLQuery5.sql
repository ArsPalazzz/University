use UNIVER

declare @amount int = (select count(*) from AUDITORIUM)
if @amount > 10
	begin
		print 'Количество аудиторий больше, чем 10'
		print 'Текст'
		print 'Текст'
	end
else if @amount < 10
	begin
		print 'Количество аудиторий меньше, чем 10'
		print 'Текст'
		print 'Текст'
	end
else 
	print 'Количество аудиторий равно 10'