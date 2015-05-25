﻿SET NAMES utf8;

ALTER TABLE `ad_categories` CHANGE COLUMN `parent_id` `parent_id` BIGINT(20) NULL;
ALTER TABLE `ad_advertisments` ADD COLUMN `category_id` BIGINT(20) NOT NULL  AFTER `id`;

INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (1,'Недвижимость',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (2,'Животные и растения',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (3,'Для дома и сада',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (4,'Авто и мото',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (5,'Электроника и техника',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (6,'Строительство и ремонт',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (7,'Товары для детей',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (8,'Одежда, обувь, аксессуары',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (9,'Спорт, туризм, отдых',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (10,'Услуги и деятельность',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (11,'Здоровье и красота',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (12,'Знакомства',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (13,'Другое',NULL);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (14,'Квартиры',1);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (15,'Комнаты',1);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (16,'Дома, участки (дачи и огороды, земельные участки)',1);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (17,'Гаражи, автостоянки',1);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (18,'Коммерческая недвижимость (офисы, помещения, склады)',1);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (19,'Разное (подвалы, сараи)',1);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (20,'Собаки',2);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (21,'Кошки',2);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (22,'Птицы',2);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (23,'Аквариумные',2);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (24,'Грызуны',2);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (25,'Другие животные',2);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (26,'Аксессуары',2);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (27,'Растения',2);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (28,'Мебель',3);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (29,'Предметы интерьера',3);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (30,'Инструменты',3);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (31,'Сантехника',3);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (32,'Садовый инвентарь',3);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (33,'Продукты питания',3);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (34,'Легковые автомобили',4);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (35,'Коммерческий транспорт',4);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (36,'Автозапчасти и аксессуары',4);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (37,'Колеса,шины и диски',4);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (38,'Мото и вело',4);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (39,'Автосервис и услуги',4);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (40,'Другое',4);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (41,'Мобильные телефоны',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (42,'Компьютеры, планшеты',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (43,'Ноутбуки',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (44,'Переферийное оборудование',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (45,'Компьютерные комплектующие',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (46,'Аудио и видео',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (47,'Фототехника',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (48,'Портативная электроника, GPS навигаторы',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (49,'Пылесосы',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (50,'Электронные книги',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (51,'Кухонная техника',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (52,'Стиральные машины',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (53,'Гладильное и швейное оборудование',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (54,'Климатическая техника',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (55,'Игры, игровые приставки',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (56,'Индивидуальный уход',5);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (57,'Двери',6);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (58,'Окна',6);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (59,'Балконы',6);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (60,'Лестницы',6);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (61,'Материалы',6);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (62,'Электрика',6);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (63,'Отопление',6);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (64,'Готовые конструкции (дома, срубы, бани)',6);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (65,'Насосы',6);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (66,'Вентиляционные системы',6);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (67,'Другое',6);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (68,'Детская одежда и обувь',7);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (69,'Коляски',7);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (70,'Автокресла',7);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (71,'Детская мебель',7);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (72,'Товары для малышей',7);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (73,'Игрушки',7);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (74,'Постельные принадлежности',7);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (75,'Для будущих мам',7);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (76,'Товары для школы',7);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (77,'Другое',7);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (78,'Женская одежда',8);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (79,'Мужская одежда',8);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (80,'Женская обувь',8);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (81,'Мужская обувь',8);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (82,'Украшения, ювелирные изделия, бижутерия',8);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (83,'Аксессуары',8);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (84,'Все для свадьбы',8);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (85,'Другое',8);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (86,'Спортивные игры, виды спорта',9);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (87,'Фитнес, атлетика, борьба',9);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (88,'Велосипеды',9);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (89,'Снаряжение для рыбалки, охоты, активного отдыха',9);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (90,'Экскурсии, туры, круизы',9);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (91,'Обучения и занятия',9);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (92,'Другое',9);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (93,'Строительные и ремонтные услуги',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (94,'Транспортные услуги и аренда',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (95,'Монтаж и ремонт оборудования',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (96,'Астрология, магия, гадания',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (97,'Организация праздников, фото-, видеосъемка',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (98,'Безопасность, детективы',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (99,'Адвокаты, нотариусы, специалисты',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (100,'Агенства недвижимости',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (101,'Ремонт и изготовление одежды и обуви',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (102,'Помощь в оформлении документов',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (103,'Услуги переводчиков',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (104,'Услуги для животных',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (105,'Другое',10);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (106,'Парфюмерия',11);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (107,'Косметика',11);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (108,'Медицинская помощь',11);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (109,'Косметология и коррекция',11);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (110,'Массаж',11);
INSERT INTO `ad_categories` (`id`,`title`,`parent_id`) VALUES (111,'Другое',11);