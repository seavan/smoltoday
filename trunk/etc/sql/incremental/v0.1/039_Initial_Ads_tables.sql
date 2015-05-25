CREATE TABLE `ad_advertisments` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(245) NOT NULL,
  `description` text,
  `price` float NOT NULL DEFAULT '0',
  `phone` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `ad_photos` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `ad_id` bigint(20) NOT NULL,
  `preview` varchar(50) DEFAULT NULL,
  `photo` varchar(50) DEFAULT NULL,
  `create_date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `ad_categories` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(245) NOT NULL,
  `parent_id` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `ad_field_descriptions` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(245) NOT NULL,
  `ad_category_id` bigint(20) NOT NULL,
  `is_multiple` bit(1) DEFAULT NULL,
  `is_anyvalue` bit(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `ad_lookup_values` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `description_id` bigint(20) NOT NULL,
  `value` varchar(245) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `ad_fields` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `ad_id` bigint(20) NOT NULL,
  `description_id` bigint(20) NOT NULL,
  `value_id` bigint(20) DEFAULT NULL,
  `value` varchar(245) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
