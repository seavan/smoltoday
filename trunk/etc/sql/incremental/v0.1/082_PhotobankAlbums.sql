SET NAMES utf8;

ALTER TABLE `accounts` ADD COLUMN `hide_birthdate` BIT(1) NULL DEFAULT b'0';

CREATE TABLE `photobank_user_albums` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `account_id` bigint(20) NOT NULL,
  `title` varchar(245) DEFAULT NULL,
  `shoot_date`  datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

ALTER TABLE `photobank_photos` ADD COLUMN `album_id` bigint(20) NULL;
