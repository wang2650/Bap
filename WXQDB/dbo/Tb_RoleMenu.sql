CREATE TABLE [dbo].[Tb_RoleMenu]
(
		[Id]   INT           IDENTITY (1, 1) NOT NULL, 
     [RoleId] INT NOT NULL DEFAULT 0, 
    [MenuId] INT NOT NULL DEFAULT 0, 
	[AddDateTime]    DATETIME      NOT NULL DEFAULT getdate(),
    [UpdateDateTime] DATETIME      NOT NULL DEFAULT getdate(),
    [AddUser]        VARCHAR (50)  NOT NULL DEFAULT '',
    [UpdateUser]     VARCHAR (50)  NOT NULL DEFAULT '',
    [RowVersion]     INT           NOT NULL DEFAULT 0,
	 [RsState] TINYINT NOT NULL DEFAULT 1,
)
