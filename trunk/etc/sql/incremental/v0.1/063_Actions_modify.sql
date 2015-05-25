set names utf8;

ALTER TABLE `smolensk`.`actions` 
ADD COLUMN `participiants_count` INT(11) NULL DEFAULT '0' AFTER `comment_count`;
