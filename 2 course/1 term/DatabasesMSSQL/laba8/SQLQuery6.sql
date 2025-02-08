-- WAITFOR DELAY '00:00:02';
use UNIVER;

select (case
	when NOTE between 0 and 3 then 'От 0 до 3'
	when NOTE between 4 and 5 then 'От 4 до 5'
	when NOTE between 6 and 7 then 'От 6 до 7'
	when NOTE between 8 and 10 then 'От 8 до 10'
end) Оценки, count(*) Количество from PROGRESS
group by (case
	when NOTE between 0 and 3 then 'От 0 до 3'
	when NOTE between 4 and 5 then 'От 4 до 5'
	when NOTE between 6 and 7 then 'От 6 до 7'
	when NOTE between 8 and 10 then 'От 8 до 10'
end)