SET NAMES UTF8;

ALTER TABLE `smolensk`.`blog_photos` CHANGE COLUMN `blog_id` `blog_id` BIGINT(20) NULL DEFAULT NULL  AFTER `id` , CHANGE COLUMN `normal` `original` VARCHAR(100) NULL DEFAULT NULL COMMENT 'Оригинальная картинка'  AFTER `blog_id` , CHANGE COLUMN `thumbnail` `list_thumbnail` VARCHAR(100) NULL DEFAULT NULL COMMENT 'Картинка для отображения в списках'  , ADD COLUMN `normal_thumbnail` VARCHAR(100) NULL COMMENT 'Картинка та тот случай, если пользователь вставляет фото на 4мб'  AFTER `list_thumbnail` , ADD COLUMN `guid` VARCHAR(36) NULL  AFTER `normal_thumbnail` , ADD COLUMN `alt` VARCHAR(256) NULL  AFTER `guid` , ADD COLUMN `url` VARCHAR(256) NULL  AFTER `alt` ;

UPDATE `smolensk`.`blog_photos` SET `normal_thumbnail`='29FDE008-7DEA-4D93-ADAE-9CE7084CA99A.jpg' WHERE `id`='1';