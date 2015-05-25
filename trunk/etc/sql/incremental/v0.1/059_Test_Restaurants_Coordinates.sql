SET NAMES utf8;

UPDATE `restaurants`
SET
`coordinates` = '32.066386,54.784959',
`map_title` = 'Золотой фазан',
`map_description` = 'Мы делаем жизнь вкуснее!'
WHERE id = 1;

UPDATE `restaurants`
SET
`coordinates` = '32.03892,54.787043',
`map_title` = 'Серебрянный дом',
`map_description` = 'Есть WiFi'
WHERE id = 2;
