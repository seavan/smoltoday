set names utf8;

CREATE  TABLE `smolensk`.`news_videos` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `news_id` BIGINT NULL ,
  `guid` VARCHAR(36) NULL ,
  `url` VARCHAR(255) NULL ,
  `original` VARCHAR(128) NULL ,
  `small_thumbnail` VARCHAR(128) NULL ,
  PRIMARY KEY (`id`) )
COMMENT = 'Таблица для хранения видео из новостей';