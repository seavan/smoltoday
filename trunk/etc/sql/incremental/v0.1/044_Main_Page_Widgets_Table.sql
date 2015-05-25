set names utf8;

CREATE  TABLE `smolensk`.`main_page_widgets` (
  `id` BIGINT NOT NULL ,
  `temperature` VARCHAR(16) NULL ,
  `sky` VARCHAR(32) NULL ,
  `sky_icon` VARCHAR(256) NULL ,
  `eur_price` DECIMAL(8,4) NOT NULL DEFAULT 0 ,
  `eur_change` DECIMAL(6,4) NOT NULL DEFAULT 0 ,
  `usd_price` DECIMAL(8,4) NOT NULL DEFAULT 0 ,
  `usd_change` DECIMAL(6,4) NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`id`) )
COMMENT = 'Для кеширования информации со сторонних сервисов';

INSERT INTO `smolensk`.`main_page_widgets`
(`id`,
`temperature`,
`sky`,
`sky_icon`)
VALUES
(
1,
'',
'',
''
);
