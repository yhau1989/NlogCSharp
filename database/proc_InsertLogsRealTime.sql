USE [bLogs]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[proc_InsertLogsRealTime](
	@level varchar(100),
	@callSite varchar(1000),
	@type varchar(20),
	@message varchar(1000),
	@stackTrace varchar(1000) = null,
	@information varchar(2000),
	@idtransaction varchar(7) = null,
	@idticket varchar(7) = null,
	@dataInput varchar(max) = null,
	@dataOutput varchar(1000) = null,
	@processedRecords varchar(1000) = null,
	@timeProces time = null,
	@app varchar(30) = null,
	@validarError bit = null
	)
with execute as 'SQLOWNER'
AS 
	BEGIN TRY
		IF @validarError IS NULL
			set @validarError = 0


			insert into dbo.tLogsHybrisRealTime
			(
				[Level],
				CallSite,
				[Type],
				[Message],
				StackTrace,
				Information,
				IdTransaction,
				IdTicket,
				LoggedOnDate,
				DataInput,
				DataOutput,
				ProcessedRecords,
				TimeProces,
				App,
				ValidarError
			)
			values
			(
				@level,
				@callSite,
				@type,
				@message,
				@stackTrace,
				@information,
				@idtransaction,
				@idticket,
				sysdatetime(),
				@dataInput,
				@dataOutput,
				@processedRecords,
				@timeProces,
				@app,
				@validarError
			)


	END TRY
	BEGIN CATCH
		THROW 90000,'ERROR SP proc_InsertLogsHybrisRealTime ',1
	END CATCH
