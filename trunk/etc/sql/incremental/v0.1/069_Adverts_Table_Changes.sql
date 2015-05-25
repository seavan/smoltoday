ALTER TABLE `ad_advertisments` ADD COLUMN `account_id` BIGINT(20) NULL AFTER `id`;

UPDATE `ad_advertisments` SET `account_id`='1' WHERE `id`='1';
UPDATE `ad_advertisments` SET `account_id`='1' WHERE `id`='2';
UPDATE `ad_advertisments` SET `account_id`='1' WHERE `id`='3';
UPDATE `ad_advertisments` SET `account_id`='2' WHERE `id`='4';
UPDATE `ad_advertisments` SET `account_id`='2' WHERE `id`='5';
UPDATE `ad_advertisments` SET `account_id`='3' WHERE `id`='6';
UPDATE `ad_advertisments` SET `account_id`='4' WHERE `id`='7';
UPDATE `ad_advertisments` SET `account_id`='4' WHERE `id`='8';

CREATE TABLE `ad_advert_requests` (
  `id` BIGINT(20) NOT NULL AUTO_INCREMENT,
  `account_id` BIGINT(20) NOT NULL,
  `ad_id` BIGINT(20) NOT NULL,
  `in_interesting` BIT NOT NULL DEFAULT 0,
  `pin_to_list` BIT NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`));