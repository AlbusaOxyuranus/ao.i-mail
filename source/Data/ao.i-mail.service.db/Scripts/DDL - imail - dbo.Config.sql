if object_id('dbo.Config', 'U') is not null
	drop table dbo.[Config] 

create table dbo.[Config]
(
	[configId] int not null identity(1,1),
	[userId] int not null,
	[key] NVARCHAR(100) not null,
	[value] NVARCHAR(max) not null,
	create_date datetime,
	modified_date datetime,
	CONSTRAINT [PK_Config] PRIMARY KEY CLUSTERED 
(
	[configId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

go