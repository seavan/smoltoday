SET NAMES utf8;

UPDATE `ad_field_descriptions` SET `is_anyvalue` = 0 WHERE `id` > 0;
UPDATE `ad_field_descriptions` SET `is_anyvalue` = 1 WHERE `id` in (2,3,4,6,7,10,11);
