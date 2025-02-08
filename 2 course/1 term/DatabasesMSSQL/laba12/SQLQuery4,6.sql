go
create procedure PASUDITORIUM_INSERT @a char(20), @n varchar(50), @c int = 0, @t char(10)
								   --auditorium,  name,			  capacity,	  type
as
begin
	begin try
		insert into AUDITORIUM(AUDITORIUM,AUDITORIUM_NAME,AUDITORIUM_CAPACITY,AUDITORIUM_TYPE)
					values (@a,@n,@c,@t)
		return 1;
	end try
	begin catch
		print cast(error_number() as varchar(10));
		print cast(error_severity() as varchar(6));
		print error_message();
		return -1;
	end catch
end
go

set nocount on
declare @res int
begin tran
	exec @res = PASUDITORIUM_INSERT @a = '206-1', @t = 'ЛК', @c = 90, @n = '206-1'
	print ' ';
	if @res = 1
	print('Процедура: выполнена')
	else print('Процедура: не выполнена')
rollback

declare @res1 int
begin tran
	exec @res1 = PASUDITORIUM_INSERT @a = '222-1', @t = 'ЛБ-К', @c = 30, @n = '222-1'
	print ' ';
	if @res1 = 1
	print('Процедура: выполнена')
	else print('Процедура: не выполнена')
rollback

drop procedure PASUDITORIUM_INSERT;





--6

go
create procedure PAUDITORIUM_INSERT_TYPE @a_ char(20), @n_ varchar(50), @c_ int = 0, @t_ char(10), @tn_ varchar(50)
as
begin
	declare @err nvarchar(50) = 'Ошибка: '
	declare @rez int
		set transaction isolation level serializable
			begin tran
				begin try
					insert into AUDITORIUM_TYPE values (@t_, @tn_)
						exec @rez = PASUDITORIUM_INSERT @a = @a_, @n = @n_, @c = @c_, @t = @t_
						if (@rez = -1)
							begin
								return -1
							end
				end try
				begin catch
					set @err = @err + error_message()
					raiserror(@err, 11, 1)
					rollback
					return -1
				end catch
			commit tran
		return 1
end
go

declare @rez int
begin tran
exec @rez = PAUDITORIUM_INSERT_TYPE @a_ = '208-1', @n_ = '208-1', @c_ = 90, @t_ = '208-1', @tn_ = 'Для 12 лабы' 
print @rez
if @rez = 1
	select * from AUDITORIUM
	select * from AUDITORIUM_TYPE
rollback
go

drop procedure PAUDITORIUM_INSERT_TYPE;