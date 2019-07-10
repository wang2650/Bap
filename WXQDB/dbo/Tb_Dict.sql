CREATE TABLE [dbo].[Tb_Dict]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DictKey] VARCHAR(50) NOT NULL DEFAULT '', 
    [DictValue] VARCHAR(200) NOT NULL DEFAULT '', 
    [DictType] VARCHAR(50) NOT NULL DEFAULT '', 
    [CreateTime] DATETIME NOT NULL DEFAULT getdate(), 
    [OrderBy] SMALLINT NOT NULL DEFAULT 0, 
    [CreateUser] VARCHAR(50) NOT NULL DEFAULT '', 
    [UpdateTime] DATETIME NOT NULL DEFAULT getdate(), 
    [UpdateUser] VARCHAR(50) NOT NULL DEFAULT '', 
    [Description] VARCHAR(50) NOT NULL DEFAULT '', 
    [GroupName] VARCHAR(50) NOT NULL DEFAULT ''
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Dict',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'字典的key',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Dict',
    @level2type = N'COLUMN',
    @level2name = N'DictKey'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'字典的值',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Dict',
    @level2type = N'COLUMN',
    @level2name = N'DictValue'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'字典类型',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Dict',
    @level2type = N'COLUMN',
    @level2name = N'DictType'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'创建时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Dict',
    @level2type = N'COLUMN',
    @level2name = N'CreateTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'排序',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Dict',
    @level2type = N'COLUMN',
    @level2name = N'OrderBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'创建人',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Dict',
    @level2type = N'COLUMN',
    @level2name = N'CreateUser'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'更新时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Dict',
    @level2type = N'COLUMN',
    @level2name = N'UpdateTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'更新人',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Dict',
    @level2type = N'COLUMN',
    @level2name = N'UpdateUser'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'描述',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Dict',
    @level2type = N'COLUMN',
    @level2name = N'Description'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'分组组名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Dict',
    @level2type = N'COLUMN',
    @level2name = N'GroupName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'字典表',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Dict',
    @level2type = NULL,
    @level2name = NULL
GO

CREATE INDEX [IX_Tb_Dict_group] ON [dbo].[Tb_Dict] ([GroupName])
