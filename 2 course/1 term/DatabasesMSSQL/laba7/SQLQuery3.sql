USE UNIVER;

DROP VIEW [Аудитории];
GO

CREATE VIEW Аудитории (Код, [Наименование аудитории], [Тип аудитории])
	AS SELECT AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE
		FROM AUDITORIUM
			WHERE AUDITORIUM_TYPE LIKE 'ЛК%'
		GO
	SELECT * FROM  Аудитории;

INSERT Аудитории values('275-1', '275-1', 'ЛК')
INSERT Аудитории values('276-1', '276-1', 'ЛК')

DELETE FROM Аудитории
	WHERE Код = '275-1' or Код = '276-1'