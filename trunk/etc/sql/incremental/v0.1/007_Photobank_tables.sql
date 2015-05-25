SET NAMES utf8;


CREATE TABLE `photobank_categories` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(245) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `photobank_categories` (`id`,`title`) VALUES (1,'Автомобили');
INSERT INTO `photobank_categories` (`id`,`title`) VALUES (2,'Еда и напитки');
INSERT INTO `photobank_categories` (`id`,`title`) VALUES (3,'Общество');
INSERT INTO `photobank_categories` (`id`,`title`) VALUES (4,'Природа');
INSERT INTO `photobank_categories` (`id`,`title`) VALUES (5,'Животные');
INSERT INTO `photobank_categories` (`id`,`title`) VALUES (6,'Фоны');

CREATE TABLE `photobank_tags` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(150) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `photobank_photo_tags` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `tag_id` bigint(20) NOT NULL,
  `photo_id` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `photobank_photos_rating` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `photo_id` bigint(20) NOT NULL,
  `account_id` bigint(20) NOT NULL,
  `rating` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;




