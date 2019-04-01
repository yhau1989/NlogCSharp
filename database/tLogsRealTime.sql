USE [bLogs]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tLogsRealTime](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[Level] [varchar](10) NOT NULL,
	[CallSite] [varchar](500) NOT NULL,
	[Type] [varchar](100) NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[StackTrace] [varchar](1000) NOT NULL,
	[Information] [varchar](1000) NOT NULL,
	[LoggedOnDate] [datetime] NOT NULL,
	[IdTransaction] [varchar](7) NULL,
	[IdTicket] [varchar](7) NULL,
	[DataInput] [varchar](8000) NULL,
	[DataOutput] [varchar](8000) NULL,
	[ProcessedRecords] [varchar](15) NULL,
	[TimeProces] [time](7) NULL,
	[App] [varchar](30) NULL,
	[ValidarError] [bit] NULL,
 CONSTRAINT [pk_logs_] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tLogsRealTime] ADD  CONSTRAINT [df_logs_loggedondatetime]  DEFAULT (getdate()) FOR [LoggedOnDate]
GO


