CREATE TABLE [dbo].[Tb_DepartmentRole]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoleId] INT NOT NULL, 
    [DepartmentId] INT NOT NULL,
    [AddDateTime]    DATETIME      NOT NULL DEFAULT getdate(),
    [UpdateDateTime] DATETIME      NOT NULL DEFAULT getdate(),
    [AddUser]        VARCHAR (50)  NOT NULL DEFAULT '',
    [UpdateUser]     VARCHAR (50)  NOT NULL DEFAULT '',
    [RowVersion]     INT           NOT NULL DEFAULT 0,
	 [RsState] TINYINT NOT NULL DEFAULT 1,
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_DepartmentRole',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO

CREATE INDEX [IX_Tb_DepartmentRole_Column] ON [dbo].[Tb_DepartmentRole] ([DepartmentId])

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'角色id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_DepartmentRole',
    @level2type = N'COLUMN',
    @level2name = N'RoleId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'部门id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_DepartmentRole',
    @level2type = N'COLUMN',
    @level2name = N'DepartmentId'