SET NAMES utf8;

ALTER TABLE `smolensk`.`accounts_favorites` 
ADD COLUMN `company_id` bigint(20) NULL AFTER `sale_id`;