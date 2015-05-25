SET NAMES utf8;


CREATE TABLE `restaurant_rating` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `account_id` bigint(20) NOT NULL,
  `restaurant_id` bigint(20) NOT NULL,
  `rating` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


INSERT INTO `smolensk`.`restaurants` (`title`, `phone`, `address`, `holes_count`, `work_time`, `photoUrl`, `vip`) VALUES ('Майтай', '123-123-222', 'Дерябино, д 44, стр 1', '1 зал - 60 мест', '24ч', '/content/images/rest_1.jpg', 0);
INSERT INTO `smolensk`.`restaurants` (`title`, `phone`, `address`, `holes_count`, `work_time`, `photoUrl`, `vip`) VALUES ('Якида', '111-222-333', 'Гайдара, д 45, стр 6', '1 зал - 20 мест', '8:00-24:00', '/content/images/rest_2.jpg', 0);


ALTER TABLE `smolensk`.`restaurants_entries` DROP COLUMN `restaurants_entriescol` ;


INSERT INTO `smolensk`.`restaurants_entries` (`restaurant_id`, `entry_id`) VALUES ('3', '36');
INSERT INTO `smolensk`.`restaurants_entries` (`restaurant_id`, `entry_id`) VALUES ('3', '41');
INSERT INTO `smolensk`.`restaurants_entries` (`restaurant_id`, `entry_id`) VALUES ('3', '43');
UPDATE `smolensk`.`restaurants_entries` SET `entry_id`='46' WHERE `id`='4';
INSERT INTO `smolensk`.`restaurants_entries` (`restaurant_id`, `entry_id`) VALUES ('3', '44');
INSERT INTO `smolensk`.`restaurants_entries` (`restaurant_id`, `entry_id`) VALUES ('3', '46');
INSERT INTO `smolensk`.`restaurants_entries` (`restaurant_id`, `entry_id`) VALUES ('4', '36');
INSERT INTO `smolensk`.`restaurants_entries` (`restaurant_id`, `entry_id`) VALUES ('4', '38');
INSERT INTO `smolensk`.`restaurants_entries` (`restaurant_id`, `entry_id`) VALUES ('4', '43');
INSERT INTO `smolensk`.`restaurants_entries` (`restaurant_id`, `entry_id`) VALUES ('4', '44');
INSERT INTO `smolensk`.`restaurants_entries` (`restaurant_id`, `entry_id`) VALUES ('4', '45');
INSERT INTO `smolensk`.`restaurants_entries` (`restaurant_id`, `entry_id`) VALUES ('4', '46');



INSERT INTO `smolensk`.`restaurant_rating` (`account_id`, `restaurant_id`, `rating`) VALUES ('1', '1', '5');
INSERT INTO `smolensk`.`restaurant_rating` (`account_id`, `restaurant_id`, `rating`) VALUES ('1', '2', '4');
INSERT INTO `smolensk`.`restaurant_rating` (`account_id`, `restaurant_id`, `rating`) VALUES ('1', '3', '4');
INSERT INTO `smolensk`.`restaurant_rating` (`account_id`, `restaurant_id`, `rating`) VALUES ('1', '4', '2');
INSERT INTO `smolensk`.`restaurant_rating` (`account_id`, `restaurant_id`, `rating`) VALUES ('2', '1', '4');
INSERT INTO `smolensk`.`restaurant_rating` (`account_id`, `restaurant_id`, `rating`) VALUES ('2', '2', '3');
INSERT INTO `smolensk`.`restaurant_rating` (`account_id`, `restaurant_id`, `rating`) VALUES ('2', '3', '5');
INSERT INTO `smolensk`.`restaurant_rating` (`account_id`, `restaurant_id`, `rating`) VALUES ('3', '1', '4');
INSERT INTO `smolensk`.`restaurant_rating` (`account_id`, `restaurant_id`, `rating`) VALUES ('3', '2', '3');
INSERT INTO `smolensk`.`restaurant_rating` (`account_id`, `restaurant_id`, `rating`) VALUES ('3', '3', '1');
INSERT INTO `smolensk`.`restaurant_rating` (`account_id`, `restaurant_id`, `rating`) VALUES ('4', '4', '4');
INSERT INTO `smolensk`.`restaurant_rating` (`account_id`, `restaurant_id`, `rating`) VALUES ('4', '3', '3');
