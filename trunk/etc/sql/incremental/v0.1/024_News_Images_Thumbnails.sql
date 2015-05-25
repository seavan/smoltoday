SET NAMES utf8;

ALTER TABLE `smolensk`.`news_images` CHANGE COLUMN `full` `original` VARCHAR(128) NULL DEFAULT NULL  , ADD COLUMN `url` VARCHAR(255) NULL  AFTER `description` , ADD COLUMN `alt` VARCHAR(255) NULL  AFTER `url` , ADD COLUMN `inline` BIT NULL  AFTER `alt` , ADD COLUMN `guid` VARCHAR(36) NULL  AFTER `inline` , ADD COLUMN `medium_thumbnail` VARCHAR(128) NULL  AFTER `small_thumbnail` , ADD COLUMN `normal_thumbnail` VARCHAR(128) NULL  AFTER `large_thumbnail` ;
