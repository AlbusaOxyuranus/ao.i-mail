DECLARE @dbname nvarchar(128)= N'i-mail-tests.db';
declare @sql nvarchar(max)

if(EXISTS(select name from master.dbo.sysdatabases where ('['+name+']'= @dbname or name=@dbname)))
BEGIN
	set @sql = 'drop database ' + QUOTENAME(@dbname)
	exec (@sql)
END;
set @sql = 'create database ' + QUOTENAME(@dbname)

exec (@sql)
print 'db exists';
go

DECLARE @dbname nvarchar(128)= N'i-mail.db';
declare @sql nvarchar(max)

if(EXISTS(select name from master.dbo.sysdatabases where ('['+name+']'= @dbname or name=@dbname)))
BEGIN
	set @sql = 'drop database ' + QUOTENAME(@dbname)
	exec (@sql)
END;
set @sql = 'create database ' + QUOTENAME(@dbname)

exec (@sql)
print 'db exists';
go