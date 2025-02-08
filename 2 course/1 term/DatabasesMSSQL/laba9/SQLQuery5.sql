use tempdb;

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


CREATE   index #EX_TKEY ON #EX(TKEY); 
SELECT name [������], avg_fragmentation_in_percent [������������ (%)]
        FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'), 
        OBJECT_ID(N'#EX'), NULL, NULL, NULL) ss
        JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  
        WHERE name is not null;

INSERT top(10000) #EX(TKEY, TF) select TKEY, TF from #EX;

SELECT name [������], avg_fragmentation_in_percent [������������ (%)]
        FROM sys.dm_db_index_physical_stats(DB_ID(N'TEMPDB'), 
        OBJECT_ID(N'#EX'), NULL, NULL, NULL) as ss
        JOIN sys.indexes as ii 
			on ss.object_id = ii.object_id and ss.index_id = ii.index_id  
        WHERE name is not null;

ALTER index #EX_TKEY on #EX reorganize; --������������� (-����� �� ������)
ALTER index #EX_TKEY on #EX rebuild with (online = off); --(������ ����� �������) �������� ����� ��� ������ => �����=0

DROP index #EX_TKEY on #EX
DROP table #EX