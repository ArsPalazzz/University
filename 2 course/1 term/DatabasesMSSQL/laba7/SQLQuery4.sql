USE UNIVER;

DROP VIEW [Лекционные_аудитории];
GO

CREATE VIEW Лекционные_аудитории (Код, [Наименование аудитории], [Тип аудитории])
	AS SELECT AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE
		FROM AUDITORIUM
			WHERE AUDITORIUM_TYPE LIKE 'ЛК%'
		GO
	SELECT * FROM  Лекционные_аудитории;

INSERT Аудитории values('275-1', '275-1', 'НЕЛК')
INSERT Аудитории values('276-1', '276-1', 'ЛК')

DELETE FROM Аудитории
	WHERE Код = '275-1' or Код = '276-1'

GO

--Чтобы операция вставки не могла осуществиться в том случае, когда информация не удовлетворяет условию, 
--записанному в секции Where, то следует создавать представление с опцией WITH CHECK OPTION
ALTER VIEW Лекционные_аудитории (Код, [Наименование аудитории], [Тип аудитории])
	AS SELECT AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE
		FROM AUDITORIUM
			WHERE AUDITORIUM_TYPE LIKE 'ЛК%' WITH CHECK OPTION
		GO
	SELECT * FROM  Лекционные_аудитории;

INSERT Лекционные_аудитории values('277-1', '275-1', 'ЛБ-К')
INSERT Лекционные_аудитории values('276-1', '276-1', 'ЛК')

DELETE FROM Аудитории
	WHERE Код = '276-1'