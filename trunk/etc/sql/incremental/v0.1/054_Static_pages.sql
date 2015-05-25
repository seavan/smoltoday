delimiter $$

CREATE TABLE `pages` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) DEFAULT NULL,
  `publish_date` datetime DEFAULT NULL,
  `html` text,
  `user_id` bigint(20) DEFAULT NULL,
  `alias` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8$$

delimiter $$

CREATE TABLE `pages_files` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) DEFAULT NULL,
  `file_name` varchar(255) DEFAULT NULL,
  `publish_date` datetime DEFAULT NULL,
  `uid` varchar(80) DEFAULT NULL,
  `extension` varchar(10) DEFAULT NULL,
  `user_id` bigint(20) DEFAULT NULL,
  `page_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8$$

