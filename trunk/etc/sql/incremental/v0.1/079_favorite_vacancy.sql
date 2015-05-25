SET NAMES utf8;

ALTER TABLE `smolensk`.`accounts_favorites` 
ADD COLUMN `vacancy_id` bigint(20) NULL AFTER `company_id`;