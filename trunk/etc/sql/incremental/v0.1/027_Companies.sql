SET NAMES utf8;

CREATE  TABLE `smolensk`.`companies` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `title` VARCHAR(60) NULL ,
  `work_time` VARCHAR(60) NULL ,
  `address` VARCHAR(100) NULL ,
  `www` VARCHAR(60) NULL ,
  `email` VARCHAR(60) NULL ,
  `phones` VARCHAR(60) NULL ,
  `leader` VARCHAR(60) NULL ,
  `description` VARCHAR(100) NULL ,
  `publish_date` DATETIME NULL ,
  `category_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );
  
INSERT INTO `smolensk`.`companies` (`title`, `work_time`, `address`, `www`, `email`, `phones`, `leader`, `description`, `publish_date`, `category_id`) VALUES ('ОАО Банк Петрокоммерц', 'Часы работы с 9:00 до 16:00', 'Смоленск, 3-я улица строителей 24, строение 1', 'bank-moscow.ru ', 'sale@bank-moscow.ru', '+7 (495) 228 1052, +7 (916) 200 02 14', 'Евстигнеев Константин Константинович, ген.директор', 'Оказывает услуги по выдаче кридитов, контроль кредитуемых лиц и услуг, оказываемых резидентами', '25.05.2013', '1');
INSERT INTO `smolensk`.`companies` (`title`, `work_time`, `address`, `www`, `email`, `phones`, `leader`, `description`, `publish_date`, `category_id`) VALUES ('ОАО ГКЧП', 'Круглосуточно', 'Везде, каждая 1я улица, 24', 'ГКЧП.рф', 'Админ@ГКЧП.рф', '+3 (666) 666 666', 'Сидоров Иван Петросович, капитан', 'Все под контролем и все четко', '12.12.2012', '2');
  
  CREATE  TABLE `smolensk`.`company_categories` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NULL ,
  PRIMARY KEY (`id`) );
  
INSERT INTO `smolensk`.`company_categories` (`name`) VALUES ('Банки, кредитные организации ');
INSERT INTO `smolensk`.`company_categories` (`name`) VALUES ('Другое');
  
  CREATE  TABLE `smolensk`.`company_kind_activities` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(60) NULL ,
  PRIMARY KEY (`id`) );
  
INSERT INTO `smolensk`.`company_kind_activities` (`name`) VALUES ('Юридические и консалтинговые услуги ');
INSERT INTO `smolensk`.`company_kind_activities` (`name`) VALUES ('банковские депозиты и кредиты');
INSERT INTO `smolensk`.`company_kind_activities` (`name`) VALUES ('акции и паевые фонды');
INSERT INTO `smolensk`.`company_kind_activities` (`name`) VALUES ('Убивает');
INSERT INTO `smolensk`.`company_kind_activities` (`name`) VALUES ('Грабит');
INSERT INTO `smolensk`.`company_kind_activities` (`name`) VALUES ('Четвертует');
  
  CREATE  TABLE `smolensk`.`companies_kind_activities` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `company_id` BIGINT NOT NULL ,
  `kind_activitiy_id` BIGINT NOT NULL ,
  PRIMARY KEY (`id`) );

INSERT INTO `smolensk`.`companies_kind_activities` (`company_id`, `kind_activitiy_id`) VALUES ('1', '1');
INSERT INTO `smolensk`.`companies_kind_activities` (`company_id`, `kind_activitiy_id`) VALUES ('1', '2');
INSERT INTO `smolensk`.`companies_kind_activities` (`company_id`, `kind_activitiy_id`) VALUES ('1', '3');
INSERT INTO `smolensk`.`companies_kind_activities` (`company_id`, `kind_activitiy_id`) VALUES ('2', '4');
INSERT INTO `smolensk`.`companies_kind_activities` (`company_id`, `kind_activitiy_id`) VALUES ('2', '5');
INSERT INTO `smolensk`.`companies_kind_activities` (`company_id`, `kind_activitiy_id`) VALUES ('2', '6');
  
  CREATE  TABLE `smolensk`.`company_files` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `file` VARCHAR(45) NULL ,
  `size` BIGINT NULL ,
  `title` VARCHAR(45) NULL ,
  `company_id` BIGINT NULL ,
  PRIMARY KEY (`id`) );
  
INSERT INTO `smolensk`.`company_files` (`file`, `size`, `title`, `company_id`) VALUES ('file1.zip', '455123', 'Презентация', '1');
INSERT INTO `smolensk`.`company_files` (`file`, `size`, `title`, `company_id`) VALUES ('file2.zip', '1544331', 'План', '1');
INSERT INTO `smolensk`.`company_files` (`file`, `size`, `title`, `company_id`) VALUES ('file3.zip', '12000000', 'Списки жертв', '2');
  
  CREATE  TABLE `smolensk`.`company_photos` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `thumbnaill` VARCHAR(45) NULL ,
  `normal` VARCHAR(45) NULL ,
  `is_main` BIT NULL ,
  `company_id` BIGINT NOT NULL ,
  PRIMARY KEY (`id`) );
  
INSERT INTO `smolensk`.`company_photos` (`thumbnaill`, `normal`, `is_main`, `company_id`) VALUES ('s1.jpg', 'b1.jpg', 1, '1');
INSERT INTO `smolensk`.`company_photos` (`thumbnaill`, `normal`, `is_main`, `company_id`) VALUES ('s2.jpg', 'b2.jpg', 0, '1');
INSERT INTO `smolensk`.`company_photos` (`thumbnaill`, `normal`, `is_main`, `company_id`) VALUES ('s3.jpg', 'b3.jpg', 0, '1');
INSERT INTO `smolensk`.`company_photos` (`thumbnaill`, `normal`, `is_main`, `company_id`) VALUES ('s1.jpg', 'b1.jpg', 0, '2');
INSERT INTO `smolensk`.`company_photos` (`thumbnaill`, `normal`, `is_main`, `company_id`) VALUES ('s2.jpg', 'b2.jpg', 1, '2');
INSERT INTO `smolensk`.`company_photos` (`thumbnaill`, `normal`, `is_main`, `company_id`) VALUES ('s3.jpg', 'b3.jpg', 0, '2');
INSERT INTO `smolensk`.`company_photos` (`thumbnaill`, `normal`, `is_main`, `company_id`) VALUES ('s4.jpg', 'b4.jpg', 0, '2');
INSERT INTO `smolensk`.`company_photos` (`thumbnaill`, `normal`, `is_main`, `company_id`) VALUES ('s1.jpg', 'b1.jpg', 0, '2');
INSERT INTO `smolensk`.`company_photos` (`thumbnaill`, `normal`, `is_main`, `company_id`) VALUES ('s2.jpg', 'b2.jpg', 0, '2');
  
  CREATE  TABLE `smolensk`.`company_rating` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `account_id` BIGINT NOT NULL ,
  `company_id` BIGINT NOT NULL ,
  `rating` INT NULL ,
  PRIMARY KEY (`id`) );
  
INSERT INTO `smolensk`.`company_rating` (`account_id`, `company_id`, `rating`) VALUES ('1', '1', '5');
INSERT INTO `smolensk`.`company_rating` (`account_id`, `company_id`, `rating`) VALUES ('2', '1', '4');
INSERT INTO `smolensk`.`company_rating` (`account_id`, `company_id`, `rating`) VALUES ('3', '1', '5');
INSERT INTO `smolensk`.`company_rating` (`account_id`, `company_id`, `rating`) VALUES ('4', '1', '5');
INSERT INTO `smolensk`.`company_rating` (`account_id`, `company_id`, `rating`) VALUES ('1', '2', '1');
INSERT INTO `smolensk`.`company_rating` (`account_id`, `company_id`, `rating`) VALUES ('2', '2', '1');
INSERT INTO `smolensk`.`company_rating` (`account_id`, `company_id`, `rating`) VALUES ('3', '2', '1');
INSERT INTO `smolensk`.`company_rating` (`account_id`, `company_id`, `rating`) VALUES ('4', '2', '1');

  
  