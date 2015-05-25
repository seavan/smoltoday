SET NAMES utf8;

  INSERT INTO `smolensk`.`vacancy_entry_categories` (`id`, `title`) VALUES ('6', 'Семейное положение');
  INSERT INTO `smolensk`.`vacancy_entry_categories` (`id`, `title`) VALUES ('7', 'Уровень образования');
  INSERT INTO `smolensk`.`vacancy_entry_categories` (`id`, `title`) VALUES ('8', 'Форма обучения');

  ALTER TABLE `smolensk`.`vacancy_entries` ADD COLUMN `only` VARCHAR(1) NULL  AFTER `vacancy_entry_category_id` ;


TRUNCATE TABLE `smolensk`.`vacancy_entries`;
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (1,'Не имеет значения',1,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (2,'От 1 года до 3 лет',1,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (3,'От 3 до 6 лет',1,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (4,'Более 6 лет',1,NULL);

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (5,'Не имеет значения',2,'v');
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (6,'Гражданин РФ',2,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (7,'Страны с безвизовым режимом',2,'v');
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (8,'Страны с визовым режимом',2,'v');

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (9,'Полная занятость',3,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (10,'Частичная занятость',3,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (11,'Проектная/Временная работа',3,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (12,'Волонтерство',3,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (13,'Стажировка',3,NULL);

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (14,'Полный день',4,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (15,'Сменный график',4,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (16,'Гибкий график',4,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (17,'Удаленная работа',4,NULL);

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (18,'Не имеет значения',5,'v');
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (19,'Высшее',5,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (20,'Неоконченное высшее',5,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (21,'Среднее',5,NULL);

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (22,'Замужем/Женат',6,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (23,'В разводе',6,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (24,'Не замужем/Не женат',6,NULL);

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (25,'Нет',7,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (26,'Среднее',7,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (27,'Неоконченное высшее',7,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (28,'Высшее',7,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (29,'Бакалавриат',7,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (30,'Магистратура',7,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (31,'Аспирантура',7,NULL);

INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (32,'Очная/Дневная',8,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (33,'Заочная/Вечерняя',8,NULL);
INSERT INTO `vacancy_entries` (`id`,`title`,`vacancy_entry_category_id`,`only`) VALUES (34,'Заочная/Дистанционная',8,NULL);


CREATE  TABLE `smolensk`.`resumes` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `post` VARCHAR(100) NULL ,
  `first_name` VARCHAR(45) NULL ,
  `middle_name` VARCHAR(45) NULL ,
  `last_name` VARCHAR(45) NULL ,
  `birth_date` DATE NULL ,
  `sex` INT NULL ,
  `salary` INT NULL ,
  `photo_url` VARCHAR(200) NULL ,
  `region_id` BIGINT NULL ,
  `city_id` BIGINT NULL ,
  `languages` VARCHAR(100) NULL ,
  `exp_years` INT NULL ,
  `exp_months` INT NULL ,
  `children` INT NULL ,
  `success_description` TEXT NULL ,
  `about` TEXT NULL ,
  `address` VARCHAR(100) NULL ,
  `phone` VARCHAR(30) NULL ,
  `email` VARCHAR(60) NULL ,
  `created` DATE NULL , 
  `edited` DATE NULL ,

  PRIMARY KEY (`id`) ); 
  
 CREATE  TABLE `smolensk`.`resumes_professionals` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `resume_id` BIGINT NULL ,
  `professional_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );

CREATE  TABLE `smolensk`.`resumes_entries` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `resume_id` BIGINT NULL ,
  `resume_entry_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );
  
  CREATE  TABLE `smolensk`.`resume_works` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `begin_date` DATE NULL ,
  `end_date` DATE NULL ,
  `post` VARCHAR(100) NULL ,
  `work_time_id` INT NULL ,
  `company_name` VARCHAR(200) NULL ,
  `success_description` TEXT NULL ,
  `resume_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );
  
 CREATE  TABLE `smolensk`.`resume_educations` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `begin_date` DATE NULL ,
  `end_date` DATE NULL ,
  `address` VARCHAR(200) NULL ,
  `education_entry_id` BIGINT NULL ,
  `faculty` VARCHAR(60) NULL ,
  `specialty` VARCHAR(60) NULL ,
  `form_entry_id` BIGINT NULL ,
  `resume_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );

CREATE  TABLE `smolensk`.`resume_trainings` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `begin_date` DATE NULL ,
  `end_date` DATE NULL ,
  `description` TEXT NULL ,
  `resume_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );
  
 CREATE  TABLE `smolensk`.`resume_links` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `url` VARCHAR(250) NULL ,
  `resume_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );

  
INSERT INTO `smolensk`.`resumes` (`post`, `first_name`, `middle_name`, `last_name`, `birth_date`, `sex`, `salary`, `region_id`, `city_id`, `languages`, `exp_years`, `exp_months`, `children`, `success_description`, `about`, `address`, `phone`, `email`) VALUES ('Архитектор комсических короблей', 'Гюнтер', 'Гюнтерович', 'Швауц', '1955-05-05', '1', '35000', '1', '1', 'Немецкий свободно, Английский свободно, русский со словарем', '15', '4', '3', '5 комисмических кораблей и один', 'умный я мужик', '55 дом по улице Комсомольская, 44 квартира', '902554412', 'gunter@mail.ru');
INSERT INTO `smolensk`.`resumes` (`post`, `first_name`, `middle_name`, `last_name`, `birth_date`, `sex`, `salary`, `region_id`, `city_id`, `languages`, `exp_years`, `exp_months`, `children`, `success_description`, `about`, `address`, `phone`, `email`) VALUES ('Архитектор мостов', 'Валера', 'Русланович', 'Петров', '1988-05-04', '1', '44000', '1', '1', 'Английский и русский', '3', '3', '0', 'Радужный мост', 'умею строить', 'Суфтина ул, 32 д, 22 кв', '9215554422', 'valer@gmail.com');
INSERT INTO `smolensk`.`resumes` (`post`, `first_name`, `middle_name`, `last_name`, `birth_date`, `sex`, `salary`, `region_id`, `city_id`, `languages`, `exp_years`, `exp_months`, `children`, `success_description`, `about`, `address`, `phone`, `email`) VALUES ('Менеджер по продажам пылесосов', 'Варвара', 'Михайловна', 'Смуглая', '1995-02-02', '2', '10000', '1', '1', 'Русский плохо', '0', '2', '0', 'Ничего не добилась пока', 'Хочу чего нибудь добиться', 'Боюсь сказать', '89025552211', 'varvar@mail.ru');


INSERT INTO `smolensk`.`resumes_professionals` (`resume_id`, `professional_id`) VALUES ('1', '1');
INSERT INTO `smolensk`.`resumes_professionals` (`resume_id`, `professional_id`) VALUES ('1', '4');
INSERT INTO `smolensk`.`resumes_professionals` (`resume_id`, `professional_id`) VALUES ('1', '6');
INSERT INTO `smolensk`.`resumes_professionals` (`resume_id`, `professional_id`) VALUES ('2', '1');
INSERT INTO `smolensk`.`resumes_professionals` (`resume_id`, `professional_id`) VALUES ('2', '3');
INSERT INTO `smolensk`.`resumes_professionals` (`resume_id`, `professional_id`) VALUES ('3', '1');
INSERT INTO `smolensk`.`resumes_professionals` (`resume_id`, `professional_id`) VALUES ('3', '7');

INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('1', '6');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('1', '14');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('1', '15');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('1', '19');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('1', '22');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('2', '6');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('2', '14');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('2', '16');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('2', '20');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('2', '24');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('3', '6');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('3', '14');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('3', '16');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('3', '21');
INSERT INTO `smolensk`.`resumes_entries` (`resume_id`, `resume_entry_id`) VALUES ('3', '23');
