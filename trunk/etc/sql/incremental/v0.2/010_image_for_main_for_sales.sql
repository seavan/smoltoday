set names utf8;

ALTER TABLE `sales` 
ADD COLUMN `image_for_main` VARCHAR(100) NULL DEFAULT NULL AFTER `image`;
