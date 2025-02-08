USE UNIVER;

DROP VIEW [Дисциплины];
GO

CREATE VIEW Дисциплины (Код, [Наименование дисциплины], [Код кафедры])
	AS SELECT TOP 150 SUBJECT, SUBJECT_NAME, PULPIT
		FROM SUBJECT
			ORDER BY SUBJECT_NAME
		GO
	SELECT * FROM  Дисциплины;