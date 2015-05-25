SET NAMES utf8;


alter table `accounts` add `facebook_id` varchar(36) DEFAULT NULL;
alter table `accounts` add `vk_id` varchar(36) DEFAULT NULL;
alter table `accounts` add `google_id` varchar(36) DEFAULT NULL;