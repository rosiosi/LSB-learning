USE [LSB]
GO

/****** Object:  Table [dbo].[LearningAdvance]    Script Date: 7/3/2019 11:53:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LearningAdvance](
	[LearningID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[SignID] [int] NOT NULL,
 CONSTRAINT [PK_LearningAdvance] PRIMARY KEY CLUSTERED 
(
	[LearningID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[LearningAdvance]  WITH CHECK ADD  CONSTRAINT [FK_LearningAdvance_Sign] FOREIGN KEY([SignID])
REFERENCES [dbo].[Sign] ([SignID])
GO

ALTER TABLE [dbo].[LearningAdvance] CHECK CONSTRAINT [FK_LearningAdvance_Sign]
GO

ALTER TABLE [dbo].[LearningAdvance]  WITH CHECK ADD  CONSTRAINT [FK_LearningAdvance_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserCI])
GO

ALTER TABLE [dbo].[LearningAdvance] CHECK CONSTRAINT [FK_LearningAdvance_User]
GO


