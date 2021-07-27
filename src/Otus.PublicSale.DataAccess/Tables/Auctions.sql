CREATE TABLE [dbo].[Auctions](
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Descition] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[StartDate] [datetime] NULL,
	[Duration] [int] NOT NULL,
	[PriceStart] [decimal](18, 2) NOT NULL,
	[PriceStep] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Auctions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

