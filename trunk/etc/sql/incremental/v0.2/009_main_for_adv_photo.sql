set names utf8;

ALTER TABLE `ad_photos` 
ADD COLUMN `is_main` BIT(1) NOT NULL DEFAULT b'0' AFTER `create_date`;