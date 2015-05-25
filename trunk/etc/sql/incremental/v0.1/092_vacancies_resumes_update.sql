SET NAMES utf8;

TRUNCATE TABLE `smolensk`.`vacancy_entries`;

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (1,'Нет',1,'r');
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (2,'Не имеет значения',1,'v');
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (3,'От 1 года до 3 лет',1,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (4,'От 3 до 6 лет',1,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (5,'Более 6 лет',1,NULL);

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (6,'Не имеет значения',2,'v');
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (7,'Гражданин РФ',2,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (8,'Страны с безвизовым режимом',2,'v');
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (9,'Страны с визовым режимом',2,'v');

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (10,'Полная занятость',3,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (11,'Частичная занятость',3,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (12,'Проектная/Временная работа',3,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (13,'Волонтерство',3,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (14,'Стажировка',3,NULL);

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (15,'Полный день',4,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (16,'Сменный график',4,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (17,'Гибкий график',4,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (18,'Удаленная работа',4,NULL);

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (19,'Нет',5,'r');
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (20,'Не имеет значения',5,'v');
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (21,'Высшее',5,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (22,'Неоконченное высшее',5,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (23,'Среднее',5,NULL);

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (24,'Замужем/Женат',6,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (25,'В разводе',6,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (26,'Не замужем/Не женат',6,NULL);

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (27,'Нет',7,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (28,'Среднее',7,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (29,'Неоконченное высшее',7,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (30,'Высшее',7,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (31,'Бакалавриат',7,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (32,'Магистратура',7,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (33,'Аспирантура',7,NULL);

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (34,'Очная/Дневная',8,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (35,'Заочная/Вечерняя',8,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (36,'Заочная/Дистанционная',8,NULL);
