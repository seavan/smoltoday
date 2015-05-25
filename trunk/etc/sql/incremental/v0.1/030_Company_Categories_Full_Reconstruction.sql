SET NAMES utf8;

ALTER TABLE `smolensk`.`company_categories` CHANGE COLUMN `name` `name` VARCHAR(100) NOT NULL  ;

INSERT INTO `smolensk`.`company_categories` (`name`) VALUES ('Оборудование, приборы, инструменты');
INSERT INTO `smolensk`.`company_categories` (`name`) VALUES ('Товары и услуги для населения');
INSERT INTO `smolensk`.`company_categories` (`name`) VALUES ('Образование и наука, культура и искусство');
INSERT INTO `smolensk`.`company_categories` (`name`) VALUES ('Транспорт, грузоперевозки');
INSERT INTO `smolensk`.`company_categories` (`name`) VALUES ('Оргтехника, компьютеры, связь');
UPDATE `smolensk`.`company_categories` SET `name`='Услуги бытовые', `icon`='', `parent`=NULL WHERE `id`='9';
UPDATE `smolensk`.`company_categories` SET `name`='СМИ и полиграфия, реклама и маркетинг', `icon`='', `parent`=NULL WHERE `id`='10';
UPDATE `smolensk`.`company_categories` SET `name`='Красота, здоровый образ жизни', `icon`='', `parent`=NULL WHERE `id`='11';
UPDATE `smolensk`.`company_categories` SET `name`='Строительные материалы и оборудование, ремонт', `icon`='', `parent`=NULL WHERE `id`='12';
UPDATE `smolensk`.`company_categories` SET `name`='Спорт и туризм. Активный отдых', `icon`='', `parent`=NULL WHERE `id`='13';
UPDATE `smolensk`.`company_categories` SET `name`='Строительство, недвижимость', `icon`='', `parent`=NULL WHERE `id`='14';
UPDATE `smolensk`.`company_categories` SET `name`='Медицина, фармация, ветеринария', `icon`='', `parent`=NULL WHERE `id`='15';
UPDATE `smolensk`.`company_categories` SET `name`='Сервис и товары для бизнеса', `icon`='', `parent`=NULL WHERE `id`='16';
UPDATE `smolensk`.`company_categories` SET `name`='Рыбное и сельское хозяйство' WHERE `id`='8';
UPDATE `smolensk`.`company_categories` SET `name`='Органы власти, управления и жизнеобеспечения', `icon`='7.png' WHERE `id`='1';
UPDATE `smolensk`.`company_categories` SET `name`='Банки, кредитные организации, страховые компании', `icon`='2.png' WHERE `id`='7';
UPDATE `smolensk`.`company_categories` SET `name`='Отдых и развлечения, общественное питание', `icon`='1.png' WHERE `id`='2';
UPDATE `smolensk`.`company_categories` SET `name`='Аудит, консалтинг, право', `icon`='2.png' WHERE `id`='3';
UPDATE `smolensk`.`company_categories` SET `name`='Охрана и безопасность' WHERE `id`='4';
UPDATE `smolensk`.`company_categories` SET `name`='Автобизнес, автотранспорт' WHERE `id`='5';
UPDATE `smolensk`.`company_categories` SET `name`='Промышленность, заводы' WHERE `id`='6';
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Управляющие компании', '1');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Клубы', '2');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Юр фирмы', '3');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('ЧОПики', '4');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Салоны автомобильные', '5');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Фабрики', '6');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Банки', '7');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Рыбаки', '8');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Бытовуха', '9');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Печатные агенства', '10');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Парикмахерские', '11');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Склады', '12');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Спортзалы', '13');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Строительные компании', '14');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Клиники', '15');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Магазины', '16');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Магаизны', '17');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Услуги', '18');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Музеи', '19');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Перевозчики', '20');
INSERT INTO `smolensk`.`company_categories` (`name`, `parent`) VALUES ('Салоны связи', '21');

UPDATE `smolensk`.`companies` SET `category_id`='24' WHERE `id`='3';

