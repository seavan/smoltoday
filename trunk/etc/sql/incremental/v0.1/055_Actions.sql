set names utf8;

CREATE TABLE `action_categories` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) NOT NULL,
  `order_id` int DEFAULT '0',
  PRIMARY KEY (`id`)
);

INSERT INTO `smolensk`.`action_categories` (`order_id`, `title`) VALUES ('1', 'Кино');
INSERT INTO `smolensk`.`action_categories` (`order_id`, `title`) VALUES ('2', 'Театр');
INSERT INTO `smolensk`.`action_categories` (`order_id`, `title`) VALUES ('3', 'Концерты');
INSERT INTO `smolensk`.`action_categories` (`order_id`, `title`) VALUES ('4', 'Шоу');
INSERT INTO `smolensk`.`action_categories` (`order_id`, `title`) VALUES ('5', 'Рок');
INSERT INTO `smolensk`.`action_categories` (`order_id`, `title`) VALUES ('6', 'Выставки');
INSERT INTO `smolensk`.`action_categories` (`order_id`, `title`) VALUES ('7', 'Клубы');
INSERT INTO `smolensk`.`action_categories` (`order_id`, `title`) VALUES ('8', 'Встречи');
INSERT INTO `smolensk`.`action_categories` (`order_id`, `title`) VALUES ('9', 'Спорт');
INSERT INTO `smolensk`.`action_categories` (`order_id`, `title`) VALUES ('10', 'Детям');
INSERT INTO `smolensk`.`action_categories` (`order_id`, `title`) VALUES ('11', 'Прочее');

CREATE TABLE `smolensk`.`genres` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`id`)
);

INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Концерт');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Выставка');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Спектакль');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Мюзикл');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Детский спектакль');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Балет');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Поп');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Рок');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Джаз');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Блюз');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Авторская песня');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Шансон');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Классика');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Этно');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Фолк');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Альтернатива');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Инди');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Драма');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Мелодрама');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Фантастика');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Триллер');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Экшн');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Комедия');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Фантастика');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Мультфильм');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Боевик');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Анимация');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Ужасы');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Приключения');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Опера');
INSERT INTO `smolensk`.`genres` (`title`) VALUES ('Другое');

CREATE TABLE `smolensk`.`actions` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(245) DEFAULT NULL,
  `text` text,
  `publish_date` datetime DEFAULT NULL,
  `is_main` bit(1) DEFAULT b'0',
  `rating` int(11) DEFAULT '0',
  `age_limit` int(10) DEFAULT '0',
  `comment_count` int(11) DEFAULT '0',
  `category_id` bigint(20) NOT NULL,
  `place_id` bigint(20) DEFAULT NULL,
  `author` varchar(100) DEFAULT NULL,
  `producer` varchar(100) DEFAULT NULL,
  `statement` varchar(100) DEFAULT NULL,
  `lecturer` varchar(100) DEFAULT NULL,
  `performers` varchar(100) DEFAULT NULL,
  `country` varchar(100) DEFAULT NULL,
  `duration` int(10) DEFAULT NULL,
  `start_date` datetime DEFAULT NULL,
  `price_min` int(10) DEFAULT NULL,
  `price_max` int(10) DEFAULT NULL,
  `site` varchar(100) DEFAULT NULL, 
  `google_link` varchar(100) DEFAULT NULL, 
  `facebook_link` varchar(100) DEFAULT NULL, 
  `twitter_link` varchar(100) DEFAULT NULL, 
  `vk_link` varchar(100) DEFAULT NULL, 
  `mail_link` varchar(100) DEFAULT NULL, 
  `odnoklassniki_link` varchar(100) DEFAULT NULL, 
  PRIMARY KEY (`id`)
);

CREATE TABLE `actions_photos` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `thumbnail` varchar(100) DEFAULT NULL,
  `normal` varchar(100) DEFAULT NULL,
  `action_id` bigint(20) DEFAULT NULL,
  `is_main` bit(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE `smolensk`.`actions_genres` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `action_id` bigint(20) NOT NULL,
  `genre_id` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE `smolensk`.`actions_schedule` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `action_id` bigint(20) NOT NULL,
  `datetime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE `actions_rating` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `account_id` bigint(20) NOT NULL,
  `action_id` bigint(20) NOT NULL,
  `rating` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE `actions_comments` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `left_key` int(11) NOT NULL,
  `right_key` int(11) NOT NULL,
  `level` int(11) NOT NULL,
  `delete` bit(1) NOT NULL,
  `create_date` datetime NOT NULL,
  `account_id` bigint(20) NOT NULL,
  `text` text NOT NULL,
  `parent_id` bigint(20) DEFAULT NULL,
  `action_id` bigint(20) NOT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE `places` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) NOT NULL,
  `text` text DEFAULT NULL,
  `adress` varchar(100) DEFAULT NULL,
  `price` varchar(100) DEFAULT NULL,
  `work_time` varchar(100) DEFAULT NULL,
  `location` varchar(100) DEFAULT NULL,  
  `phone` varchar(100) DEFAULT NULL,
  `site` varchar(100) DEFAULT NULL,
  `google_link` varchar(100) DEFAULT NULL, 
  `facebook_link` varchar(100) DEFAULT NULL, 
  `twitter_link` varchar(100) DEFAULT NULL, 
  `vk_link` varchar(100) DEFAULT NULL, 
  `mail_link` varchar(100) DEFAULT NULL, 
  `odnoklassniki_link` varchar(100) DEFAULT NULL,
  `longitude` bigint(20) DEFAULT NULL, 
  `latitude` bigint(20) DEFAULT NULL,   
  PRIMARY KEY (`id`)
);

CREATE TABLE `places_rating` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `account_id` bigint(20) NOT NULL,
  `place_id` bigint(20) NOT NULL,
  `rating` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
);

INSERT INTO `smolensk`.`actions`(`title`,`text`,`publish_date`,`is_main`,`rating`,`age_limit`,`comment_count`,`category_id`,`place_id`,`author`,`producer`,`statement`,`lecturer`,`performers`,`country`,`duration`,`start_date`,`price_min`,`price_max`,`site`,`google_link`,`facebook_link`,`twitter_link`,`vk_link`,`mail_link`,`odnoklassniki_link`)
VALUE("Кавалер розы","<p>На исторической сцене Большого театра — опера эпохи венского сецессиона: </p><p>Композитор-модернист Рихард Штраус и драматург Гуго фон Гофмансталь привели в движение все слои венского общества, от авантюристов до графов, со вкусом высмеяли высший свет, заставили юношу переодеваться девушкой, а «кавалера розы» (проще говоря, свата) — самого стать женихом.</p><p>Инсценировал эту историю английский режиссер Стивен Лоулесс, бывший директор Глайндборнского фестиваля, а в главных партиях выступает приглашенная команда, одна из главных звезд которой — английский баритон Томас Аллен.</p>",'2013-09-16 00:00:00',1,0,16,0,2,1,null,"Стивен Лоулесс","Большой театр",null,"Иванов И.И., Петрова А.Ф., Куров А.И., Васин А.П.","Россия",120,'2012-05-12 00:00:00',100,1500,"www.site.ru","www.google_link.com","","www.twitter_link.com","","","");

INSERT INTO `smolensk`.`places`(`title`,`text`,`adress`,`price`,`work_time`,`location`,`phone`,`site`,`google_link`,`facebook_link`,`twitter_link`,`vk_link`,`mail_link`,`odnoklassniki_link`,`longitude`,`latitude`)
VALUES("Большой Драматический театр","<p>Российский Академический молодежный театр был основан в 1921 году Натальей Сац. В 30-х годах нынешний РАМТ получил имя Центрального детского</p><p>На исторической сцене Большого театра — опера эпохи венского сецессиона: </p><p>Композитор-модернист Рихард Штраус и драматург Гуго фон Гофмансталь привели в движение все слои венского общества, от авантюристов до графов, со вкусом высмеяли высший свет, заставили юношу переодеваться девушкой, а «кавалера розы» (проще говоря, свата) — самого стать женихом.</p><p>Инсценировал эту историю английский режиссер Стивен Лоулесс, бывший директор Глайндборнского фестиваля, а в главных партиях выступает приглашенная команда, одна из главных звезд которой — английский баритон Томас Аллен.</p>","Театральная пл., ул. 2","100-2000 р.","Ежедн. 12:00-15:00, 16:00-19:00, касса (Б. Дмитровка, 4): ежедн. 11:00-14:00, 15:00-19:00","На центральной площади сядьте на автоус №2 в сторону ул. Кирова, 5-ая остановка Театр РАМТ","+7 (495) 692-65-72, 692-00-69","http://www.ramt.ru","google_link",null,null,null,null,"odnoklassniki_link",0,0);

INSERT INTO `smolensk`.`actions_genres` (`action_id`, `genre_id`) VALUES ('1', '3');
INSERT INTO `smolensk`.`actions_genres` (`action_id`, `genre_id`) VALUES ('1', '30');

INSERT INTO `smolensk`.`actions_schedule` (`action_id`, `datetime`) VALUES ('1', '2013-09-15 13:00:00');
INSERT INTO `smolensk`.`actions_schedule` (`action_id`, `datetime`) VALUES ('1', '2013-09-16 13:00:00');
INSERT INTO `smolensk`.`actions_schedule` (`action_id`, `datetime`) VALUES ('1', '2013-09-16 20:00:00');
INSERT INTO `smolensk`.`actions_schedule` (`action_id`, `datetime`) VALUES ('1', '2013-09-17 13:00:00');
INSERT INTO `smolensk`.`actions_schedule` (`action_id`, `datetime`) VALUES ('1', '2013-09-19 13:00:00');

INSERT INTO `smolensk`.`actions_photos`(`thumbnail`,`normal`,`action_id`,`is_main`) VALUES ("s1.jpg","b1.jpg",1,1);
INSERT INTO `smolensk`.`actions_photos`(`thumbnail`,`normal`,`action_id`,`is_main`) VALUES ("s2.jpg","b2.jpg",1,0);
INSERT INTO `smolensk`.`actions_photos`(`thumbnail`,`normal`,`action_id`,`is_main`) VALUES ("s3.jpg","b3.jpg",1,0);