SET NAMES utf8;

ALTER TABLE `smolensk`.`vacancies` ADD COLUMN `is_publish` BIT NULL  AFTER `account_id` ;

ALTER TABLE `smolensk`.`vacancies` ADD COLUMN `contact_phone2` VARCHAR(10) NULL  AFTER `contact_phone` ;

ALTER TABLE `smolensk`.`vacancies` ADD COLUMN `work_phone2` VARCHAR(10) NULL  AFTER `work_phone` ;
