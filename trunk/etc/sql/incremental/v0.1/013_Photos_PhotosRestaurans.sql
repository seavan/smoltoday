SET NAMES utf8;

CREATE  TABLE `smolensk`.`photos` (
  `id` BIGINT(20) NOT NULL ,
  `smallUrl` VARCHAR(255) NULL ,
  `normalUrl` VARCHAR(255) NULL ,
  PRIMARY KEY (`id`) );
  
  CREATE  TABLE `smolensk`.`restaurants_photos` (
  `id` BIGINT(20) NOT NULL ,
  `photoId` BIGINT(20) NULL ,
  `restaurantId` BIGINT(20) NULL ,
  PRIMARY KEY (`id`) );
