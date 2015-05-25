SET NAMES utf8;

CREATE TABLE `my_messages` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(245) DEFAULT NULL,
  `text` text,
  `link` varchar(245) DEFAULT NULL,
  `link_name` varchar(100) DEFAULT NULL,
  `create_date` datetime DEFAULT NULL,
  `is_new` bit(1) DEFAULT b'0',  
  `account_id` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;