SET NAMES utf8;

ALTER TABLE `accounts_favorites` 
ADD COLUMN `restaurant_id` bigint(20) NULL AFTER `sale_id`;