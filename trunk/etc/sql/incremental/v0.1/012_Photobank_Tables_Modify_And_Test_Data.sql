SET NAMES utf8;

ALTER TABLE `photobank_related_photos` DROP COLUMN `price`, DROP COLUMN `license_id`;
ALTER TABLE `photobank_related_photos` ADD COLUMN `original` BIT NOT NULL DEFAULT 0  AFTER `photo_id`;
ALTER TABLE `photobank_photos` DROP COLUMN `photo`, DROP COLUMN `filename`;

INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (1,1,1,'1280','1024','6b66570e-fd41-11e2-a424-f50845417a90.jpg','photo1.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (2,2,1,'1280','1024','6d0ccefc-fd42-11e2-a424-f50845417a90.jpg','photo2.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (3,3,1,'1280','1024','0d2674c4-fd43-11e2-a424-f50845417a90.jpg','photo3.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (4,4,1,'1280','1024','79790f54-fd43-11e2-a424-f50845417a90.jpg','photo4.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (5,5,1,'1280','1024','6d0ccefc-fd42-11e2-a424-f50845417a92.jpg','photo5.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (6,6,1,'1280','1024','6b66570e-fd41-11e2-a424-f50845417a92.jpg','photo6.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (7,7,1,'1280','1024','79790f54-fd43-11e2-a424-f50845417a92.jpg','photo7.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (8,8,1,'1280','1024','0d2674c4-fd43-11e2-a424-f50845417a92.jpg','photo8.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (9,9,1,'1280','1024','0d2674c4-fd43-11e2-a424-f50845417a94.jpg','photo9.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (10,10,1,'1280','1024','79790f54-fd43-11e2-a424-f50845417a94.jpg','photo10.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (11,11,1,'1280','1024','6b66570e-fd41-11e2-a424-f50845417a94.jpg','photo11.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (12,12,1,'1280','1024','6d0ccefc-fd42-11e2-a424-f50845417a94.jpg','photo12.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (13,13,1,'1280','1024','6d0ccefc-fd42-11e2-a424-f50845417a96.jpg','photo13.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (14,14,1,'1280','1024','79790f54-fd43-11e2-a424-f50845417a96.jpg','photo14.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (15,15,1,'1280','1024','0d2674c4-fd43-11e2-a424-f50845417a96.jpg','photo15.jpg');
INSERT INTO `photobank_related_photos` (`id`,`photo_id`,`original`,`width`,`height`,`photo`,`filename`) VALUES (16,16,1,'1280','1024','6b66570e-fd41-11e2-a424-f50845417a96.jpg','photo16.jpg');

CREATE TABLE `photobank_photo_prices` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `rel_photo_id` bigint(20) NOT NULL,
  `license_id` int(11) NOT NULL,
  `price` float NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (1,1,1,100);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (2,2,1,150);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (3,3,1,80);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (4,4,1,110);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (5,5,1,90);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (6,6,1,100);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (7,7,1,100);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (8,8,1,50);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (9,9,1,100);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (10,10,1,60);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (11,11,1,120);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (12,12,1,70);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (13,13,1,100);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (14,14,1,100);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (15,15,1,130);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (16,16,1,110);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (17,1,2,200);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (18,2,2,210);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (19,3,2,210);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (20,4,2,320);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (21,5,2,230);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (22,6,2,210);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (23,7,2,250);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (24,8,2,180);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (25,9,2,245);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (26,10,2,250);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (27,11,2,240);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (28,12,2,240);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (29,13,2,250);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (30,14,2,220);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (31,15,2,230);
INSERT INTO `photobank_photo_prices` (`id`,`rel_photo_id`,`license_id`,`price`) VALUES (32,16,2,200);



