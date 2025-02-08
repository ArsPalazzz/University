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
  
  SELECT count(*)[количество строк] from #EX;
  SELECT * from #EX

  CREATE index #EX_NONCLU on #EX(TKEY, CC)

  SELECT * from  #EX where  TKEY > 1500 and  CC < 4500;  --0.199356
  SELECT * from  #EX order by  TKEY, CC --0.199356

  SELECT * from  #EX where  TKEY = 556 and  CC > 3 --0.0032834


DROP table #EX