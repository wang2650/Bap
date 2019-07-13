/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80016
Source Host           : 127.0.0.1:3306
Source Database       : wxqdb

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2019-07-13 15:20:36
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_dict`
-- ----------------------------
DROP TABLE IF EXISTS `tb_dict`;
CREATE TABLE `tb_dict` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DictKey` varchar(50) DEFAULT NULL,
  `DictValue` varchar(50) DEFAULT NULL,
  `DictType` varchar(50) DEFAULT NULL,
  `CreateTime` timestamp NULL DEFAULT NULL,
  `OrderBy` smallint(6) DEFAULT NULL,
  `CreateUser` varchar(50) DEFAULT NULL,
  `UpdateTime` timestamp NULL DEFAULT NULL,
  `UpdateUser` varchar(50) DEFAULT NULL,
  `Description` varchar(50) DEFAULT NULL,
  `GroupName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_dict
-- ----------------------------
