SET NAMES utf8;

ALTER TABLE `smolensk`.`companies` ADD COLUMN `stable_order` BIGINT NULL  AFTER `paid_order` ;

UPDATE `smolensk`.`companies` SET `stable_order`='444' WHERE `id`='1';



ALTER TABLE `smolensk`.`company_categories` CHANGE COLUMN `name` `name` VARCHAR(45) NOT NULL  , ADD COLUMN `icon` VARCHAR(100) NULL  AFTER `name` , ADD COLUMN `parent` BIGINT NULL  AFTER `icon` ;


UPDATE `smolensk`.`company_categories` SET `name`='Отдых и развлечения', `icon`='1.png' WHERE `id`='1';
UPDATE `smolensk`.`company_categories` SET `name`='Аудит, консалтинг, право', `icon`='2.png' WHERE `id`='2';
INSERT INTO `smolensk`.`company_categories` (`name`, `icon`) VALUES ('Безопасность, охрана', '3.png');
INSERT INTO `smolensk`.`company_categories` (`name`, `icon`) VALUES ('Промышленность, заводы', '4.png');
INSERT INTO `smolensk`.`company_categories` (`name`, `icon`) VALUES ('Банки, кредиты, вклады и депозиты', '5.png');
INSERT INTO `smolensk`.`company_categories` (`name`, `icon`) VALUES ('Рыбное и сельское хозяйство', '6.png');
INSERT INTO `smolensk`.`company_categories` (`name`, `icon`) VALUES ('ЖКХ и Органы власти', '7.png');
INSERT INTO `smolensk`.`company_categories` (`name`, `icon`) VALUES ('Авто, транспорт, грузоперевозки', '8.png');


UPDATE `smolensk`.`companies` SET `category_id`='7' WHERE `id`='2';
UPDATE `smolensk`.`companies` SET `category_id`='5' WHERE `id`='1';


INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Клубы', '1');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Юр фирмы', '2');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Охранные предприятия', '3');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Фабрики', '4');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Банки', '5');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Фермы', '6');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Управляющие компании', '7');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Перевозчики', '8');



INSERT INTO `smolensk`.`companies` (`id`, `title`, `work_time`, `address`, `www`, `email`, `phones`, `leader`, `description`, `publish_date`, `category_id`, `stable_order`) VALUES ('3', 'ИП Сапог', 'с 9 до 21', 'Смоленск, 5-я улица строителей 33, строение 15', 'sapog.ru', 'sapog@sapog.ru', '+7 (920) 544 21 11', 'Сапог Евгений Петросович', 'Сапоги ремонтируем очень качественно, быстро и недорого', '2012-04-14 12:30:00', '12', '333');
