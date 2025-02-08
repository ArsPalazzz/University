use master;
go
create database ServerDB;
create database FirstDB;
create database SecondDB;

go
use ServerDB;
go
select * from dbo.Data;

use FirstDB
go
select * from dbo.Data;

use SecondDB
go
select * from dbo.Data;
--truncate table dbo.Data;
commit;

go
alter login [sa] with DEFAULT_DATABASE=[master]
go
use [master]
go
alter login [sa] with password=N'1234' must_change




ALTER LOGIN [sa] WITH CHECK_EXPIRATION=ON;
GO
ALTER LOGIN [sa] WITH PASSWORD=N'1234', CHECK_POLICY=ON, MUST_CHANGE
GO