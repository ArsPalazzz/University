-- WAITFOR DELAY '00:00:02';
use UNIVER;

select (case
	when NOTE between 0 and 3 then '�� 0 �� 3'
	when NOTE between 4 and 5 then '�� 4 �� 5'
	when NOTE between 6 and 7 then '�� 6 �� 7'
	when NOTE between 8 and 10 then '�� 8 �� 10'
end) ������, count(*) ���������� from PROGRESS
group by (case
	when NOTE between 0 and 3 then '�� 0 �� 3'
	when NOTE between 4 and 5 then '�� 4 �� 5'
	when NOTE between 6 and 7 then '�� 6 �� 7'
	when NOTE between 8 and 10 then '�� 8 �� 10'
end)