SET NAMES utf8;

drop table `smolensk`.`photos`;

drop table `smolensk`.`restaurants_photos`;


CREATE  TABLE `smolensk`.`restaurant_photos` (
  `id` BIGINT NOT NULL AUTO_INCREMENT ,
  `thumbnail` VARCHAR(100) NULL ,
  `normal` VARCHAR(100) NULL ,
  `restaurtan_id` BIGINT NULL ,
  `is_main` BIT NULL ,
  PRIMARY KEY (`id`) );

ALTER TABLE `smolensk`.`restaurants` DROP COLUMN `photoUrl` ;

INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s1.jpg', 'b1.jpg', '1', 1);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s2.jpg', 'b2.jpg', '1', 0);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s3.jpg', 'b3.jpg', '1', 0);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s4.jpg', 'b4.jpg', '1', 0);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s1.jpg', 'b1.jpg', '1', 0);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s2.jpg', 'b2.jpg', '1', 0);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s3.jpg', 'b3.jpg', '1', 0);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s1.jpg', 'b1.jpg', '2', 0);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s2.jpg', 'b2.jpg', '2', 1);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s3.jpg', 'b3.jpg', '2', 0);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s4.jpg', 'b4.jpg', '2', 0);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s1.jpg', 'b1.jpg', '3', 0);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s2.jpg', 'b2.jpg', '3', 0);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s3.jpg', 'b3.jpg', '3', 1);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s4.jpg', 'b4.jpg', '4', 1);
INSERT INTO `smolensk`.`restaurant_photos` (`thumbnail`, `normal`, `restaurtan_id`, `is_main`) VALUES ('s2.jpg', 'b2.jpg', '4', 0);


