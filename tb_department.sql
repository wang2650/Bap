/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80016
Source Host           : 127.0.0.1:3306
Source Database       : wxqdb

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2019-07-13 15:14:55
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
INSERT INTO `tb_department` VALUES ('1', '0', '总公司', '', '2019-06-17 13:52:31', '2019-06-17 13:52:31', '', '', '0', '1');
INSERT INTO `tb_department` VALUES ('2', '1', '财务部', '', '2019-06-19 14:03:00', '2019-06-19 14:03:00', '', '', '0', '1');
INSERT INTO `tb_department` VALUES ('3', '1', '人事部', '', '2019-06-19 14:03:12', '2019-06-19 14:03:12', '', '', '0', '1');
INSERT INTO `tb_department` VALUES ('4', '1', '技术部', '', '2019-06-19 14:03:29', '2019-06-19 14:03:29', '', '', '0', '1');
INSERT INTO `tb_department` VALUES ('5', '4', '电梯', '', '2019-06-19 14:03:53', '2019-06-19 14:03:53', '', '', '0', '1');
INSERT INTO `tb_department` VALUES ('6', '4', '楼梯部', '', '2019-06-19 14:04:05', '2019-06-19 14:04:05', '', '', '0', '1');
INSERT INTO `tb_department` VALUES ('7', '1', 'xiaceshi', 'aaaaa', '2019-07-11 15:19:14', null, '2', null, null, null);
