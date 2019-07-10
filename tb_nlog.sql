CREATE TABLE `tb_nlog` (
  `Id` int(10) NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `Application` varchar(50) NOT NULL DEFAULT '' COMMENT '应用名称',
  `Logged` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '记录时间',
  `Level` varchar(50) NOT NULL DEFAULT '' COMMENT '级别',
  `Message` varchar(3000) NOT NULL DEFAULT '' COMMENT '消息',
  `Logger` varchar(100) NOT NULL DEFAULT '' COMMENT '日志',
  `CallSite` varchar(100) NOT NULL DEFAULT '' COMMENT '站点',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
