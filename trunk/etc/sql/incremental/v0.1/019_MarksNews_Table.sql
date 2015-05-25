SET NAMES utf8;

CREATE  TABLE `news_marks` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,  
  `create_date` datetime NOT NULL,
  `account_id` bigint(20) NOT NULL ,
  `news_id` bigint(20) NOT NULL ,
  `mark` int(11) NOT NULL,
  PRIMARY KEY (`id`) 
 ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;
  

