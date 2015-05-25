SET NAMES utf8;

ALTER TABLE `photobank_photos` ADD COLUMN `is_main` BIT(1) NULL DEFAULT b'0';
ALTER TABLE `photobank_photos` ADD COLUMN `day_photo` BIT(1) NULL DEFAULT b'0';
ALTER TABLE `photobank_photos` ADD COLUMN `preview_main` varchar(50) DEFAULT NULL;
