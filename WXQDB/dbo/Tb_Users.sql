CREATE TABLE [dbo].[Tb_Users] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [UserName]       VARCHAR (50)  NOT NULL DEFAULT '',
    [Password]       VARCHAR (100) NOT NULL DEFAULT '',
	   [AddDateTime]    DATETIME      NOT NULL DEFAULT getdate(),
    [UpdateDateTime] DATETIME      NOT NULL DEFAULT getdate(),
    [AddUser]        VARCHAR (50)  NOT NULL DEFAULT '',
    [UpdateUser]     VARCHAR (50)  NOT NULL DEFAULT '',
    [RowVersion]     INT           NOT NULL DEFAULT 0,
    [Introduction] VARCHAR(50) NOT NULL DEFAULT '', 
    [NickName] VARCHAR(50) NOT NULL DEFAULT '', 
    [HeadImage] VARCHAR(100) NOT NULL DEFAULT '', 
	 [RsState] TINYINT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Tb_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'描述', @value = N'用户表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_Users';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_Users', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'用户名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_Users', @level2type = N'COLUMN', @level2name = N'UserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'密码', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_Users', @level2type = N'COLUMN', @level2name = N'Password';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'添加时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_Users', @level2type = N'COLUMN', @level2name = N'AddDateTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'修改时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_Users', @level2type = N'COLUMN', @level2name = N'UpdateDateTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'添加人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_Users', @level2type = N'COLUMN', @level2name = N'AddUser';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'修改人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_Users', @level2type = N'COLUMN', @level2name = N'UpdateUser';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'版本号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_Users', @level2type = N'COLUMN', @level2name = N'RowVersion';


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'介绍',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Users',
    @level2type = N'COLUMN',
    @level2name = N'Introduction'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'昵称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Users',
    @level2type = N'COLUMN',
    @level2name = N'NickName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'头像',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Users',
    @level2type = N'COLUMN',
    @level2name = N'HeadImage'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'用户表',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Tb_Users',
    @level2type = NULL,
    @level2name = NULL