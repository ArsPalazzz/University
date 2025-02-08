USE UNIVER;

DROP VIEW [Количество кафедр];
GO

CREATE VIEW [Количество кафедр]
	AS SELECT	FACULTY.FACULTY_NAME [Факультет],
				count (distinct PULPIT.PULPIT) [Количество кафедр]
	FROM FACULTY JOIN PULPIT
		ON FACULTY.FACULTY = PULPIT.FACULTY
			GROUP BY FACULTY.FACULTY_NAME;
	go
select * from [Количество кафедр];