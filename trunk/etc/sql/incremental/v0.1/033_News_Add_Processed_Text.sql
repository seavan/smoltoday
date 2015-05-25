set names utf8;

ALTER TABLE `smolensk`.`news` ADD COLUMN `processed_text` TEXT NULL  AFTER `text` ;
