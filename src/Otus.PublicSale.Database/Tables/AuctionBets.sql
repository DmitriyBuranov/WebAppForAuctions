CREATE TABLE [dbo].[AuctionBets](
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[AuctionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Bets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AuctionBets]  WITH CHECK ADD  CONSTRAINT [FK_Bets_Auctions] FOREIGN KEY([AuctionId])
REFERENCES [dbo].[Auctions] ([Id])
GO

ALTER TABLE [dbo].[AuctionBets] CHECK CONSTRAINT [FK_Bets_Auctions]
GO

ALTER TABLE [dbo].[AuctionBets]  WITH CHECK ADD  CONSTRAINT [FK_Bets_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[AuctionBets] CHECK CONSTRAINT [FK_Bets_Users]
GO

