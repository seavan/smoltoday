SET NAMES utf8;


delete from `photobank_categories` where id > 0;
alter table `photobank_categories` auto_increment = 1;
alter table `photobank_categories` ADD COLUMN `photo` VARCHAR(50) NULL  AFTER `title`;

insert into `photobank_categories` (`title`, `photo`) VALUES ('Пейзажи', 'e2b4b514-fd3a-11e2-a424-f50845417a9f.jpg');
insert into `photobank_categories` (`title`, `photo`) VALUES ('События', '15b97618-fd3b-11e2-a424-f50845417a9f.jpg');
insert into `photobank_categories` (`title`, `photo`) VALUES ('Спорт', '24d44b98-fd3b-11e2-a424-f50845417a9f.jpg');
insert into `photobank_categories` (`title`, `photo`) VALUES ('Фотоприколы', '2fc78f3d-fd3b-11e2-a424-f50845417a9f.jpg');

alter table `accounts` ADD COLUMN `address` TEXT NULL  AFTER `company_account_id`;
insert into `accounts` (`id`, `email`, `firstname`, `lastname`, `role_id`, `created`, `password`, `website`, `company`, `address`, `description`) VALUES ('4', 'photoman@yandex.ru', 'Иван', 'Иванов', '1', '2013-08-01 09:00:00', '7d586415281c5e0e20e6d58ceccf6395', 'smolportal.ru', 'ИвановФото', 'Россия, Краснодарский край', 'Родился в Краснодарском крае. Работал на такие популярные журналы, как burda, мой дом, дизайны для дома. Основной жанр: пезажи и общие фото.');

CREATE TABLE `photobank_licenses` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `photobank_licenses` (`title`) VALUES ('Обычная');
INSERT INTO `photobank_licenses` (`title`) VALUES ('Расширенная');

CREATE TABLE `photobank_photos` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `category_id` bigint(20) NOT NULL,
  `account_id` bigint(20) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `photo` varchar(50) NOT NULL,
  `preview` varchar(50) DEFAULT NULL COMMENT 'photo preview (325x211px)',
  `preview_square` varchar(50) DEFAULT NULL COMMENT 'square photo preview (138x138px)',
  `filename` varchar(255) DEFAULT NULL,
  `view_count` int(11) NOT NULL DEFAULT '0',
  `download_count` int(11) NOT NULL DEFAULT '0',
  `publish_date` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;

CREATE TABLE `photobank_related_photos` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `photo_id` bigint(20) NOT NULL,
  `license_id` int(11) NOT NULL,
  `width` int(11) DEFAULT NULL,
  `height` int(11) DEFAULT NULL,
  `photo` varchar(50) DEFAULT NULL,
  `filename` varchar(255) DEFAULT NULL,
  `price` float DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (1,1,4,'photo1',NULL,'6b66570e-fd41-11e2-a424-f50845417a90.jpg','6b66570e-fd41-11e2-a424-f50845417a90.jpg','6b66570e-fd41-11e2-a424-f50845417a91.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (2,1,4,'photo2',NULL,'6d0ccefc-fd42-11e2-a424-f50845417a90.jpg','6d0ccefc-fd42-11e2-a424-f50845417a90.jpg','6d0ccefc-fd42-11e2-a424-f50845417a91.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (3,1,4,'photo3',NULL,'0d2674c4-fd43-11e2-a424-f50845417a90.jpg','0d2674c4-fd43-11e2-a424-f50845417a90.jpg','0d2674c4-fd43-11e2-a424-f50845417a91.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (4,1,4,'photo4',NULL,'79790f54-fd43-11e2-a424-f50845417a90.jpg','79790f54-fd43-11e2-a424-f50845417a90.jpg','79790f54-fd43-11e2-a424-f50845417a91.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (5,2,4,'photo5',NULL,'6d0ccefc-fd42-11e2-a424-f50845417a92.jpg','6d0ccefc-fd42-11e2-a424-f50845417a92.jpg','6d0ccefc-fd42-11e2-a424-f50845417a93.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (6,2,4,'photo6',NULL,'6b66570e-fd41-11e2-a424-f50845417a92.jpg','6b66570e-fd41-11e2-a424-f50845417a92.jpg','6b66570e-fd41-11e2-a424-f50845417a93.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (7,2,4,'photo7',NULL,'79790f54-fd43-11e2-a424-f50845417a92.jpg','79790f54-fd43-11e2-a424-f50845417a92.jpg','79790f54-fd43-11e2-a424-f50845417a93.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (8,2,4,'photo8',NULL,'0d2674c4-fd43-11e2-a424-f50845417a92.jpg','0d2674c4-fd43-11e2-a424-f50845417a92.jpg','0d2674c4-fd43-11e2-a424-f50845417a93.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (9,3,4,'photo9',NULL,'0d2674c4-fd43-11e2-a424-f50845417a94.jpg','0d2674c4-fd43-11e2-a424-f50845417a94.jpg','0d2674c4-fd43-11e2-a424-f50845417a95.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (10,3,4,'photo10',NULL,'79790f54-fd43-11e2-a424-f50845417a94.jpg','79790f54-fd43-11e2-a424-f50845417a94.jpg','79790f54-fd43-11e2-a424-f50845417a95.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (11,3,4,'photo11',NULL,'6b66570e-fd41-11e2-a424-f50845417a94.jpg','6b66570e-fd41-11e2-a424-f50845417a94.jpg','6b66570e-fd41-11e2-a424-f50845417a95.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (12,3,4,'photo12',NULL,'6d0ccefc-fd42-11e2-a424-f50845417a94.jpg','6d0ccefc-fd42-11e2-a424-f50845417a94.jpg','6d0ccefc-fd42-11e2-a424-f50845417a95.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (13,4,4,'photo13',NULL,'6d0ccefc-fd42-11e2-a424-f50845417a96.jpg','6d0ccefc-fd42-11e2-a424-f50845417a96.jpg','6d0ccefc-fd42-11e2-a424-f50845417a97.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (14,4,4,'photo14',NULL,'79790f54-fd43-11e2-a424-f50845417a96.jpg','79790f54-fd43-11e2-a424-f50845417a96.jpg','79790f54-fd43-11e2-a424-f50845417a97.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (15,4,4,'photo15',NULL,'0d2674c4-fd43-11e2-a424-f50845417a96.jpg','0d2674c4-fd43-11e2-a424-f50845417a96.jpg','0d2674c4-fd43-11e2-a424-f50845417a97.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');
INSERT INTO `photobank_photos` (`id`,`category_id`,`account_id`,`title`,`description`,`photo`,`preview`,`preview_square`,`filename`,`view_count`,`download_count`,`publish_date`) VALUES (16,4,4,'photo16',NULL,'6b66570e-fd41-11e2-a424-f50845417a96.jpg','6b66570e-fd41-11e2-a424-f50845417a96.jpg','6b66570e-fd41-11e2-a424-f50845417a97.jpg','photo.jpg',0,0,'2013-08-03 09:00:00');