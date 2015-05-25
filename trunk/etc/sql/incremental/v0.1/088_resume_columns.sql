SET NAMES utf8;

ALTER TABLE `smolensk`.`resumes` ADD COLUMN `is_publish` BIT NULL  AFTER `account_id` ;

ALTER TABLE `smolensk`.`accounts_favorites` ADD COLUMN `resume_id` BIGINT(20) NULL  AFTER `vacancy_id` ;
