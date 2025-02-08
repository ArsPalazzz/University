USE UNIVER;
/* Встроенная функция CAST используется в запросе для перевода значения в вещественное число. */
/* Функция ROUND обеспечивает расчет значений с точностью до двух знаков после запятой: */

SELECT  f.FACULTY[Факультет], /* задаем какие поля будут выводится (после точки, это столбцы, f,g - ) */
    g.PROFESSION[Специальность], 
    g.YEAR_FIRST[Год поступления],
    round(avg(cast(p.NOTE as float(4))),2)[Средняя оценка]  /* считаем среднюю */
  FROM FACULTY f 
  Inner Join GROUPS g ON f.FACULTY = g.FACULTY
  Inner Join STUDENT s ON g.IDGROUP = s.IDGROUP
  Inner Join PROGRESS p ON p.IDSTUDENT = s.IDSTUDENT
  GROUP BY f.FACULTY, g.PROFESSION, g.YEAR_FIRST
  ORDER BY [Средняя оценка] desc;

/* №4(б) */
-- значения оценок использовались оценки только по дисциплинам с кодами БД и ОАиП
USE UNIVER;
SELECT  f.FACULTY[Факультет], 
    g.PROFESSION[Специальность], 
    g.YEAR_FIRST[Год поступления],
    round(avg(cast(p.NOTE as float(4))),2)[Средняя оценка]
  FROM FACULTY f 
  Inner Join GROUPS g ON f.FACULTY = g.FACULTY
  Inner Join STUDENT s ON g.IDGROUP = s.IDGROUP
  Inner Join PROGRESS p ON p.IDSTUDENT = s.IDSTUDENT
  WHERE p.SUBJECT IN('БД', 'ОАиП')
  GROUP BY f.FACULTY, g.PROFESSION, g.YEAR_FIRST
  ORDER BY [Средняя оценка] desc;