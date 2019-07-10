CREATE TABLE [dbo].[Tb_OpLog]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MethodName] VARCHAR(50) NOT NULL DEFAULT '', 
    [ControllerName] VARCHAR(50) NOT NULL DEFAULT '', 
    [CreateDateTime] DATETIME NOT NULL DEFAULT getdate(), 
    [OpUser] INT NOT NULL DEFAULT 0, 
    [ParaValue] VARCHAR(6000) NOT NULL DEFAULT '', 
    [AppId] SMALLINT NOT NULL DEFAULT 0, 
    [Ip] VARCHAR(30) NOT NULL DEFAULT '', 
    [Brower] VARCHAR(200) NOT NULL DEFAULT '', 
    [navigator] VARCHAR(50) NOT NULL DEFAULT ''
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'操作日志表',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_OpLog',
    @level2type = NULL,
    @level2name = NULL