set names utf8;

ALTER TABLE `smolensk`.`companies` ADD COLUMN `views_count` BIGINT(20) NULL  AFTER `stable_order` ;

INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Адвокаты', '3');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Телепаты', '3');

INSERT INTO `smolensk`.`companies` (`title`, `work_time`, `address`, `www`, `email`, `phones`, `leader`, `description`, `publish_date`, `category_id`, `views_count`) VALUES ('ИПП', 'с 9 до 21', 'Смоленск, 6-я улица 22, строение 12', 'IPP', 'IPP@IPP.ru', '+79115554754', 'Евгений Александрович Мандражка', 'Все делает', '2010-04-11 11:11:00', '43', '4');
UPDATE `smolensk`.`companies` SET `views_count`='2' WHERE `id`='3';
UPDATE `smolensk`.`companies` SET `views_count`='4' WHERE `id`='2';
UPDATE `smolensk`.`companies` SET `views_count`='1' WHERE `id`='1';
