SET NAMES utf8;

alter table `comments_news` add `parent_id` bigint(20) DEFAULT NULL;
alter table `comments_news` add `news_id` bigint(20) NOT NULL;