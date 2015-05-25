set names utf8;

alter table actions

add column published bit(1) default b'1' after approve;



update actions

set published = b'1'
where `status` = 1 and id > 0;



update actions

set published = b'0'
where `status` = 0 and id > 0;



alter table actions
drop column `status`;
