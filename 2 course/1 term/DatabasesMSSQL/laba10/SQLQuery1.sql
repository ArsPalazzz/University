USE UNIVER;
DECLARE @discip char(20), @d char(300) ='';
DECLARE Discipline CURSOR
				for SELECT SUBJECT.SUBJECT --1 столбец
					FROM SUBJECT 
					WHERE SUBJECT.PULPIT IN('ИСиТ')
	OPEN Discipline; --Курсор открывается с помощью оператора OPEN
	FETCH Discipline into @discip; --1 переменная
	print 'Дисциплины с кафедры ИСиТ';
	while @@fetch_status = 0
		begin
			set @d = rtrim(@discip) + ',' + @d;
			FETCH Discipline into @discip; --1 переменная
		end;
	print @d;
	CLOSE Discipline;
	DEALLOCATE Discipline /*Удаляет ссылку курсора. Когда удаляется последняя ссылка курсора, Microsoft SQL Server освобождает 
							структуры данных, составляющие курсор. */