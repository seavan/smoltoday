SET NAMES utf8;


ALTER TABLE `accounts` ADD COLUMN `website` VARCHAR(255) NULL  AFTER `rememberpass_guid` , ADD COLUMN `company` VARCHAR(255) NULL  AFTER `website` , ADD COLUMN `company_account_id` BIGINT(20) NULL  AFTER `company` , ADD COLUMN `description` TEXT NULL  AFTER `company_account_id`;