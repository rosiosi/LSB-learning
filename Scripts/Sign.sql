USE [LSB]
GO

/****** Object:  Table [dbo].[Sign]    Script Date: 7/3/2019 11:54:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sign](
	[SignID] [int] IDENTITY(1,1) NOT NULL,
	[SignVideoPath] [nvarchar](max) NOT NULL,
	[SignLanguage] [nvarchar](20) NOT NULL,
	[SignPoint] [int] NULL,
	[WordID] [int] NOT NULL,
 CONSTRAINT [PK_Sign] PRIMARY KEY CLUSTERED 
(
	[SignID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Sign] ADD  CONSTRAINT [DF_Sign_SignLanguage]  DEFAULT (N'Spanish') FOR [SignLanguage]
GO

ALTER TABLE [dbo].[Sign]  WITH CHECK ADD  CONSTRAINT [FK_Sign_Word] FOREIGN KEY([WordID])
REFERENCES [dbo].[Word] ([WordID])
GO

ALTER TABLE [dbo].[Sign] CHECK CONSTRAINT [FK_Sign_Word]
GO


