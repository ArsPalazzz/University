use UNIVER;

CREATE table #EX
(    TKEY int, 
      CC int identity(1, 1), --������� IDENTITY ��������� ������� ������� ���������������
      TF varchar(100)
);

 set nocount on;           
  declare @i int = 0;
  while   @i < 20000       -- ���������� � ������� 20000 �����
  begin
       INSERT #EX(TKEY, TF) values(floor(30000*RAND()), replicate('������ ', 10));
        set @i = @i + 1; 
  end;

  CREATE index #EX_NONCLU on #EX(TKEY, CC)

  SELECT * from  #EX where  TKEY > 1500 and  CC < 4500;  --0.199356
  SELECT * from  #EX order by  TKEY, CC --0.199356

  CREATE  index #EX_TKEY_X on #EX(TKEY) INCLUDE (CC)
  SELECT CC from #EX where TKEY>15000 --0.0341985

  DROP table #EX