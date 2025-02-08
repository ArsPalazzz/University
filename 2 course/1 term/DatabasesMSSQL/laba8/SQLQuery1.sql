declare @a char = 'A',
		@b varchar(5) = 'ABCDE',
		@c datetime,
		@d time,
		@e int,
		@f smallint,
		@g tinyint,
		@h numeric(12,5);

set @c = getdate();
--14 или 114 - формат даты "hh:mi:ss:mmmm" (24-часовой формат времени)
set @d = (select convert(varchar(12), getdate(), 114) 'hh:mi:ss:mmm');

select @e = 21122001, @f = 21, @G = 1;

select @a AS varA, @b AS varB, @c AS varC;

print 'time = ' + cast(@d as varchar);
print 'Int = ' + convert(varchar, @e);
print 'Smallint = ' + convert(varchar, @f);
print 'Tinyint = ' + convert(varchar, @g);
print 'Numeric = ' + convert(varchar, @h);