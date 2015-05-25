set names utf8;

ALTER TABLE `sale_types` 
ADD COLUMN `order` INT NOT NULL AFTER `unlimited`;

update `sale_types` 
set `order` = `id`;

update `sale_types` 
set `order` = 1
where id = 4;

update `sale_types` 
set `order` = 4
where id = 1;
