SET NAMES utf8;

ALTER TABLE `accounts` ADD COLUMN `has_photoprofile` BIT(1) NULL DEFAULT b'0';

CREATE TABLE `photobank_obtained` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `account_id` bigint(20) NOT NULL,
  `price_id` bigint(20) NOT NULL,
  `buy_date`  datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;
