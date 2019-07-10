CREATE TABLE `tb_department` (
  `Id` int(10) NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `ParentId` int(10) NOT NULL COMMENT '上级id',
  `DepartmentName` varchar(50) NOT NULL COMMENT '部门名称',
  `Description` varchar(100) NOT NULL COMMENT '描述',
  `AddDateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `UpdateDateTime` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `AddUser` varchar(50) NOT NULL DEFAULT '' COMMENT '添加人',
  `UpdateUser` varchar(50) NOT NULL DEFAULT '' COMMENT '更新人',
  `RowVersion` int(10) NOT NULL COMMENT '版本号',
  `RsState` tinyint(3) unsigned NOT NULL COMMENT '记录状态',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
