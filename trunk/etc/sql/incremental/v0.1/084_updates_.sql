SET NAMES UTF8;

ALTER TABLE `smolensk`.`vacancy_entries` CHANGE COLUMN `id` `id` BIGINT(20) NOT NULL AUTO_INCREMENT  ;

INSERT INTO `smolensk`.`vacancy_entries` (`title`, `vacancy_entry_category_id`, `only`) VALUES ('Нет', '5', 'r');

ALTER TABLE `smolensk`.`resumes` ADD COLUMN `phone2` VARCHAR(10) NULL  AFTER `phone` ;