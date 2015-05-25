SET NAMES utf8;

ALTER TABLE `smolensk`.`resumes` ADD COLUMN `account_id` BIGINT NULL  AFTER `edited` ;

ALTER TABLE `smolensk`.`vacancies` ADD COLUMN `account_id` BIGINT NULL  AFTER `show_in_banner` ;

UPDATE `smolensk`.`vacancies` SET `account_id`='1' WHERE `id`='1';
UPDATE `smolensk`.`vacancies` SET `account_id`='1' WHERE `id`='2';
UPDATE `smolensk`.`vacancies` SET `account_id`='1' WHERE `id`='3';

UPDATE `smolensk`.`resumes` SET `account_id`='1' WHERE `id`='1';
UPDATE `smolensk`.`resumes` SET `account_id`='1' WHERE `id`='2';
UPDATE `smolensk`.`resumes` SET `account_id`='1' WHERE `id`='3';
