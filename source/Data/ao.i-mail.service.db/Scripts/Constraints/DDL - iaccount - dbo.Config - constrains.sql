if object_id('DF_Config_modified_date') is not null
	alter table dbo.[Config]
		drop constraint DF_Config_modified_date
go

alter table dbo.[Config]
	add constraint DF_Config_modified_date default (getdate()) for modified_date

GO


