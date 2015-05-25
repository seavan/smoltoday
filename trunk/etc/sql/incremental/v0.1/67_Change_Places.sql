SET NAMES utf8;

ALTER TABLE `places` DROP COLUMN `longitude`;
ALTER TABLE `places` DROP COLUMN `latitude`;
ALTER TABLE `places` ADD COLUMN `coordinates` VARCHAR(30) NULL  AFTER `odnoklassniki_link`;

UPDATE `places` SET `coordinates` = '32.042354,54.822873' WHERE id = 1;


