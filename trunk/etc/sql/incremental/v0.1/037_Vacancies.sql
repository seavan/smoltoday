set names utf8;



CREATE  TABLE `smolensk`.`vacancy_entry_categories` (
  `id` BIGINT NOT NULL,
  `title` VARCHAR(45) NULL ,
  PRIMARY KEY (`id`) );

INSERT INTO `smolensk`.`vacancy_entry_categories` (`id`, `title`) VALUES ('1', 'Опыт работы');
INSERT INTO `smolensk`.`vacancy_entry_categories` (`id`, `title`) VALUES ('2', 'Гражданство');
INSERT INTO `smolensk`.`vacancy_entry_categories` (`id`, `title`) VALUES ('3', 'Тип занятости');
INSERT INTO `smolensk`.`vacancy_entry_categories` (`id`, `title`) VALUES ('4', 'График работы');
INSERT INTO `smolensk`.`vacancy_entry_categories` (`id`, `title`) VALUES ('5', 'Образование');



CREATE  TABLE `smolensk`.`vacancy_entries` (
  `id` BIGINT NOT NULL,
  `title` VARCHAR(100) NULL ,
  `vacancy_entry_category_id` INT NULL ,
  PRIMARY KEY (`id`) );

INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('1', 'Не имеет значения', '1');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('2', 'От 1 года до 3 лет', '1');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('3', 'От 3 до 6 лет', '1');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('4', 'Более 6 лет', '1');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('5', 'Не имеет значения', '2');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('6', 'Гражданин РФ', '2');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('7', 'Страны с безвизовым режимом', '2');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('8', 'Страны с визовым режимом', '2');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('9', 'Полная занятость', '3');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('10', 'Частичная занятость', '3');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('11', 'Проектная/Временная работа', '3');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('12', 'Волонтерство', '3');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('13', 'Стажировка', '3');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('14', 'Полный день', '4');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('15', 'Сменный график', '4');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('16', 'Гибкий график', '4');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('17', 'Удаленная работа', '4');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('18', 'Не имеет значения', '5');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('19', 'Высшее', '5');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('20', 'Неоконченное высшее', '5');
INSERT INTO `smolensk`.`vacancy_entries` (`id`, `title`, `vacancy_entry_category_id`) VALUES ('21', 'Среднее', '5');



CREATE  TABLE `smolensk`.`vacancy_professionals` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `title` VARCHAR(60) NULL ,
  `parent_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );
  
INSERT INTO `smolensk`.`vacancy_professionals` (`id`, `title`) VALUES ('1', 'Строительство и ремонт');
INSERT INTO `smolensk`.`vacancy_professionals` (`id`, `title`, `parent_id`) VALUES ('2', 'Ремонт', '1');
INSERT INTO `smolensk`.`vacancy_professionals` (`id`, `title`, `parent_id`) VALUES ('3', 'Нелегальная иммиграция', '1');
INSERT INTO `smolensk`.`vacancy_professionals` (`id`, `title`, `parent_id`) VALUES ('4', 'Малярия-штукария', '1');
INSERT INTO `smolensk`.`vacancy_professionals` (`id`, `title`, `parent_id`) VALUES ('5', 'Сервисные услуги', '1');
INSERT INTO `smolensk`.`vacancy_professionals` (`id`, `title`) VALUES ('6', 'Туризм, гостиничный сервис');
INSERT INTO `smolensk`.`vacancy_professionals` (`id`, `title`, `parent_id`) VALUES ('7', 'Продажа путевок', '6');
INSERT INTO `smolensk`.`vacancy_professionals` (`id`, `title`, `parent_id`) VALUES ('8', 'Отправка на отдых', '6');

 
  
CREATE  TABLE `smolensk`.`regions` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `title` VARCHAR(100) NULL ,
  PRIMARY KEY (`id`) );
  
INSERT INTO `smolensk`.`regions` (`title`) VALUES ('Смоленская область');
INSERT INTO `smolensk`.`regions` (`title`) VALUES ('Архангельская область');
 
 
 
CREATE  TABLE `smolensk`.`cities` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `title` VARCHAR(50) NULL ,
  `region_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );
  
INSERT INTO `smolensk`.`cities` (`title`, `region_id`) VALUES ('Смоленск', '1');
INSERT INTO `smolensk`.`cities` (`title`, `region_id`) VALUES ('Вязьма', '1');
INSERT INTO `smolensk`.`cities` (`title`, `region_id`) VALUES ('Архангельск', '2');
INSERT INTO `smolensk`.`cities` (`title`, `region_id`) VALUES ('Северодвинск', '2');

  
 
CREATE  TABLE `smolensk`.`vacancies` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `title` VARCHAR(60) NULL ,
  `company_id` BIGINT NULL ,
  `city_id` BIGINT NULL ,
  `contact_person` VARCHAR(60) NULL ,
  `contact_phone` VARCHAR(30) NULL ,
  `compensation1` INT NULL ,
  `compensation2` INT NULL ,
  `age1` INT NULL ,
  `age2` INT NULL ,
  `sex` INT NULL ,
  `description` TEXT NULL ,
  `responsibility` TEXT NULL ,
  `requirements` TEXT NULL ,
  `terms` TEXT NULL ,
  `work_region_id` BIGINT NULL ,
  `work_city_id` BIGINT NULL ,
  `work_phone` VARCHAR(30) NULL ,
  `work_address` VARCHAR(100) NULL ,
  PRIMARY KEY (`id`) );

INSERT INTO `smolensk`.`vacancies` (`title`, `company_id`, `city_id`, `contact_person`, `contact_phone`, `compensation1`, `compensation2`, `age1`, `age2`, `sex`, `description`, `responsibility`, `requirements`, `terms`, `work_region_id`, `work_city_id`, `work_phone`, `work_address`) VALUES ('Менеджер по продажам', '1', '1', 'Старосельская Мария', '89635555500', '45000', '80000', '18', '24', '1', 'В связи с расширением штата требуются молодые люди на должность менеджера по продажам в статус помощника руководителя команды.', 'Решение вопросов по аренде‚ рекламе для проведения мероприятия по сбыту товара', 'Только мужчины в возрасте от 18 до 24‚ готовые трудиться полный рабочий день.', 'Загруженный график 6/1', '2', '1', '955-444-22-11', 'ул. Думская 5/22');



CREATE  TABLE `smolensk`.`vacancies_entries` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `vacancy_id` BIGINT NULL ,
  `vacancy_entry_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );
  
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('1', '2');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('1', '6');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('1', '9');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('1', '10');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('1', '14');
INSERT INTO `smolensk`.`vacancies_entries` (`vacancy_id`, `vacancy_entry_id`) VALUES ('1', '19');

  
  
CREATE  TABLE `smolensk`.`vacancies_professionals` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `vacancy_id` BIGINT NOT NULL ,
  `professional_id` BIGINT NOT NULL ,
  PRIMARY KEY (`id`) );

INSERT INTO `smolensk`.`vacancies_professionals` (`vacancy_id`, `professional_id`) VALUES ('1', '1');
INSERT INTO `smolensk`.`vacancies_professionals` (`vacancy_id`, `professional_id`) VALUES ('1', '3');
INSERT INTO `smolensk`.`vacancies_professionals` (`vacancy_id`, `professional_id`) VALUES ('1', '4');
INSERT INTO `smolensk`.`vacancies_professionals` (`vacancy_id`, `professional_id`) VALUES ('1', '6');
INSERT INTO `smolensk`.`vacancies_professionals` (`vacancy_id`, `professional_id`) VALUES ('1', '8');