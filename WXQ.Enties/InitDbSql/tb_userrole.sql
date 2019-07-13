/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80016
Source Host           : 127.0.0.1:3306
Source Database       : wxqdb

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2019-07-13 15:22:00
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_userrole`
-- ----------------------------
DROP TABLE IF EXISTS `tb_userrole`;
CREATE TABLE `tb_userrole` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `AddDateTime` timestamp NULL DEFAULT NULL,
  `UpdateDateTime` timestamp NULL DEFAULT NULL,
  `AddUser` varchar(50) DEFAULT NULL,
  `UpdateUser` varchar(50) DEFAULT NULL,
  `RowVersion` int(11) DEFAULT NULL,
  `RsState` tinyint(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_userrole
-- ----------------------------
INSERT INTO `tb_userrole` (`RoleId`
		,`UserId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ('1', '2', '2019-05-30 13:12:09', '2019-05-30 13:12:09', '', '', '0', '1');

