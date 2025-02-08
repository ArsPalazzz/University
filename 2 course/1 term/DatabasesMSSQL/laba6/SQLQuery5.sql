USE UNIVER;
SELECT  f.FACULTY[Факультет], 
    g.PROFESSION[Специальность], 
    p.SUBJECT[Дисциплина],
    round(avg(cast(p.NOTE as float(4))), 2)[Средняя оценка]
  FROM FACULTY f 
  Inner Join GROUPS g ON f.FACULTY = g.FACULTY
  Inner Join STUDENT s ON g.IDGROUP = s.IDGROUP
  Inner Join PROGRESS p ON p.IDSTUDENT = s.IDSTUDENT
  WHERE f.FACULTY IN('ТОВ')
  GROUP BY f.FACULTY, g.PROFESSION, p.SUBJECT

--ROLLUP выводит такие же результирующие группы строк как и при обычном group by и итоговые строки по значениям, указанными в скобках справа от ключ слова rollup
SELECT  f.FACULTY[Факультет], 
    g.PROFESSION[Специальность], 
    p.SUBJECT[Дисциплина],
    round(avg(cast(p.NOTE as float(4))), 2)[Средняя оценка]
  FROM FACULTY f 
  Inner Join GROUPS g ON f.FACULTY = g.FACULTY
  Inner Join STUDENT s ON g.IDGROUP = s.IDGROUP
  Inner Join PROGRESS p ON p.IDSTUDENT = s.IDSTUDENT
  WHERE f.FACULTY IN('ТОВ')
  GROUP BY ROLLUP (f.FACULTY, g.PROFESSION, p.SUBJECT)
-- выведет две строки со среднем значением, итоговую строку по специальности, факультету и всем факультетам