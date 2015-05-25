SET NAMES utf8;

/*
Navicat MySQL Data Transfer

Source Server         : work
Source Server Version : 50531
Source Host           : localhost:3306
Source Database       : smolensk

Target Server Type    : MYSQL
Target Server Version : 50531
File Encoding         : 65001

Date: 2013-07-23 23:18:51
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `accounts`
-- ----------------------------
DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `email` varchar(60) NOT NULL,
  `firstname` varchar(48) DEFAULT NULL,
  `lastname` varchar(80) DEFAULT NULL,
  `role_id` bigint(20) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `password` varchar(32) NOT NULL DEFAULT '',
  `salt` varchar(36) NOT NULL DEFAULT '',
  `activation_guid` varchar(36) DEFAULT NULL,
  `lastlogin` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='Table for portal user accounts';

-- ----------------------------
-- Records of accounts
-- ----------------------------
INSERT INTO `accounts` VALUES ('1', 'seavan@etcetera.ws', 'Самвел', 'Аванесов', '0', '2013-06-27 09:00:00', '7d586415281c5e0e20e6d58ceccf6395', '', null, null);
INSERT INTO `accounts` VALUES ('2', 'khlas@yandex.ru', 'Александр', 'Хлевной', '2', '2013-06-26 14:00:00', '7d586415281c5e0e20e6d58ceccf6395', '', null, null);
INSERT INTO `accounts` VALUES ('3', 'annberuk@yandex.ru', 'Анна', 'Бирюкова', '4', '2013-06-28 10:41:00', '7d586415281c5e0e20e6d58ceccf6395', '', null, null);
