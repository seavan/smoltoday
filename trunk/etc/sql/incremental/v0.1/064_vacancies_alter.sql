SET NAMES utf8;

ALTER TABLE `smolensk`.`vacancies` ADD COLUMN `views_count` BIGINT NULL  AFTER `edited` ;
ALTER TABLE `smolensk`.`vacancies` ADD COLUMN `closed` BIT NULL  AFTER `views_count` ;

INSERT INTO `smolensk`.`vacancies` (`title`, `company_id`, `city_id`, `contact_person`, `contact_phone`, `compensation1`, `compensation2`, `age1`, `age2`, `sex`, `description`, `responsibility`, `requirements`, `terms`, `work_region_id`, `work_city_id`, `work_phone`, `work_address`, `created`, `edited`, `views_count`) VALUES ('Менеджер по продажам', '1', '1', 'Старосельская Мария2', '5345345', '11111', '22222', '12', '16', '1', 'БЛАБЛАБЛА', 'блаблабла', 'блаблабла', 'ад', '2', '1', '34234123123', 'ул Хромцова 555', '18.09.2013', '18.09.2013', '0');
UPDATE `smolensk`.`vacancies` SET `created`='11.09.2013', `edited`='11.09.2013', `views_count`='0' WHERE `id`='1';
INSERT INTO `smolensk`.`vacancies` (`id`, `title`, `company_id`, `city_id`, `contact_person`, `contact_phone`, `compensation1`, `compensation2`, `age1`, `age2`, `sex`, `description`, `responsibility`, `requirements`, `terms`, `work_region_id`, `work_city_id`, `work_phone`, `work_address`, `created`, `edited`, `views_count`) VALUES ('3', 'Менеджер хирург', '2', '1', 'Селопетровская Ирина', '2123123', '4141', '111111', '18', '22', '1', 'БЛА БЛА БЛА ', 'БЛА БЛА БЛА', 'фвфывйцу й', 'ад', '2', '2', '123123123', 'ул ХХХХХХХ 22, 11', '2018-09-20 13:00:00', '2018-09-20 13:00:00', '0');

INSERT INTO `smolensk`.`vacancies_professionals` (`vacancy_id`, `professional_id`) VALUES ('2', '1');
INSERT INTO `smolensk`.`vacancies_professionals` (`vacancy_id`, `professional_id`) VALUES ('3', '1');
INSERT INTO `smolensk`.`vacancies_professionals` (`vacancy_id`, `professional_id`) VALUES ('2', '3');

INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('2', '2');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('2', '6');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('3', '9');

UPDATE `smolensk`.`vacancies_entries` SET `vacancy_id`='2' WHERE `id`='9';
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('2', '10');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('2', '14');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('2', '19');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('3', '2');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('3', '6');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('3', '9');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('3', '10');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('3', '14');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('3', '19');
