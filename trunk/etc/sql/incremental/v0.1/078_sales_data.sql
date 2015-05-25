SET NAMES utf8;

UPDATE `smolensk`.`sales` SET `image`='photo_sale_1.jpg' WHERE `id`='1';
UPDATE `smolensk`.`sales` SET `image`='photo_sale_2.jpg' WHERE `id`='2';

INSERT INTO `smolensk`.`sales`
(`title`,`text`, `publish_date`,`is_main`, `category_id`, `company_id`, `sale_type_id`,`comment_count`,
`start_date`,`end_date`,`percent`,`percent_max`,`site`,`phone`,`products`,`work_time`,`sales_offices`,`image`)
VALUES
("категория - все для дома, тип - акции, время добавления - 26 сентября", "тут должно быть описание",
'2013-09-26 23:10:00',0, 2,1,2,0, '2013-09-20 00:00:00', '2013-09-21 00:00:00', 100, null, null,
"(499) 340-21-90, (497) 777-77-77", null, "ежедневно с 11:00 до 20:00", "Адрес: Смоленск, пр. Мира, 9", null);

INSERT INTO `smolensk`.`sales`
(`title`,`text`, `publish_date`,`is_main`, `category_id`, `company_id`, `sale_type_id`,`comment_count`,
`start_date`,`end_date`,`percent`,`percent_max`,`site`,`phone`,`products`,`work_time`,`sales_offices`,`image`)
VALUES
("категория - интернет, тип - акции, время добавления - 25 сентября", "тут должно быть описание...",
'2013-09-25 23:15:00',0, 3,1,2,0, '2013-09-21 00:00:00', '2013-09-22 00:00:00', null, 10, null,
"(499) 340-21-90, (497) 777-77-77", null, "ежедневно с 11:00 до 20:00", "Адрес: Смоленск, пр. Мира, 10", null);

INSERT INTO `smolensk`.`sales`
(`title`,`text`, `publish_date`,`is_main`, `category_id`, `company_id`, `sale_type_id`,`comment_count`,
`start_date`,`end_date`,`percent`,`percent_max`,`site`,`phone`,`products`,`work_time`,`sales_offices`,`image`)
VALUES
("категория - интернет, тип - скидки, время добавления - 24 сентября", "сумасшедшие скидки",
'2013-09-24 23:15:00',0, 3,2,1,0, '2013-09-23 00:00:00', '2013-09-24 00:00:00', 1, null, null,
"(499) 340-21-90, (497) 777-77-77", null, "ежедневно с 11:00 до 20:00", "Адрес: Смоленск, пр. Мира, 11", null);

INSERT INTO `smolensk`.`sales`
(`title`,`text`, `publish_date`,`is_main`, `category_id`, `company_id`, `sale_type_id`,`comment_count`,
`start_date`,`end_date`,`percent`,`percent_max`,`site`,`phone`,`products`,`work_time`,`sales_offices`,`image`)
VALUES
("категория - интернет, тип - скидки, время добавления - 25 сентября", "еще более сумасшедшие скидки",
'2013-09-25 23:15:00',0, 3,2,1,0, '2013-09-23 00:00:00', '2013-09-24 00:00:00', null, 2, null,
"(499) 340-21-90, (497) 777-77-77", null, "ежедневно с 11:00 до 20:00", "Адрес: Смоленск, пр. Мира, 11", null);