set names utf8;


ALTER TABLE `smolensk`.`vacancies` ADD COLUMN `created` DATETIME NULL  AFTER `work_address` , ADD COLUMN `edited` DATETIME NULL  AFTER `created` ;
