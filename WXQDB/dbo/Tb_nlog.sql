CREATE TABLE [dbo].[Tb_nlog] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Application] VARCHAR (50)   NOT NULL DEFAULT '',
    [Logged]      DATETIME       DEFAULT (getdate()) NOT NULL,
    [Level]       VARCHAR (50)   NOT NULL DEFAULT '',
    [Message]     VARCHAR (3000) NOT NULL DEFAULT '',
    [Logger]      VARCHAR (100)  NOT NULL DEFAULT '',
    [CallSite]    VARCHAR (100)  NOT NULL DEFAULT '',
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



GO

GO

GO

GO

GO

GO

GO

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'nlog日志表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_nlog';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志内容', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_nlog', @level2type = N'COLUMN', @level2name = N'Message';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_nlog', @level2type = N'COLUMN', @level2name = N'Logger';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_nlog', @level2type = N'COLUMN', @level2name = N'Logged';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志级别', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_nlog', @level2type = N'COLUMN', @level2name = N'Level';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'id主键', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_nlog', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'调用位置', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_nlog', @level2type = N'COLUMN', @level2name = N'CallSite';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'应用名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tb_nlog', @level2type = N'COLUMN', @level2name = N'Application';

