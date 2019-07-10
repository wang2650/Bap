CREATE TABLE `tb_role` (
  `Id` int(10) NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `RoleName` varchar(50) NOT NULL DEFAULT '' COMMENT '角色名',
  `Description` varchar(50) NOT NULL DEFAULT '' COMMENT '描述',
  `AddDateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `UpdateDateTime` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `AddUser` varchar(50) NOT NULL DEFAULT '' COMMENT '添加人',
  `UpdateUser` varchar(50) NOT NULL DEFAULT '' COMMENT '更新人',
  `RowVersion` int(10) NOT NULL COMMENT '版本号',
  `RsState` tinyint(3) unsigned NOT NULL COMMENT '记录状态',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;