set names utf8;

ALTER TABLE `news_categories` ADD COLUMN `css_class` VARCHAR(64) NULL  AFTER `order_id` ;