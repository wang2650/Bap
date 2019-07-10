CREATE TABLE [dbo].[Tb_Department]
(
		[Id]   INT           IDENTITY (1, 1) NOT NULL, 
     [ParentId] INT NOT NULL DEFAULT 0, 
    [DepartmentName] VARCHAR (50)  NOT NULL DEFAULT '',
	 [Description] VARCHAR (50)  NULL DEFAULT '',
	[AddDateTime]    DATETIME      NOT NULL DEFAULT getdate(),
    [UpdateDateTime] DATETIME      NOT NULL DEFAULT getdate(),
    [AddUser]        VARCHAR (50)  NOT NULL DEFAULT '',
    [UpdateUser]     VARCHAR (50)  NOT NULL DEFAULT '',
    [RowVersion]     INT           NOT NULL DEFAULT 0, 
	 [RsState] TINYINT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Tb_Department] PRIMARY KEY ([Id]),
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'上一级部门id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Department',
    @level2type = N'COLUMN',
    @level2name = N'ParentId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'部门名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Department',
    @level2type = N'COLUMN',
    @level2name = N'DepartmentName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'描述',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Department',
    @level2type = N'COLUMN',
    @level2name = N'Description'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'添加时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Department',
    @level2type = N'COLUMN',
    @level2name = N'AddDateTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'更新时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Department',
    @level2type = N'COLUMN',
    @level2name = N'UpdateDateTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'添加人',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Department',
    @level2type = N'COLUMN',
    @level2name = N'AddUser'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'更新人',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Department',
    @level2type = N'COLUMN',
    @level2name = N'UpdateUser'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'版本号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Department',
    @level2type = N'COLUMN',
    @level2name = N'RowVersion'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'部门表',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Department',
    @level2type = NULL,
    @level2name = NULL