﻿CREATE TABLE [dbo].[Tb_MenuPageElement]
(
	[Id]   INT           IDENTITY (1, 1) NOT NULL, 
     [MenuId] INT NOT NULL DEFAULT 0, 
    [ElementName] VARCHAR (50)  NOT NULL DEFAULT '',
	 [Description] VARCHAR (50)  NOT NULL DEFAULT '',
	[AddDateTime]    DATETIME      NOT NULL DEFAULT getdate(),
    [UpdateDateTime] DATETIME      NOT NULL DEFAULT getdate(),
    [AddUser]        VARCHAR (50)  NOT NULL DEFAULT '',
    [UpdateUser]     VARCHAR (50)  NOT NULL DEFAULT '',
    [RowVersion]     INT           NOT NULL DEFAULT 0,
	 [RsState] TINYINT NOT NULL DEFAULT 1,
)
