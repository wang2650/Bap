CREATE TABLE `tb_dict` (
  `Id` int(10) NOT NULL AUTO_INCREMENT COMMENT 'Id',
  `DictKey` varchar(50) NOT NULL DEFAULT '' COMMENT '字典key',
  `DictValue` varchar(50) NOT NULL DEFAULT '' COMMENT '字典值',
  `DictType` varchar(50) NOT NULL DEFAULT '' COMMENT '数据类型',
  `CreateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '添加时间',
  `OrderBy` int(10) NOT NULL COMMENT '排序',
  `CreateUser` varchar(50) NOT NULL DEFAULT '' COMMENT '创建者',
  `UpdateTime` datetime DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `UpdateUser` varchar(50) NOT NULL DEFAULT '' COMMENT '更新人',
  `Description` varchar(50) NOT NULL DEFAULT '' COMMENT '描述',
  `GroupName` varchar(50) NOT NULL DEFAULT '' COMMENT '分组名称',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
