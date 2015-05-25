set names utf8;

CREATE TABLE `sale_categories` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) NOT NULL,
  `order_id` int DEFAULT '0',
  PRIMARY KEY (`id`)
);

INSERT INTO `smolensk`.`sale_categories` (`order_id`, `title`) VALUES ('1', 'Авто');
INSERT INTO `smolensk`.`sale_categories` (`order_id`, `title`) VALUES ('2', 'Все для дома');
INSERT INTO `smolensk`.`sale_categories` (`order_id`, `title`) VALUES ('3', 'Интернет');
INSERT INTO `smolensk`.`sale_categories` (`order_id`, `title`) VALUES ('4', 'Красота');
INSERT INTO `smolensk`.`sale_categories` (`order_id`, `title`) VALUES ('5', 'Одежда, обувь, аксессуары');
INSERT INTO `smolensk`.`sale_categories` (`order_id`, `title`) VALUES ('6', 'Туризм');
INSERT INTO `smolensk`.`sale_categories` (`order_id`, `title`) VALUES ('7', 'Развлечения');
INSERT INTO `smolensk`.`sale_categories` (`order_id`, `title`) VALUES ('8', 'Рестораны и кафе');
INSERT INTO `smolensk`.`sale_categories` (`order_id`, `title`) VALUES ('9', 'Разное');

CREATE TABLE `sale_types` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
);

INSERT INTO `smolensk`.`sale_types` (`title`) VALUES ('Скидки');
INSERT INTO `smolensk`.`sale_types` (`title`) VALUES ('Распродажи');
INSERT INTO `smolensk`.`sale_types` (`title`) VALUES ('Акции');
INSERT INTO `smolensk`.`sale_types` (`title`) VALUES ('Скидки по банковской карте');

CREATE TABLE `smolensk`.`sales` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(245) DEFAULT NULL,
  `text` text,
  `publish_date` datetime DEFAULT NULL,
  `is_main` bit(1) DEFAULT b'0',
  `category_id` bigint(20) NOT NULL,
  `company_id` bigint(20) NOT NULL,
  `sale_type_id` bigint(20) NOT NULL,
  `comment_count` int(11) DEFAULT '0',
  `start_date` datetime DEFAULT NULL,
  `end_date` datetime DEFAULT NULL,
  `percent` int(10) DEFAULT NULL,
  `percent_max` int(10) DEFAULT NULL,
  `site` varchar(100) DEFAULT NULL,
  `phone` varchar(100) DEFAULT NULL,
  `products` varchar(200) DEFAULT NULL,
  `work_time` varchar(100) DEFAULT NULL, 
  `sales_offices` text DEFAULT NULL,  
  `image` varchar(100) DEFAULT NULL,  
  PRIMARY KEY (`id`)
);

CREATE TABLE `sales_comments` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `left_key` int(11) NOT NULL,
  `right_key` int(11) NOT NULL,
  `level` int(11) NOT NULL,
  `delete` bit(1) NOT NULL,
  `create_date` datetime NOT NULL,
  `account_id` bigint(20) NOT NULL,
  `text` text NOT NULL,
  `parent_id` bigint(20) DEFAULT NULL,
  `sale_id` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE `smolensk`.`accounts_favorites` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `account_id` bigint(20) NOT NULL,
  `sale_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
);

INSERT INTO `smolensk`.`sales`
(`title`,`text`, `publish_date`,`is_main`, `category_id`, `company_id`, `sale_type_id`,`comment_count`,
`start_date`,`end_date`,`percent`,`percent_max`,`site`,`phone`,`products`,`work_time`,`sales_offices`,`image`)
VALUES
("Скидки до 50% при оплате картой Visa Elektron, MasterCard Standard и VISA Classic",
"Скидка 3% при оплате картой Visa Elektron,MasterCard Standard и VISA Classic, Кобрендовые карты MasterCard «Национальной студенческой Футбольной Лиги. Скидка 5% MasterCard Gold и VISA Gold,MasterCard Platinum и VISA Platinum. Скидка 2% При оплате наличными с предъявлением карты Банка Visa Electron,MasterCard Standard и VISA Classic, Кобрендовые карты MasterCard «Национальной студенческой Футбольной Лиги. Скидка 3% При оплате наличными с предъявлением карты Банка MasterCard Gold и VISA Gold,MasterCard Platinum и VISA Platinum.",
'2013-09-24 16:40:00',1, 1,1,1,0, '2013-07-08 00:00:00', '2013-09-21 00:00:00', null, 50, "http://advantatur.ru/",
"(499) 340-03-91, (495) 940-76-94", "Горящие туры, экскурсионные туры, круизы", "ежедневно с 11:00 до 20:00",
"Адрес: ул.Митинская дом 31, станция метро Митино<br>8-499-3400391<br>8-499-3400392<br>
<br>Офис продаж: «АЛЕКСЕЕВСКИЙ»<br>Адрес: Проспект Мира дом 114а, станция метро Алексеевская<br>
Телефоны:<br>8-495-9407694<br>8-495-7486295", null);

INSERT INTO `smolensk`.`sales`
(`title`,`text`, `publish_date`,`is_main`, `category_id`, `company_id`, `sale_type_id`,`comment_count`,
`start_date`,`end_date`,`percent`,`percent_max`,`site`,`phone`,`products`,`work_time`,`sales_offices`,`image`)
VALUES
("Скидка 7% на продукцию для держателей международных платежных систем VISA и Master Card, эмитированных Смоленским Банком", "Скидка 3% при оплате картой Visa Elektron,MasterCard Standard и VISA Classic, Кобрендовые карты MasterCard «Национальной студенческой Футбольной Лиги. Скидка 5% MasterCard Gold и VISA Gold,MasterCard Platinum и VISA Platinum. Скидка 2% При оплате наличными с предъявлением карты Банка Visa Electron,MasterCard Standard и VISA Classic, Кобрендовые карты MasterCard «Национальной студенческой Футбольной Лиги. Скидка 3% При оплате наличными с предъявлением карты Банка MasterCard Gold и VISA Gold,MasterCard Platinum и VISA Platinum.",
'2013-09-24 16:50:00',1, 1,1,1,0, '2013-07-08 00:00:00', '2013-09-21 00:00:00', null, 25, null,
"(499) 340-03-91, (495) 940-76-94", null, "ежедневно с 11:00 до 20:00",
"Адрес: ул.Митинская дом 31, станция метро Митино", null);
