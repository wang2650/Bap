/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80016
Source Host           : 127.0.0.1:3306
Source Database       : wxqdb

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2019-07-13 15:21:34
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_role`
-- ----------------------------
DROP TABLE IF EXISTS `tb_role`;
CREATE TABLE `tb_role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(50) DEFAULT NULL,
  `Description` varchar(50) DEFAULT NULL,
  `AddDateTime` timestamp NULL DEFAULT NULL,
  `UpdateDateTime` timestamp NULL DEFAULT NULL,
  `AddUser` varchar(50) DEFAULT NULL,
  `UpdateUser` varchar(50) DEFAULT NULL,
  `RowVersion` int(11) DEFAULT NULL,
  `RsState` tinyint(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_role
-- ----------------------------
INSERT INTO `tb_role`(`RoleName`
		,`Description`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ('1', '系统管理员', '', '2019-05-30 13:11:27', '2019-05-30 13:11:27', '', '', '0', '1');

