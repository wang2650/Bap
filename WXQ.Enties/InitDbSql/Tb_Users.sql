/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80016
Source Host           : 127.0.0.1:3306
Source Database       : wxqdb

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2019-07-13 15:22:07
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_users`
-- ----------------------------
DROP TABLE IF EXISTS `tb_users`;
CREATE TABLE `tb_users` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `UserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '用户名',
  `Password` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '密码',
  `AddDateTime` timestamp NULL DEFAULT NULL,
  `UpdateDateTime` timestamp NULL DEFAULT NULL,
  `AddUser` varchar(50) DEFAULT NULL,
  `UpdateUser` varchar(50) DEFAULT NULL,
  `RowVersion` int(11) DEFAULT NULL,
  `Introduction` varchar(50) DEFAULT NULL,
  `NickName` varchar(50) DEFAULT NULL,
  `HeadImage` varchar(100) DEFAULT NULL,
  `RsState` tinyint(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1015 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_users
-- ----------------------------
INSERT INTO `tb_users` (`UserName`
		,`Password`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`Introduction`
		,`NickName`
		,`HeadImage`
		,`RsState`) VALUES ( 'administrator', 'e0662446dc3e1fe50801cae1b6e01b336263a9772cafe5abbf7ae677ae61c5e9', '2019-05-16 15:35:24', '2019-07-02 10:48:40', '', '2', '1', '系统管理员tttt', '超管', '0', '1');
INSERT INTO `tb_users` (`UserName`
		,`Password`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`Introduction`
		,`NickName`
		,`HeadImage`
		,`RsState`) VALUES ( 'aaaaazsaa', '7b3524baed5914cd28aea0f2e9cdcb040ba00acad73dfd9fe2c887ed41fbfc3a', '2019-05-20 13:59:10', '2019-05-20 15:04:14', '2', '2', '1', '普通用户', '普通用户', 'aaaaaaaaaaa', '1');
INSERT INTO `tb_users` (`UserName`
		,`Password`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`Introduction`
		,`NickName`
		,`HeadImage`
		,`RsState`) VALUES ( 'ccccccccc', '7667a3770e9ae3159c6b56630934af376f63045f43b207277d4f8fc065baeba1', '2019-05-20 14:00:16', '2019-05-20 14:00:16', '2', '', '0', '测试账号', '垃圾账号', 'fefadsfdsfsdf', '1');
INSERT INTO `tb_users` (`UserName`
		,`Password`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`Introduction`
		,`NickName`
		,`HeadImage`
		,`RsState`) VALUES ( 'ttaajj66', 'e9d57617c5e40abc0e0cadb2329e7d12cd11ea35c8ff60fd249694401071532a', '2019-06-13 12:12:31', '2019-06-13 12:12:31', '2', '', '0', '士大夫士大夫的说法', '郭聪', '', '1');
INSERT INTO `tb_users`(`UserName`
		,`Password`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`Introduction`
		,`NickName`
		,`HeadImage`
		,`RsState`) VALUES ( 'luxiuli', 'e0662446dc3e1fe50801cae1b6e01b336263a9772cafe5abbf7ae677ae61c5e9', '2019-06-13 13:00:39', '2019-06-13 13:00:39', '2', '', '0', '大范德萨范德萨发', '路秀丽', '', '1');
INSERT INTO `tb_users` (`UserName`
		,`Password`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`Introduction`
		,`NickName`
		,`HeadImage`
		,`RsState`) VALUES ('fghdfgdfg', 'e68dfc58e5a47f615a4af796f7242fc527f5220e5dfe8cb31cc5ee9448fddada', '2019-06-13 13:00:57', '2019-06-13 13:00:57', '2', '', '0', 'dsgdfgfdg', '山东是大', '', '1');
INSERT INTO `tb_users` (`UserName`
		,`Password`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`Introduction`
		,`NickName`
		,`HeadImage`
		,`RsState`) VALUES ('ghfghgdgfdh', 'f4e814ee4229c5d2a1322c75d89fc838d106995bc8a22e034e50fce16f1cef5c', '2019-06-13 13:01:17', '2019-06-13 13:01:17', '2', '', '0', 'fdhfgh', 'sadf', '', '1');
INSERT INTO `tb_users` (`UserName`
		,`Password`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`Introduction`
		,`NickName`
		,`HeadImage`
		,`RsState`) VALUES ( 'yrtyrtyrty', '51fdbd5a9ea47083566f06314e842fa532fc45ecac6244915b6c4f0b84ecc116', '2019-06-13 13:01:33', '2019-06-13 13:01:33', '2', '', '0', 'rtyrtyrty', 'dfgdfg', '', '1');
INSERT INTO `tb_users` (`UserName`
		,`Password`
		,`AddDateTime`
		,`UpdateDateTime`
		,`AddUser`
		,`UpdateUser`
		,`RowVersion`
		,`Introduction`
		,`NickName`
		,`HeadImage`
		,`RsState`) VALUES ( 'asdasddsa', '253eb206ffd595eee53f8afc5801baa9f5a6f5d4f717eae16322e8a918ef09cd', '2019-06-13 13:02:06', '2019-06-13 13:02:06', '2', '', '0', 'sadsadsads', 'gdfgfdg', '', '1');
