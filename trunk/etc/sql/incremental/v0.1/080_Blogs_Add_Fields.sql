SET NAMES utf8;

ALTER TABLE `blogs` ADD COLUMN `can_comment` BIT(1) NULL DEFAULT b'0';
ALTER TABLE `blogs` ADD COLUMN `is_publish` BIT(1) NULL DEFAULT b'0';
ALTER TABLE `blogs` ADD COLUMN `is_delete` BIT(1) NULL DEFAULT b'0';