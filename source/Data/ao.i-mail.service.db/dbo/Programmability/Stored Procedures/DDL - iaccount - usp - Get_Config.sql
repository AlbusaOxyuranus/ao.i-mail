if(object_id('dbo.usp_Get_Config') is not null)
	drop procedure dbo.usp_Get_Config
go

create procedure dbo.usp_Get_Config
(	
	@id int
) as
begin
	
	select top (1) u.[configId] as Id, u.[key] as [key], u.[value] as [value]  from dbo.[Config] as u where u.[configId]= @id
	for json path
end
go