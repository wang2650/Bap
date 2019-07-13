/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80016
Source Host           : 127.0.0.1:3306
Source Database       : wxqdb

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2019-07-13 15:20:45
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_limitip`
-- ----------------------------
DROP TABLE IF EXISTS `tb_limitip`;
CREATE TABLE `tb_limitip` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IPBegin` varchar(20) DEFAULT NULL,
  `IpEnd` varchar(20) DEFAULT NULL,
  `RelationType` smallint(6) DEFAULT NULL,
  `RelationId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_limitip
-- ----------------------------
