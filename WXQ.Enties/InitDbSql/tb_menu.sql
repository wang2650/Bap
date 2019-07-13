/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80016
Source Host           : 127.0.0.1:3306
Source Database       : wxqdb

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2019-07-13 15:20:51
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_menu`
-- ----------------------------
DROP TABLE IF EXISTS `tb_menu`;
CREATE TABLE `tb_menu` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `MenuName` varchar(50) DEFAULT NULL,
  `Description` varchar(50) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL,
  `AddDateTime` timestamp NULL DEFAULT NULL,
  `UpdateDateTime` timestamp NULL DEFAULT NULL,
  `AddUser` varchar(50) DEFAULT NULL,
  `UpdateUser` varchar(50) DEFAULT NULL,
  `RowVersion` int(11) DEFAULT NULL,
  `MenuType` tinyint(11) DEFAULT NULL,
  `Url` varchar(100) DEFAULT NULL,
  `RsState` tinyint(11) DEFAULT NULL,
  `Icon` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_menu
-- ----------------------------
INSERT INTO `tb_menu` (`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ( '系统首页', '', '0', '2019-05-30 13:05:46', '2019-05-30 13:05:46', '', '', '0', '1', 'dashboard', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ('基础表格', '', '0', '2019-05-30 13:06:01', '2019-05-30 13:06:01', '', '', '0', '1', 'table', '1', 'el-icon-menu');
INSERT INTO `tb_menu` (`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`)VALUES ('tab选项卡', '', '0', '2019-05-30 13:06:34', '2019-05-30 13:06:34', '', '', '0', '1', 'tabs', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ('表单相关', '', '0', '2019-05-30 13:06:37', '2019-05-30 13:06:37', '', '', '0', '1', '', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ('基本表单', '', '4', '2019-05-30 13:07:43', '2019-05-30 13:07:43', '', '', '0', '1', 'form', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ('三级菜单', '', '4', '2019-05-30 13:07:52', '2019-05-30 13:07:52', '', '', '0', '1', '', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ('富文本编辑器', '', '6', '2019-05-30 13:08:41', '2019-05-30 13:08:41', '', '', '0', '1', 'editor', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ('markdown编辑器', '', '6', '2019-05-30 13:09:00', '2019-05-30 13:09:00', '', '', '0', '1', 'markdown', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ('系统管理', '', '0', '2019-06-12 13:13:31', '2019-06-12 13:13:31', '', '', '0', '1', '', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ( '用户', '', '9', '2019-06-12 13:14:02', '2019-06-12 13:14:02', '', '', '0', '1', '', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ( '用户管理', '', '10', '2019-06-12 13:15:15', '2019-06-12 13:15:15', '', '', '0', '1', 'usermanage', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ( '角色管理', '', '9', '2019-06-15 10:13:45', '2019-06-15 10:13:45', '', '', '0', '1', '', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ( '角色', '', '12', '2019-06-15 10:14:02', '2019-06-15 10:14:02', '', '', '0', '1', 'rolemanage', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ( '部门', '', '9', '2019-06-19 14:46:20', '2019-06-19 14:46:20', '', '', '0', '1', '', '1', 'el-icon-menu');
INSERT INTO `tb_menu` (`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`)VALUES ( '部门管理', '', '14', '2019-06-19 14:46:30', '2019-06-19 14:46:30', '', '', '0', '1', 'departmentmanage', '1', 'el-icon-menu');
INSERT INTO `tb_menu`(`MenuName`
		,`Description`
		,`ParentId`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`MenuType`
		,`Url`
		,`RsState`
		,`Icon`) VALUES ( '我的首页', '', '0', '2019-07-01 16:03:18', '2019-07-01 16:03:18', '', '', '0', '1', 'myselfinfo', '1', 'el-icon-menu');
