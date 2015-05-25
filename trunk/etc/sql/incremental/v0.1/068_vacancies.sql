SET NAMES utf8;

ALTER TABLE `smolensk`.`vacancies` ADD COLUMN `show_in_banner` BIT NULL  AFTER `closed` ;

UPDATE `smolensk`.`vacancies` SET `show_in_banner`=1 WHERE `id`='1';
