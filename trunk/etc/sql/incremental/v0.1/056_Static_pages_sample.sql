-- MySQL dump 10.13  Distrib 5.6.13, for Win64 (x86_64)
--
-- Host: localhost    Database: smolensk
-- ------------------------------------------------------
-- Server version	5.6.13-log
SET NAMES utf8;

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `pages`
--

DROP TABLE IF EXISTS `pages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pages` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) DEFAULT NULL,
  `publish_date` datetime DEFAULT NULL,
  `html` text,
  `user_id` bigint(20) DEFAULT NULL,
  `alias` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pages`
--

LOCK TABLES `pages` WRITE;
/*!40000 ALTER TABLE `pages` DISABLE KEYS */;
INSERT INTO `pages` VALUES (6,'О проекте','1800-01-01 00:00:00','<p>\n	Здесь прекрасная информация о нашем проекте</p>\n',0,'about'),(7,'Часто задаваемые вопросы','1800-01-01 00:00:00','\n',0,'faq'),(8,'Соглашения','1800-01-01 00:00:00','<p>\n	Текст соглашения</p>\n',0,'agreement'),(9,'Партнерство','1800-01-01 00:00:00','<h2>\n	Почему мы предлагаем сотрудничество?</h2>\n<ul>\n	<li>\n		СКБ Контур&nbsp;&mdash; стремительно развивающаяся компания, нацеленная на&nbsp;постоянный рост. Мы делаем ставки на&nbsp;инновации, открытие и&nbsp;захват новых рынков. Если вы хотите быть в&nbsp;лидерах&nbsp;&mdash; нам по&nbsp;пути.</li>\n	<li>\n		Мы заинтересованы в&nbsp;развитии партнерской сети. За&nbsp;более чем 20-летнюю историю существования нашей компанией накоплен огромный опыт по&nbsp;налаживанию контактов и&nbsp;установлению обоюдовыгодного сотрудничества с&nbsp;самыми разными компаниями по&nbsp;всей стране.&nbsp;</li>\n</ul>\n<h2>\n	Коммерческие партнеры СКБ Контур</h2>\n<p>\n	Партнер для&nbsp;нас&nbsp;&mdash; это прежде всего друг, коллега и&nbsp;главный помощник. Взаимодействие СКБ Контур и&nbsp;партнеров строится на&nbsp;принципах диалога. Специалисты СКБ Контур открыты и&nbsp;готовы к&nbsp;взаимодействию: постоянному общению, совместной подготовке и&nbsp;проведению мероприятий, помощи в&nbsp;реализации интересных проектов.</p>\n<p>\n	<strong>Сотрудничество с&nbsp;СКБ Контур дает партнеру возможность:</strong></p>\n<ul>\n	<li>\n		зарабатывать, привлекая новых абонентов к&nbsp;работе с&nbsp;веб-сервисами СКБ Контур;</li>\n	<li>\n		зарабатывать, продавая программы и&nbsp;обновления;</li>\n	<li>\n		зарабатывать, продавая собственные услуги по&nbsp;внедрению, настройке и&nbsp;сопровождению программ;</li>\n	<li>\n		зарабатывать, безупречной технической поддержкой завоевывая авторитет у&nbsp;клиентов и&nbsp;обеспечивая продления договоров;</li>\n	<li>\n		развивать бизнес, расширяя спектр услуг, предоставляемых клиентам;</li>\n	<li>\n		повышать имидж и&nbsp;значимость собственного имени за&nbsp;счет продвижения качества, простоты использования и&nbsp;квалифицированной поддержки программ СКБ Контур;</li>\n	<li>\n		участвовать в&nbsp;семинарах и&nbsp;других мероприятиях;</li>\n	<li>\n		постоянно развиваться, получать новые знания и&nbsp;возможности.</li>\n</ul>\n<p>\n	<strong>Партнеры СКБ Контур&nbsp;&mdash; это дружная команда профессионалов!</strong></p>\n',0,'partnership');
/*!40000 ALTER TABLE `pages` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-09-16  4:39:34
