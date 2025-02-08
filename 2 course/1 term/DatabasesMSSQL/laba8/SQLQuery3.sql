PRINT 'Rowcount is ' + cast(@@ROWCOUNT as varchar(10));  
PRINT 'Version is ' + cast(@@VERSION as varchar(180))
PRINT 'Spid is ' + cast(@@SPID as varchar(10))
PRINT 'Error is ' + cast(@@ERROR as varchar(10));  
PRINT 'Servarname is ' + cast(@@SERVERNAME as varchar(20))
PRINT 'Trancount is ' + cast(@@TRANCOUNT as varchar(10))
PRINT 'Fetch status is ' + cast(@@FETCH_STATUS as varchar(10));  
PRINT 'Nest level is ' + cast(@@NESTLEVEL as varchar(10))
