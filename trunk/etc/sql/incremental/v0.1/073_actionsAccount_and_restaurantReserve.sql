SET NAMES utf8;

ALTER TABLE `smolensk`.`actions` 
ADD COLUMN `account_id` bigint(20) NULL AFTER `place_id`,
ADD COLUMN `delete` bit(1) NULL DEFAULT b'0' AFTER `account_id`,
ADD COLUMN `approve` bit(1) NULL DEFAULT b'0' AFTER `account_id`,
ADD COLUMN `status` int NOT NULL DEFAULT '0' AFTER `account_id`;

UPDATE `smolensk`.`actions`
SET `approve` = b'1', `status` = 1
WHERE `id` > 0;

CREATE TABLE `smolensk`.`restaurants_reserve` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `create_date` datetime,
  `contact` varchar(100) DEFAULT NULL,
  `phone` varchar(100) DEFAULT NULL,
  `visit_date` datetime,
  `persons_count` int(11) DEFAULT '1',
  `account_id` bigint(20) NOT NULL,
  `restaraunt_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
);