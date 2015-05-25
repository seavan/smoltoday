SET NAMES utf8;

CREATE TABLE `restaurant_events` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `date` datetime DEFAULT NULL,
  `title` varchar(45) DEFAULT NULL,
  `short_desc` varchar(100) DEFAULT NULL,
  `restaurant_id` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

INSERT INTO `restaurant_events` (`id`,`date`,`title`,`short_desc`,`restaurant_id`) VALUES (1,'2013-07-14 18:00:00','Русские гвозди','Музыка',1);
INSERT INTO `restaurant_events` (`id`,`date`,`title`,`short_desc`,`restaurant_id`) VALUES (2,'2013-07-14 20:00:00','Американский молоток','Шоу',1);
INSERT INTO `restaurant_events` (`id`,`date`,`title`,`short_desc`,`restaurant_id`) VALUES (3,'2013-07-15 20:00:00','Чай в троем','Обеды',2);
INSERT INTO `restaurant_events` (`id`,`date`,`title`,`short_desc`,`restaurant_id`) VALUES (4,'2013-07-19 20:00:00','Чай в пятером','Обеды вкусные',1);
INSERT INTO `restaurant_events` (`id`,`date`,`title`,`short_desc`,`restaurant_id`) VALUES (5,'2013-07-21 23:00:00','Стрипати','Тусовка',1);
INSERT INTO `restaurant_events` (`id`,`date`,`title`,`short_desc`,`restaurant_id`) VALUES (6,'2013-07-27 22:00:00','Дуэт \"Триплет\"','Музыка',2);
INSERT INTO `restaurant_events` (`id`,`date`,`title`,`short_desc`,`restaurant_id`) VALUES (7,'2013-07-27 22:00:00','Джигурда','Экстрим',1);
INSERT INTO `restaurant_events` (`id`,`date`,`title`,`short_desc`,`restaurant_id`) VALUES (8,'2013-08-15 11:00:00','Балалайка Спела','Неизвестно',1);