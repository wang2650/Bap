CREATE TABLE `tb_menu` (
  `Id` int(10) NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `MenuName` varchar(50) NOT NULL DEFAULT '' COMMENT '菜单名称',
  `Description` varchar(50) NOT NULL DEFAULT '' COMMENT '描述',
  `ParentId` int(10) NOT NULL COMMENT '上级id',
  `AddDateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `UpdateDateTime` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `AddUser` varchar(50) NOT NULL DEFAULT '' COMMENT '添加人',
  `UpdateUser` varchar(50) NOT NULL DEFAULT '' COMMENT '更新人',
  `RowVersion` int(10) NOT NULL COMMENT '版本号',
  `MenuType` int(10) NOT NULL COMMENT '菜单类型',
  `Url` varchar(50) NOT NULL DEFAULT '' COMMENT '地址',
  `RsState` tinyint(3) unsigned NOT NULL COMMENT '记录状态',
  `Icon` varchar(50) NOT NULL DEFAULT '' COMMENT '图标',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
