ALTER TABLE `ad_advertisments` 
ADD COLUMN `created_date` DATETIME DEFAULT NULL AFTER `category_id`,
ADD COLUMN `name` VARCHAR(100) DEFAULT NULL AFTER `price`,
ADD COLUMN `view_count` INT NOT NULL DEFAULT 0 AFTER `email`,
ADD COLUMN `on_main` BIT NOT NULL DEFAULT 0 AFTER `view_count`,
ADD COLUMN `in_interesting` BIT NOT NULL DEFAULT 0 AFTER `on_main`,
ADD COLUMN `pin_to_list` BIT NOT NULL DEFAULT 0 AFTER `in_interesting`;