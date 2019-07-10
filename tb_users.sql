CREATE TABLE `tb_users` (
  `Id` int(10) NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `UserName` varchar(50) NOT NULL DEFAULT '' COMMENT '用户名',
  `Password` varchar(50) NOT NULL DEFAULT '' COMMENT '密码',
  `AddDateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `UpdateDateTime` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `AddUser` varchar(50) NOT NULL DEFAULT '' COMMENT '添加人',
  `UpdateUser` varchar(50) NOT NULL DEFAULT '' COMMENT '更新人',
  `RowVersion` int(10) NOT NULL COMMENT '版本号',
  `Introduction` varchar(50) NOT NULL DEFAULT '' COMMENT '介绍',
  `NickName` varchar(50) NOT NULL DEFAULT '' COMMENT '昵称',
  `HeadImage` varchar(100) NOT NULL DEFAULT '' COMMENT '头像',
  `RsState` tinyint(3) unsigned NOT NULL COMMENT '记录状态',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
