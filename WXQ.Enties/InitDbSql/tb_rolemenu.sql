/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80016
Source Host           : 127.0.0.1:3306
Source Database       : wxqdb

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2019-07-13 15:21:40
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_rolemenu`
-- ----------------------------
DROP TABLE IF EXISTS `tb_rolemenu`;
CREATE TABLE `tb_rolemenu` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` int(11) DEFAULT NULL,
  `MenuId` int(11) DEFAULT NULL,
  `AddDateTime` timestamp NULL DEFAULT NULL,
  `UpdateDateTime` timestamp NULL DEFAULT NULL,
  `AddUser` varchar(50) DEFAULT NULL,
  `UpdateUser` varchar(50) DEFAULT NULL,
  `RowVersion` int(11) DEFAULT NULL,
  `RsState` tinyint(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1036 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_rolemenu
-- ----------------------------
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ('1', '1', '2019-05-30 13:20:21', '2019-05-30 13:20:21', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '1', '2', '2019-05-30 13:20:24', '2019-05-30 13:20:24', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '1', '3', '2019-05-30 13:20:27', '2019-05-30 13:20:27', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '1', '4', '2019-05-30 13:20:29', '2019-05-30 13:20:29', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ('5', '1', '5', '2019-05-30 13:20:33', '2019-05-30 13:20:33', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '1', '6', '2019-05-30 13:20:35', '2019-05-30 13:20:35', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '1', '7', '2019-05-30 13:20:38', '2019-05-30 13:20:38', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ('1', '8', '2019-05-30 13:20:43', '2019-05-30 13:20:43', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ('1', '9', '2019-06-12 13:16:58', '2019-06-12 13:16:58', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '1', '10', '2019-06-12 13:17:03', '2019-06-12 13:17:03', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '1', '11', '2019-06-12 13:17:08', '2019-06-12 13:17:08', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '1', '12', '2019-06-15 10:14:24', '2019-06-15 10:14:24', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '1', '13', '2019-06-15 10:14:31', '2019-06-15 10:14:31', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ('1014', '1', '14', '2019-06-19 14:46:54', '2019-06-19 14:46:54', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '1', '15', '2019-06-19 14:47:04', '2019-06-19 14:47:04', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '5', '1', '2019-06-19 16:27:51', '2019-06-19 16:27:51', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '5', '2', '2019-06-19 16:27:56', '2019-06-19 16:27:56', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '5', '3', '2019-06-19 16:28:03', '2019-06-19 16:28:03', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`)VALUES ( '5', '4', '2019-06-19 16:28:10', '2019-06-19 16:28:10', '', '', '0', '1');
INSERT INTO `tb_rolemenu` (`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '2', '6', '2019-06-20 11:22:49', '2019-06-20 11:22:49', '2', '', '0', '1');
INSERT INTO `tb_rolemenu`(`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '2', '7', '2019-06-20 11:22:49', '2019-06-20 11:23:04', '2', '', '0', '1');
INSERT INTO `tb_rolemenu`(`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '2', '8', '2019-06-20 11:22:49', '2019-06-20 11:23:05', '2', '', '0', '1');
INSERT INTO `tb_rolemenu`(`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '2', '4', '2019-06-20 11:22:49', '2019-06-20 11:23:06', '2', '', '0', '1');
INSERT INTO `tb_rolemenu`(`RoleId`
		,`MenuId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`RsState`) VALUES ( '1', '16', '2019-07-01 16:03:47', '2019-07-01 16:03:47', '', '', '0', '1');
