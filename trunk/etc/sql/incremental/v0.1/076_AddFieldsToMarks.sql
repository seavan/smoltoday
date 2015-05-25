SET NAMES utf8;

ALTER TABLE `actions_rating` ADD COLUMN `create_date` datetime DEFAULT NULL;
ALTER TABLE `blog_marks` ADD COLUMN `create_date` datetime DEFAULT NULL;
ALTER TABLE `company_rating` ADD COLUMN `create_date` datetime DEFAULT NULL;
ALTER TABLE `places_rating` ADD COLUMN `create_date` datetime DEFAULT NULL;
ALTER TABLE `restaurant_rating` ADD COLUMN `create_date` datetime DEFAULT NULL;