/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80016
Source Host           : 127.0.0.1:3306
Source Database       : wxqdb

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2019-07-13 15:20:18
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_department`
-- ----------------------------
DROP TABLE IF EXISTS `tb_department`;
CREATE TABLE `tb_department` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ParentId` int(11) DEFAULT NULL,
  `DepartmentName` varchar(50) DEFAULT NULL,
  `Description` varchar(50) DEFAULT NULL,
  `AddDateTime` timestamp NULL DEFAULT NULL,
  `UpdateDateTime` timestamp NULL DEFAULT NULL,
  `AddUser` varchar(50) DEFAULT NULL,
  `UpdateUser` varchar(50) DEFAULT NULL,
  `RowVersion` int(11) DEFAULT NULL,
  `RsState` tinyint(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_department
-- ----------------------------
INSERT INTO `tb_department` 	(`ParentId`
		,`DepartmentName`
		,`Description`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '0', '总公司', '', '2019-06-17 13:52:31', '2019-06-17 13:52:31', '', '', '0', '1');
