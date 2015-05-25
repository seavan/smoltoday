SET NAMES utf8;


INSERT INTO `photobank_tags` (`title`) VALUES ('горы');
INSERT INTO `photobank_tags` (`title`) VALUES ('пейзаж');
INSERT INTO `photobank_tags` (`title`) VALUES ('фрукты');
INSERT INTO `photobank_tags` (`title`) VALUES ('облака');
INSERT INTO `photobank_tags` (`title`) VALUES ('обои');

INSERT INTO `photobank_photo_tags` (`tag_id`, `photo_id`) VALUES ('5', '1');
INSERT INTO `photobank_photo_tags` (`tag_id`, `photo_id`) VALUES ('2', '2');
INSERT INTO `photobank_photo_tags` (`tag_id`, `photo_id`) VALUES ('4', '2');
INSERT INTO `photobank_photo_tags` (`tag_id`, `photo_id`) VALUES ('1', '3');
INSERT INTO `photobank_photo_tags` (`tag_id`, `photo_id`) VALUES ('2', '3');
INSERT INTO `photobank_photo_tags` (`tag_id`, `photo_id`) VALUES ('4', '3');
INSERT INTO `photobank_photo_tags` (`tag_id`, `photo_id`) VALUES ('3', '4');
INSERT INTO `photobank_photo_tags` (`tag_id`, `photo_id`) VALUES ('5', '4');

INSERT INTO `photobank_photos_rating` (`photo_id`, `account_id`, `rating`) VALUES ('1', '1', '3');
INSERT INTO `photobank_photos_rating` (`photo_id`, `account_id`, `rating`) VALUES ('1', '2', '5');
INSERT INTO `photobank_photos_rating` (`photo_id`, `account_id`, `rating`) VALUES ('1', '4', '4');
INSERT INTO `photobank_photos_rating` (`photo_id`, `account_id`, `rating`) VALUES ('2', '1', '4');
INSERT INTO `photobank_photos_rating` (`photo_id`, `account_id`, `rating`) VALUES ('2', '2', '4');
INSERT INTO `photobank_photos_rating` (`photo_id`, `account_id`, `rating`) VALUES ('3', '4', '3');
INSERT INTO `photobank_photos_rating` (`photo_id`, `account_id`, `rating`) VALUES ('4', '1', '3');
INSERT INTO `photobank_photos_rating` (`photo_id`, `account_id`, `rating`) VALUES ('4', '3', '3');
INSERT INTO `photobank_photos_rating` (`photo_id`, `account_id`, `rating`) VALUES ('4', '2', '4');
INSERT INTO `photobank_photos_rating` (`photo_id`, `account_id`, `rating`) VALUES ('4', '4', '5');