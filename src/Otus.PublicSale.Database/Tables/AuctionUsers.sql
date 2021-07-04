CREATE TABLE [dbo].[AuctionUsers](
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[AuctionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_AuctionsUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AuctionUsers]  WITH CHECK ADD  CONSTRAINT [FK_AuctionsUsers_Auctions] FOREIGN KEY([AuctionId])
REFERENCES [dbo].[Auctions] ([Id])
GO

ALTER TABLE [dbo].[AuctionUsers] CHECK CONSTRAINT [FK_AuctionsUsers_Auctions]
GO

ALTER TABLE [dbo].[AuctionUsers]  WITH CHECK ADD  CONSTRAINT [FK_AuctionsUsers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[AuctionUsers] CHECK CONSTRAINT [FK_AuctionsUsers_Users]
GO

