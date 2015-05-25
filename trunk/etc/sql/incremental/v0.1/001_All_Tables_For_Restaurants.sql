SET NAMES utf8;

CREATE TABLE `restaurant_entries` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) DEFAULT NULL,
  `restaurant_entry_category_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8;

INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (34,'Банкетный зал',1);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (35,'Бар',1);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (36,'Загородный ресторан',1);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (37,'Караоке-бар',1);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (38,'до 1000р',2);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (39,'1000-1500р',2);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (40,'1500-2000р',2);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (41,'2000-3000р',2);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (42,'от 3000р',2);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (43,'Австралийская',3);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (44,'Австрийская',3);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (45,'Авторская',3);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (46,'Азербайджанская',3);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (47,'Аниматоры',4);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (48,'Детская комната',4);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (49,'Детские праздники',4);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (50,'Детские стульчики',4);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (51,'Бизнес-ланч',5);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (52,'Вегетарианское меню',5);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (53,'Винная карта',5);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (54,'Выездное обслуживание',5);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (55,'Chill-out / Lounge',6);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (56,'VIP-зал',6);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (57,'Винотека',6);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (58,'Действиющий камин',6);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (59,'Бильярд',7);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (60,'Боулинг',7);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (61,'Гольф',7);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (62,'Дартс',7);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (63,'Банкетов',8);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (64,'Бизнес-ланча',8);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (65,'Болельщиков',8);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (66,'Деловых встреч',8);
INSERT INTO `restaurant_entries` (`id`,`title`,`restaurant_entry_category_id`) VALUES (67,'Wi-Fi',9);

CREATE TABLE `restaurant_entry_categories` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

INSERT INTO `restaurant_entry_categories` (`id`,`title`) VALUES (1,'Тип');
INSERT INTO `restaurant_entry_categories` (`id`,`title`) VALUES (2,'Средний счет');
INSERT INTO `restaurant_entry_categories` (`id`,`title`) VALUES (3,'Кухня');
INSERT INTO `restaurant_entry_categories` (`id`,`title`) VALUES (4,'Детям');
INSERT INTO `restaurant_entry_categories` (`id`,`title`) VALUES (5,'Предложения');
INSERT INTO `restaurant_entry_categories` (`id`,`title`) VALUES (6,'Особенности');
INSERT INTO `restaurant_entry_categories` (`id`,`title`) VALUES (7,'Развлечения');
INSERT INTO `restaurant_entry_categories` (`id`,`title`) VALUES (8,'Идеальное место для');
INSERT INTO `restaurant_entry_categories` (`id`,`title`) VALUES (9,'Другое');

CREATE TABLE `restaurants` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `holes_count` varchar(120) DEFAULT NULL,
  `work_time` varchar(140) DEFAULT NULL,
  `photoUrl` varchar(200) DEFAULT NULL,
  `vip` bit(1) DEFAULT b'0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

INSERT INTO `restaurants` (`id`,`title`,`phone`,`address`,`holes_count`,`work_time`,`photoUrl`,`vip`) VALUES (1,'Золотой фазан','523-432-432','Упырева, д 6/3, стр. 3','2 зала - 98 мест','пн-пт 8:00-24:00, сб-вс 12:00-24:00','/content/images/rest_1.jpg',1);
INSERT INTO `restaurants` (`id`,`title`,`phone`,`address`,`holes_count`,`work_time`,`photoUrl`,`vip`) VALUES (2,'Серебрянный дом','123-123-333','Смулакова, д 5, стр 21','5 залов - 500 мест','24ч','/content/images/rest_2.jpg',0);

CREATE TABLE `restaurants_entries` (
  `restaurant_id` bigint(20) NOT NULL,
  `entry_id` bigint(20) NOT NULL,
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `restaurants_entriescol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

INSERT INTO `restaurants_entries` (`restaurant_id`,`entry_id`,`id`,`restaurants_entriescol`) VALUES (1,38,1,NULL);
INSERT INTO `restaurants_entries` (`restaurant_id`,`entry_id`,`id`,`restaurants_entriescol`) VALUES (1,36,2,NULL);
INSERT INTO `restaurants_entries` (`restaurant_id`,`entry_id`,`id`,`restaurants_entriescol`) VALUES (1,47,3,NULL);
INSERT INTO `restaurants_entries` (`restaurant_id`,`entry_id`,`id`,`restaurants_entriescol`) VALUES (1,55,4,NULL);
INSERT INTO `restaurants_entries` (`restaurant_id`,`entry_id`,`id`,`restaurants_entriescol`) VALUES (1,56,5,NULL);
INSERT INTO `restaurants_entries` (`restaurant_id`,`entry_id`,`id`,`restaurants_entriescol`) VALUES (1,57,6,NULL);
INSERT INTO `restaurants_entries` (`restaurant_id`,`entry_id`,`id`,`restaurants_entriescol`) VALUES (1,67,7,NULL);
INSERT INTO `restaurants_entries` (`restaurant_id`,`entry_id`,`id`,`restaurants_entriescol`) VALUES (2,41,11,NULL);
INSERT INTO `restaurants_entries` (`restaurant_id`,`entry_id`,`id`,`restaurants_entriescol`) VALUES (2,36,12,NULL);
INSERT INTO `restaurants_entries` (`restaurant_id`,`entry_id`,`id`,`restaurants_entriescol`) VALUES (2,44,13,NULL);
INSERT INTO `restaurants_entries` (`restaurant_id`,`entry_id`,`id`,`restaurants_entriescol`) VALUES (2,54,14,NULL);
INSERT INTO `restaurants_entries` (`restaurant_id`,`entry_id`,`id`,`restaurants_entriescol`) VALUES (2,56,15,NULL);