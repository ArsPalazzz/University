USE UNIVER;
GO

ALTER VIEW [Количество кафедр] WITH SCHEMABINDING
	AS SELECT FACULTY.FACULTY_NAME [Факультет], COUNT (*) [Количество кафедр]
		FROM dbo.FACULTY JOIN dbo.PULPIT
			ON FACULTY.FACULTY = PULPIT.FACULTY
				GROUP BY FACULTY.FACULTY_NAME
		GO
	SELECT * FROM  [Количество кафедр];

	/*Опция SCHEMABINDING устанавливает запрещение на операции с таблицами и представлениями, которые могут привести к нарушению 
	работоспособности представления*/