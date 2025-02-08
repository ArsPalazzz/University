-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
USE UNIVER
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
set nocount on
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[PSUBJECT] @p varchar(20) = NULL, @c int output 
AS
BEGIN
	declare @k int = (select COUNT(*) from SUBJECT where PULPIT = @p);
	print 'Параметры: @p = ' + @p + ', @c = ' + cast(@c as varchar(3));
	select SUBJECT [Код], SUBJECT_NAME [Дисциплина], PULPIT [Кафедра] from SUBJECT where PULPIT = @p;
	set @c = @@rowcount;
	return @k;
END

declare @y int = 0, @z varchar(20) = 'ИСИТ', @w int = 0
exec @y = PSUBJECT @p = @z, @c = @w output
print 'Всего строк: ' + cast(@y as nvarchar)
print 'Строк с факультетом ' + @z + ': '+ cast(@w as nvarchar)
GO
