begin TRY
	update PROGRESS set NOTE = 'Несоответствие с типом данных' where NOTE = 9
end TRY
begin CATCH
	print ERROR_NUMBER() -- код последней ошибки
	print ERROR_MESSAGE() -- сообщение об ошибке
	print ERROR_LINE() -- код последней ошибки
	print ERROR_PROCEDURE() -- имя процедуры или NULL
	print ERROR_SEVERITY() -- уровень серьезности ошибки
	print ERROR_STATE() -- метка ошибки
end CATCH