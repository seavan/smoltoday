-- MySQL dump 10.13  Distrib 5.5.30, for Win64 (x86)
--
-- Host: localhost    Database: smolensk
-- ------------------------------------------------------
-- Server version	5.5.30-log

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

SET NAMES utf8;
--
-- Table structure for table `city_prices_icons`
--

DROP TABLE IF EXISTS `city_prices_icons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `city_prices_icons` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(45) DEFAULT NULL,
  `css_class` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `city_prices_icons`
--

LOCK TABLES `city_prices_icons` WRITE;
/*!40000 ALTER TABLE `city_prices_icons` DISABLE KEYS */;
INSERT INTO `city_prices_icons` VALUES (1,'Топливо','fuel'),(2,'Такси','taxi'),(3,'Еда','eat'),(4,'Отель','hotel'),(5,'Недвижимость','realty');
/*!40000 ALTER TABLE `city_prices_icons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `city_prices`
--

DROP TABLE IF EXISTS `city_prices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `city_prices` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(145) DEFAULT NULL,
  `icon_id` bigint(20) DEFAULT NULL,
  `value` varchar(45) DEFAULT NULL,
  `html` varchar(245) DEFAULT NULL,
  `url_icon` varchar(145) DEFAULT NULL,
  `url_showall` varchar(145) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `city_prices`
--

LOCK TABLES `city_prices` WRITE;
/*!40000 ALTER TABLE `city_prices` DISABLE KEYS */;
INSERT INTO `city_prices` VALUES (1,'такси в городе',3,'300','','http://yandex.ru/',''),(2,'прочие радости',4,'3000','<p>\n	Поговорить? Обсудить проблемы? <strong>Звоните! +79269026899!</strong></p>\n','http://lenta.ru/news/2013/09/12/orbit/','http://smoltoday.ru/'),(3,'дизель / супериор',1,'42','','',''),(4,'кв. м в центре',5,'100 000','<p>\n	Недорогая недвижимость! Круглосуточная парковка! При покупке от 5 млн. руб. - ФУТБОЛКА в подарок.</p>\n','http://incom.ru/',''),(5,'до москвы',2,'5 000','<p>\n	До Москвы - с комфортом! Ереван-Такси.</p>\n','','');
/*!40000 ALTER TABLE `city_prices` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-09-12  8:47:22
