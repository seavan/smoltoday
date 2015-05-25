set names utf8;

ALTER TABLE `smolensk`.`restaurants` ADD COLUMN `can_book_table` BIT NULL DEFAULT 0  AFTER `map_description` ;