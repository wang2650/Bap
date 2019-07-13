/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80016
Source Host           : 127.0.0.1:3306
Source Database       : wxqdb

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2019-07-13 15:21:53
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_userextendinfo`
-- ----------------------------
DROP TABLE IF EXISTS `tb_userextendinfo`;
CREATE TABLE `tb_userextendinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `TelePhone` varchar(20) DEFAULT NULL,
  `RelationPerson` varchar(20) DEFAULT NULL,
  `Url` varchar(100) DEFAULT NULL,
  `UserKey` tinyint(4) DEFAULT NULL,
  `Sex` tinyint(4) DEFAULT NULL,
  `Sequence` smallint(6) DEFAULT NULL,
  `IsMustUseKey` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_userextendinfo
-- ----------------------------
