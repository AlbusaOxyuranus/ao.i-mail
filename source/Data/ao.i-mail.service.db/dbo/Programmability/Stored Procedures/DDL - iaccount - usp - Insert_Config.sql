if(object_id('dbo.usp_Insert_Config') is not null)
	drop procedure dbo.usp_Insert_Config
go

create procedure dbo.usp_Insert_Config
(	
	@json nvarchar(max)
) as
begin
	insert into dbo.[Config] 
	(
	[key],
	[value],
	[userId],
	create_date
	)
	select 
		[key], 
		[value],
		[userId], 
		getdate()
	from openjson(@json)
	with
	(
		[key] nvarchar(250) N'strict $."Key"',
		[value] nvarchar(250) N'strict $."Value"',
		[userId] int N'strict $."UserId"'
	
	)

	select scope_identity()	
end
go