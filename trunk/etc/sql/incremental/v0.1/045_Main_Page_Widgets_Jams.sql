set names utf8;

ALTER TABLE `smolensk`.`main_page_widgets` ADD COLUMN `jams_degree` INT NULL  AFTER `usd_change` , ADD COLUMN `jams_description` VARCHAR(64) NULL  AFTER `jams_degree`;

UPDATE `smolensk`.`main_page_widgets`
SET
jams_degree = 7, jams_description = 'движение плотное'
WHERE id = 1;
