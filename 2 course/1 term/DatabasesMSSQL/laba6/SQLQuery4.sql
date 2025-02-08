USE UNIVER;
/* ���������� ������� CAST ������������ � ������� ��� �������� �������� � ������������ �����. */
/* ������� ROUND ������������ ������ �������� � ��������� �� ���� ������ ����� �������: */

SELECT  f.FACULTY[���������], /* ������ ����� ���� ����� ��������� (����� �����, ��� �������, f,g - ) */
    g.PROFESSION[�������������], 
    g.YEAR_FIRST[��� �����������],
    round(avg(cast(p.NOTE as float(4))),2)[������� ������]  /* ������� ������� */
  FROM FACULTY f 
  Inner Join GROUPS g ON f.FACULTY = g.FACULTY
  Inner Join STUDENT s ON g.IDGROUP = s.IDGROUP
  Inner Join PROGRESS p ON p.IDSTUDENT = s.IDSTUDENT
  GROUP BY f.FACULTY, g.PROFESSION, g.YEAR_FIRST
  ORDER BY [������� ������] desc;

/* �4(�) */
-- �������� ������ �������������� ������ ������ �� ����������� � ������ �� � ����
USE UNIVER;
SELECT  f.FACULTY[���������], 
    g.PROFESSION[�������������], 
    g.YEAR_FIRST[��� �����������],
    round(avg(cast(p.NOTE as float(4))),2)[������� ������]
  FROM FACULTY f 
  Inner Join GROUPS g ON f.FACULTY = g.FACULTY
  Inner Join STUDENT s ON g.IDGROUP = s.IDGROUP
  Inner Join PROGRESS p ON p.IDSTUDENT = s.IDSTUDENT
  WHERE p.SUBJECT IN('��', '����')
  GROUP BY f.FACULTY, g.PROFESSION, g.YEAR_FIRST
  ORDER BY [������� ������] desc;