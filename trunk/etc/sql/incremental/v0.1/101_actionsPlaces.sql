set names utf8;

CREATE TABLE `smolensk`.`actions_places` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `action_id` bigint(20) NOT NULL,
  `place_id` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
);

ALTER TABLE `smolensk`.`actions` 
DROP COLUMN `place_id`;

ALTER TABLE `smolensk`.`actions_schedule` 
CHANGE COLUMN `action_id` `action_place_id` BIGINT(20) NOT NULL ;

ALTER TABLE `smolensk`.`places` 
CHANGE COLUMN `location` `location` VARCHAR(200) NULL DEFAULT NULL ;

ALTER TABLE `smolensk`.`places` 
CHANGE COLUMN `work_time` `work_time` VARCHAR(200) NULL DEFAULT NULL ;
