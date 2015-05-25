SET NAMES utf8;

ALTER TABLE `smolensk`.`companies` ADD COLUMN `paid_order` BIGINT NULL  AFTER `category_id` ;

UPDATE `smolensk`.`companies` SET `paid_order`='555' WHERE `id`='2';
