CREATE TABLE [dbo].[AuctionFiles](
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[AuctionId] [int] NOT NULL,
	[FileName] [nvarchar](50) NOT NULL,
	[Path] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_AuctionsFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AuctionFiles]  WITH CHECK ADD  CONSTRAINT [FK_AuctionsFiles_Auctions] FOREIGN KEY([AuctionId])
REFERENCES [dbo].[Auctions] ([Id])
GO

ALTER TABLE [dbo].[AuctionFiles] CHECK CONSTRAINT [FK_AuctionsFiles_Auctions]
GO

