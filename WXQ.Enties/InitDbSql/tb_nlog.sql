/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80016
Source Host           : 127.0.0.1:3306
Source Database       : wxqdb

Target Server Type    : MYSQL
Target Server Version : 80016
File Encoding         : 65001

Date: 2019-07-13 15:21:20
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_nlog`
-- ----------------------------
DROP TABLE IF EXISTS `tb_nlog`;
CREATE TABLE `tb_nlog` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Application` varchar(50) DEFAULT NULL,
  `Logged` timestamp NULL DEFAULT NULL,
  `Level` varchar(50) DEFAULT NULL,
  `Message` varchar(255) DEFAULT NULL,
  `Logger` varchar(100) DEFAULT NULL,
  `CallSite` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_nlog
-- ----------------------------
INSERT INTO `tb_nlog` VALUES ('13', 'WebApi', '2019-05-20 12:32:11', 'Error', 'An unhandled exception has occurred while executing the request.', 'Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware', 'Microsoft.AspNetCore.Diagnostics.Internal.DiagnosticsLoggerExtensions.UnhandledException');
