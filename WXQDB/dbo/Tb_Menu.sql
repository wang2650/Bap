CREATE TABLE [dbo].[Tb_Menu]
(
	[Id]   INT           IDENTITY (1, 1) NOT NULL, 
    [MenuName] VARCHAR(50) NOT NULL DEFAULT '', 
    [Description] VARCHAR(50) NOT NULL DEFAULT '', 
    [ParentId] INT NOT NULL DEFAULT 0, 
	[AddDateTime]    DATETIME      NOT NULL DEFAULT getdate(),
    [UpdateDateTime] DATETIME      NOT NULL DEFAULT getdate(),
    [AddUser]        VARCHAR (50)  NOT NULL DEFAULT '',
    [UpdateUser]     VARCHAR (50)  NOT NULL DEFAULT '',
    [RowVersion]     INT           NOT NULL DEFAULT 0, 
    [MenuType] TINYINT NOT NULL DEFAULT 1, 
    [Url] VARCHAR(100) NOT NULL DEFAULT '', 
    [RsState] TINYINT NOT NULL DEFAULT 1, 
    [Icon] VARCHAR(50) NOT NULL DEFAULT '',
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'菜单类型',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Menu',
    @level2type = N'COLUMN',
    @level2name = N'MenuType'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'链接地址',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Menu',
    @level2type = N'COLUMN',
    @level2name = N'Url'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'记录状态',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Menu',
    @level2type = N'COLUMN',
    @level2name = N'RsState'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'地址',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Menu',
    @level2type = N'COLUMN',
    @level2name = N'Icon'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'菜单名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Menu',
    @level2type = N'COLUMN',
    @level2name = N'MenuName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'描述',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Menu',
    @level2type = N'COLUMN',
    @level2name = N'Description'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'上级id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Menu',
    @level2type = N'COLUMN',
    @level2name = N'ParentId'