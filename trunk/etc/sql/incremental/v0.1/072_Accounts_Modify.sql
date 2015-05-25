SET NAMES utf8;

ALTER TABLE `accounts` 
ADD COLUMN `is_male` BIT(1) NULL DEFAULT b'0' AFTER `google_id`;

ALTER TABLE `accounts` 
ADD COLUMN `birthdate` datetime DEFAULT NULL AFTER `is_male`;

ALTER TABLE `accounts` 
ADD COLUMN `secondname` VARCHAR(80) NULL DEFAULT NULL AFTER `birthdate`;

ALTER TABLE `accounts` 
ADD COLUMN `career` VARCHAR(80) NULL DEFAULT NULL AFTER `secondname`;

ALTER TABLE `accounts` 
ADD COLUMN `comments_count` int(11) DEFAULT '0' AFTER `career`;

