SET NAMES utf8;

CREATE TABLE `quizzes` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(200) DEFAULT NULL,
  `datetime_start` datetime DEFAULT NULL,
  `datetime_finish` datetime DEFAULT NULL,
  `datetime_publish` datetime DEFAULT NULL,
  `is_main` bit(1) DEFAULT b'0',
  PRIMARY KEY (`id`)
);

CREATE TABLE `quiz_options` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `quiz_id` bigint(20) NOT NULL,
  `value` varchar(200) DEFAULT NULL,
  `order` int,
  PRIMARY KEY (`id`)
);

CREATE TABLE `quiz_results` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `account_id` bigint(20) NOT NULL,
  `quiz_id` bigint(20) NOT NULL,
  `quiz_option_id` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
);

INSERT INTO `quizzes` (`title`, `datetime_start`, `datetime_finish`, `is_main`) 
VALUES ('Какой банк в Смоленске самый удобный?', '2013-10-12 00:00:00', '2013-10-31 00:00:00', 1);

INSERT INTO `quiz_options` (`quiz_id`, `order`, `value`) VALUES ('1', 1, 'ВТБ 24');
INSERT INTO `quiz_options` (`quiz_id`, `order`, `value`) VALUES ('1', 2, 'Смоленский банк');
INSERT INTO `quiz_options` (`quiz_id`, `order`, `value`) VALUES ('1', 3, 'Сбербанк');