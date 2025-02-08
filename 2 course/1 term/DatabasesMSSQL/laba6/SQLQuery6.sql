SELECT  f.FACULTY[Факультет], 
    g.PROFESSION[Специальность], 
    p.SUBJECT[Дисциплина],
    round(avg(cast(p.NOTE as float(4))), 2)[Средняя оценка]
  FROM FACULTY f 
  Inner Join GROUPS g ON f.FACULTY = g.FACULTY
  Inner Join STUDENT s ON g.IDGROUP = s.IDGROUP
  Inner Join PROGRESS p ON p.IDSTUDENT = s.IDSTUDENT
  WHERE f.FACULTY IN('ТОВ')
  GROUP BY CUBE (f.FACULTY, g.PROFESSION, p.SUBJECT)