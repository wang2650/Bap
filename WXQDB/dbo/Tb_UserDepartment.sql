CREATE TABLE [dbo].[Tb_UserDepartment]
(
		[Id]   INT           IDENTITY (1, 1) NOT NULL, 
     [UserId] INT NOT NULL DEFAULT 0, 
    [DepartmentId] INT NOT NULL DEFAULT 0, 
	[AddDateTime]    DATETIME      NOT NULL DEFAULT getdate(),
    [UpdateDateTime] DATETIME      NOT NULL DEFAULT getdate(),
    [AddUser]        VARCHAR (50)  NOT NULL DEFAULT '',
    [UpdateUser]     VARCHAR (50)  NOT NULL DEFAULT '',
    [RowVersion]     INT           NOT NULL DEFAULT 0,
	 [RsState] TINYINT NOT NULL DEFAULT 1,
)
