SET NAMES utf8;

ALTER TABLE `restaurants` ADD COLUMN `coordinates` VARCHAR(30) NULL  AFTER `feedback_email`;
ALTER TABLE `restaurants` ADD COLUMN `map_title` VARCHAR(60) NULL  AFTER `coordinates`;
ALTER TABLE `restaurants` ADD COLUMN `map_description` VARCHAR(200) NULL  AFTER `map_title`;

ALTER TABLE `companies` ADD COLUMN `coordinates` VARCHAR(30) NULL  AFTER `views_count`;
ALTER TABLE `companies` ADD COLUMN `map_title` VARCHAR(60) NULL  AFTER `coordinates`;
ALTER TABLE `companies` ADD COLUMN `map_description` VARCHAR(200) NULL  AFTER `map_title`;

ALTER TABLE `actions` ADD COLUMN `coordinates` VARCHAR(30) NULL  AFTER `odnoklassniki_link`;
ALTER TABLE `actions` ADD COLUMN `map_title` VARCHAR(60) NULL  AFTER `coordinates`;
ALTER TABLE `actions` ADD COLUMN `map_description` VARCHAR(200) NULL  AFTER `map_title`;

