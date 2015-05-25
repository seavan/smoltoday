ALTER TABLE `smolensk`.`restaurants_photos` CHANGE COLUMN `id` `id` BIGINT(20) NOT NULL AUTO_INCREMENT  ;

INSERT INTO `photos` (`id`,`smallUrl`,`normalUrl`) VALUES (1,'/content/images/restSmall_1.jpg','/content/images/restBig_1.jpg');
INSERT INTO `photos` (`id`,`smallUrl`,`normalUrl`) VALUES (2,'/content/images/restSmall_2.jpg','/content/images/restBig_2.jpg');
INSERT INTO `photos` (`id`,`smallUrl`,`normalUrl`) VALUES (3,'/content/images/restSmall_3.jpg','/content/images/restBig_3.jpg');
INSERT INTO `photos` (`id`,`smallUrl`,`normalUrl`) VALUES (4,'/content/images/restSmall_4.jpg','/content/images/restBig_4.jpg');
INSERT INTO `photos` (`id`,`smallUrl`,`normalUrl`) VALUES (5,'/content/images/restSmall_1.jpg','/content/images/restBig_1.jpg');
INSERT INTO `photos` (`id`,`smallUrl`,`normalUrl`) VALUES (6,'/content/images/restSmall_2.jpg','/content/images/restBig_2.jpg');
INSERT INTO `photos` (`id`,`smallUrl`,`normalUrl`) VALUES (7,'/content/images/restSmall_3.jpg','/content/images/restBig_3.jpg');
INSERT INTO `photos` (`id`,`smallUrl`,`normalUrl`) VALUES (8,'/content/images/restSmall_4.jpg','/content/images/restBig_4.jpg');
INSERT INTO `photos` (`id`,`smallUrl`,`normalUrl`) VALUES (9,'/content/images/restSmall_1.jpg','/content/images/restBig_1.jpg');
INSERT INTO `photos` (`id`,`smallUrl`,`normalUrl`) VALUES (10,'/content/images/restSmall_2.jpg','/content/images/restBig_2.jpg');
INSERT INTO `photos` (`id`,`smallUrl`,`normalUrl`) VALUES (11,'/content/images/restSmall_3.jpg','/content/images/restBig_3.jpg');
INSERT INTO `photos` (`id`,`smallUrl`,`normalUrl`) VALUES (12,'/content/images/restSmall_4.jpg','/content/images/restBig_4.jpg');


INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('1', '1');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('2', '1');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('3', '1');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('4', '1');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('5', '1');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('6', '1');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('7', '1');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('8', '1');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('9', '1');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('10', '1');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('1', '2');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('2', '2');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('11', '2');
INSERT INTO `smolensk`.`restaurants_photos` (`photoId`, `restaurantId`) VALUES ('12', '2');