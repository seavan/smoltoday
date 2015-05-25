set names utf8;

ALTER TABLE `company_ownerships` CHANGE COLUMN `id` `id` BIGINT(20) NOT NULL AUTO_INCREMENT;

INSERT INTO `company_ownerships` (`title`) VALUES ('ЗАО');
INSERT INTO `company_ownerships` (`title`) VALUES ('ФГУП');

ALTER TABLE `vacancies` ADD COLUMN `url` VARCHAR(255) NULL  AFTER `is_publish` ;

