CREATE TABLE `tb_metrics` (
  `Id` int(10) NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `MethodName` varchar(50) NOT NULL DEFAULT '' COMMENT '方法名称',
  `CreateDateTIme` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `CostTime` int(10) NOT NULL COMMENT '消耗时间',
  `AppId` tinyint(3) unsigned NOT NULL COMMENT '应用id',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
