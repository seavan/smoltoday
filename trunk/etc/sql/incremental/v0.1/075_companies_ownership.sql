SET NAMES utf8;

CREATE  TABLE `smolensk`.`company_ownerships` (
  `id` BIGINT NOT NULL ,
  `title` VARCHAR(45) NULL ,
  PRIMARY KEY (`id`) );

ALTER TABLE `smolensk`.`companies` ADD COLUMN `ownership_id` BIGINT NULL  AFTER `map_description` ;

INSERT INTO `smolensk`.`company_ownerships` (`id`, `title`) VALUES ('1', 'ОАО');
INSERT INTO `smolensk`.`company_ownerships` (`id`, `title`) VALUES ('2', 'ООО');
INSERT INTO `smolensk`.`company_ownerships` (`id`, `title`) VALUES ('3', 'ИП');


CREATE  TABLE `smolensk`.`vacancy_facilities` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `title` VARCHAR(45) NULL ,
  PRIMARY KEY (`id`) );
  
 CREATE  TABLE `smolensk`.`vacancy_facility_variants` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `title` VARCHAR(45) NULL ,
  `facility_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );

 CREATE  TABLE `smolensk`.`vacancies_facilities` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `facility_id` BIGINT NULL ,
  `variant_id` BIGINT NULL ,
  `vacancy_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );

 CREATE  TABLE `smolensk`.`resumes_facilities` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `facility_id` BIGINT NULL ,
  `variant_id` BIGINT NULL ,
  `resume_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );

  
INSERT INTO `smolensk`.`vacancy_facilities` (`id`, `title`) VALUES (NULL, 'Другие льготы');
INSERT INTO `smolensk`.`vacancy_facilities` (`title`) VALUES ('Предоставление жилья');
INSERT INTO `smolensk`.`vacancy_facilities` (`title`) VALUES ('Транспорт');
INSERT INTO `smolensk`.`vacancy_facilities` (`title`) VALUES ('Питание');
INSERT INTO `smolensk`.`vacancy_facilities` (`title`) VALUES ('Здравоохранение');



INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Любые льготы', '2');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Отдельное жилье', '2');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Общежитие', '2');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Любые льготы', '3');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Доставка на работу', '3');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Оплата проезда к месту работы', '3');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Бесплатный проезд в транспорте', '3');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Железнодорожные льготы', '3');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Бесплатный проезд на отдых', '3');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Любые льготы', '4');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Питание за счет предприятия', '4');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Наличие столовой', '4');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Любые льготы', '5');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Медицинские учреждения', '5');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Санаторно-курортные учреждения', '5');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Спортивные сооружения', '5');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Дополнительное медецинское страхование (ДМС)', '5');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Любые льготы', '1');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Социальный пакет', '1');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Забота о детях', '1');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Предоставление спец.одежды', '1');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Льготный кредит на жилье', '1');
INSERT INTO `smolensk`.`vacancy_facility_variants` (`title`, `facility_id`) VALUES ('Льгтная пенсия', '1');