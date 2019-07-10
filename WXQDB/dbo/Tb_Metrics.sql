CREATE TABLE [dbo].[Tb_Metrics]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MethodName] VARCHAR(100) NOT NULL DEFAULT '', 
    [CreateDateTIme] DATETIME NOT NULL DEFAULT getdate(), 
    [CostTime] INT NOT NULL DEFAULT 0, 
    [AppId] SMALLINT NOT NULL DEFAULT 0
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'主键',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Metrics',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'方法名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Metrics',
    @level2type = N'COLUMN',
    @level2name = 'MethodName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'创建时间',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Metrics',
    @level2type = N'COLUMN',
    @level2name = N'CreateDateTIme'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'执行时长',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Metrics',
    @level2type = N'COLUMN',
    @level2name = N'CostTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'方法度量时间表',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Metrics',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'应用id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Metrics',
    @level2type = N'COLUMN',
    @level2name = N'AppId'