use UNIVER;

CREATE table #EX
(    TKEY int, 
      CC int identity(1, 1), --Атрибут IDENTITY позволяет сделать столбец идентификатором
      TF varchar(100)
);

 set nocount on;           
  declare @i int = 0;
  while   @i < 20000       -- добавление в таблицу 20000 строк
  begin
       INSERT #EX(TKEY, TF) values(floor(30000*RAND()), replicate('строка ', 10));
        set @i = @i + 1; 
  end;

  CREATE index #EX_NONCLU on #EX(TKEY, CC)

	SELECT TKEY from  #EX where TKEY between 5000 and 19999; --0.0343586
	SELECT TKEY from  #EX where TKEY>15000 and  TKEY < 20000  --0.0136609
	SELECT TKEY from  #EX where TKEY=17000 --0.0032836

	 CREATE  index #EX_WHERE on #EX(TKEY) where (TKEY>=15000 and TKEY < 20000); 
	 
	 SELECT TKEY from  #EX where TKEY between 5000 and 19999; --0.0343586
		SELECT TKEY from  #EX where TKEY>15000 and  TKEY < 20000  --0.0077341
		SELECT TKEY from  #EX where TKEY=17000 --0.0032837
 

DROP index #EX_WHERE on #EX
DROP table #EX
