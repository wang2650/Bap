CREATE TABLE `tb_oplog` (
  `Id` int(10) NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `MethodName` varchar(50) NOT NULL DEFAULT '' COMMENT '方法名称',
  `ControllerName` varchar(50) NOT NULL DEFAULT '' COMMENT '控制器名称',
  `CreateDateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '记录时间',
  `OpUser` int(10) NOT NULL COMMENT '操作人',
  `ParaValue` varchar(6000) NOT NULL DEFAULT '' COMMENT '参数',
  `AppId` int(10) NOT NULL COMMENT '应用id',
  `Ip` varchar(100) NOT NULL DEFAULT '' COMMENT 'IP地址',
  `Brower` varchar(100) NOT NULL DEFAULT '' COMMENT '浏览器',
  `navigator` varchar(100) NOT NULL DEFAULT '' COMMENT '包含有关浏览器的信息',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;