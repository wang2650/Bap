SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_metrics`
-- ----------------------------
DROP TABLE IF EXISTS `tb_metrics`;
CREATE TABLE `tb_metrics` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `MethodName` varchar(100) DEFAULT NULL,
  `CreateDateTIme` timestamp NULL DEFAULT NULL,
  `CostTime` int(11) DEFAULT NULL,
  `AppId` smallint(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2149 DEFAULT CHARSET=utf8;