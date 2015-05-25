ALTER TABLE `photobank_photos_rating` ADD COLUMN `create_date` DATETIME NOT NULL AFTER `rating`;
ALTER TABLE `photobank_photos` ADD COLUMN `rating` INT(11) NULL DEFAULT 0 AFTER `publish_date`;
DELETE FROM `photobank_photos_rating` WHERE id > 0;
ALTER TABLE `photobank_photos_rating` AUTO_INCREMENT = 1;