use UNIVER

SELECT max(AUDITORIUM_CAPACITY) [Максимальная вместимость],
	   min(AUDITORIUM_CAPACITY) [Минимальная вместимость],
	   avg(AUDITORIUM_CAPACITY) [Средняя вместимость],
	   sum(AUDITORIUM_CAPACITY) [Суммарная вместимость],
	   count(AUDITORIUM_CAPACITY) [Общая вместимость]
FROM AUDITORIUM