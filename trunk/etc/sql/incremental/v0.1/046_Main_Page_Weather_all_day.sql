ALTER TABLE `smolensk`.`main_page_widgets` ADD COLUMN `sky_icon_morning` VARCHAR(256) NULL  AFTER `jams_description` , ADD COLUMN `sky_icon_afternoon` VARCHAR(256) NULL  AFTER `sky_icon_morning` , ADD COLUMN `sky_icon_evening` VARCHAR(256) NULL  AFTER `sky_icon_afternoon` , ADD COLUMN `sky_morning` VARCHAR(45) NULL  AFTER `sky_icon_evening` , ADD COLUMN `sky_afternoon` VARCHAR(45) NULL  AFTER `sky_morning` , ADD COLUMN `sky_evening` VARCHAR(45) NULL  AFTER `sky_afternoon` , ADD COLUMN `temperature_morning` VARCHAR(45) NULL  AFTER `sky_evening` , ADD COLUMN `temperature_afternoon` VARCHAR(45) NULL  AFTER `temperature_morning` , ADD COLUMN `temperature_evening` VARCHAR(45) NULL  AFTER `temperature_afternoon` , 
COMMENT = '' ;
