SET NAMES utf8;

ALTER TABLE `smolensk`.`actions` 
ADD COLUMN `is_top` BIT(1) NULL DEFAULT b'0' AFTER `is_main`;

ALTER TABLE `smolensk`.`actions` 
ADD COLUMN `is_main_category` BIT(1) NULL DEFAULT b'0' AFTER `is_main`;

ALTER TABLE `smolensk`.`actions` 
ADD COLUMN `image_for_main` VARCHAR(100) NULL DEFAULT NULL AFTER `map_description`;

INSERT INTO `smolensk`.`actions`(`title`,`text`,`publish_date`,`is_main`,`is_main_category`,`is_top`, `rating`,`age_limit`,`comment_count`,`category_id`,`place_id`,`author`,`producer`,`statement`,`lecturer`,`performers`,`country`,`duration`,`start_date`,`price_min`,`price_max`,`site`,`google_link`,`facebook_link`,`twitter_link`,`vk_link`,`mail_link`,`odnoklassniki_link`, `image_for_main`)
VALUE("Малавита","<p>Что вы знаете о своих соседях? Особенно о тех, которые заявляются среди ночи… 
Так, однажды на тихой улочке провинциального французского городка поселился писатель по фамилии Блейк, со своим семейством и собакой Малавитой. 
На этом многовековое спокойствие города закончилось.</p>
<p>Почему сгорел местный супермаркет? Чем рискует медлительный водопроводчик? Что лежит в рюкзаке у милого парня в бежевых бриджах? 
Кто бы мог представить, что на самом деле мистер Блейк – бывший глава мафии, которого власти прячут здесь от преследования. 
И вот в городок приезжают люди «Коза Ностры»... Экранизация популярной одноименной комедии выдающегося современного писателя Тонино Бенаквисты.</p>",
'2013-09-23 22:45:00',0,1,1,0,16,0,1,2,null,"Люк Бессон",null,null,
"Роберт Де Ниро, Мишель Пфайффер, Томми Ли Джонс, Дианна Агрон, Доменик Ломбардоззи",
"США, Франция",116,'2013-09-19 00:00:00',150,400,null,"","","","","","", "s21.jpg");

INSERT INTO `smolensk`.`places`(`title`,`text`,`adress`,`price`,`work_time`,`location`,`phone`,`site`,`google_link`,`facebook_link`,`twitter_link`,`vk_link`,`mail_link`,`odnoklassniki_link`)
VALUES("Радуга Кино","<p>Mногозальный кинотеатр «Радуга Кино» приглашает посетить:</p>
<p><i> - пять комфортабельных кинозалов;</i></p>
<p><i> - парк развлечений 'Остров сокровищ' - лабиринт, игровые автоматы, карусель, 4D аттракцион;</i></p>
<p><i>- прямые трансляции спортивных мероприятий;</i></p>
<p><i>- караоке.</i></p>",
"проспект Андропова, 8, ТРЦ 'Мегаполис', 3 этаж","150-400 р.","Ежедн. 9:00-01:00",
"станция метро Коломенская","+7 (495) 663-36-64","http://www.radygakino.ru",null,null,null,null,null,null);

INSERT INTO `smolensk`.`actions_genres` (`action_id`, `genre_id`) VALUES ('2', '21');
INSERT INTO `smolensk`.`actions_genres` (`action_id`, `genre_id`) VALUES ('2', '23');

INSERT INTO `smolensk`.`actions_schedule` (`action_id`, `datetime`) VALUES ('2', '2013-09-25 20:00:00');
INSERT INTO `smolensk`.`actions_schedule` (`action_id`, `datetime`) VALUES ('2', '2013-09-26 21:00:00');

INSERT INTO `smolensk`.`actions`(`title`,`text`,`publish_date`,`is_main`,`is_main_category`,`is_top`, `rating`,`age_limit`,`comment_count`,`category_id`,`place_id`,`author`,`producer`,`statement`,`lecturer`,`performers`,`country`,`duration`,`start_date`,`price_min`,`price_max`,`site`,`google_link`,`facebook_link`,`twitter_link`,`vk_link`,`mail_link`,`odnoklassniki_link`, `image_for_main`)
VALUE("Гадкий Я 2","<p>Злодея в отставке Грю приглашают в Суперсекретную организацию, призванную защитить мир от зла. Вместе с Люси, красоткой суперагентшей, 
Грю должен выяснить, кто стоит за серией грандиозных преступлений, и куда, динамит их разбери, исчезают его милашки миньоны.</p>",
'2013-09-23 22:46:00',1,1,1,0,0,0,1,2,null,"Пьер Соффин, Крис Рено",null,null, "Стив Карелл, Рассел Брэнд, Аль Пачино",
"США",98,'2013-08-15 00:00:00',200,null,null,"","","","","","", "s31.jpg");

INSERT INTO `smolensk`.`actions_genres` (`action_id`, `genre_id`) VALUES ('3', '27');

INSERT INTO `smolensk`.`actions`(`title`,`text`,`publish_date`,`is_main`,`is_main_category`,`is_top`, `rating`,`age_limit`,`comment_count`,`category_id`,`place_id`,`author`,`producer`,`statement`,`lecturer`,`performers`,`country`,`duration`,`start_date`,`price_min`,`price_max`,`site`,`google_link`,`facebook_link`,`twitter_link`,`vk_link`,`mail_link`,`odnoklassniki_link`, `image_for_main`)
VALUE("Tablao Flamenсo","<p>Одна из лучших московских вечеринок для поклонников фламенко.</p>",
'2013-09-23 22:45:00',1,1,1,0,16,0,3,3,null,null,null,null, null,
"Испания, Россия",null,'2013-09-23 20:30:00',400,null,"http://www.ucclub.ru/event/23-09-2013/20-30/","","","","","","","s41.jpg");

INSERT INTO `smolensk`.`places`(`title`,`text`,`adress`,`price`,`work_time`,`location`,`phone`,`site`,`google_link`,`facebook_link`,`twitter_link`,`vk_link`,`mail_link`,`odnoklassniki_link`)
VALUES("Джаз-клуб 'Союз композиторов'","<p>В самом центре города, в тихом московском переулке расположился джаз клуб «Союз композиторов». 
Здесь каждый день звучит живая музыка разных направлений — традиционный джаз, современный джаз, фьюжн, джаз рок, латина, блюз, фанк, этно, танго.</p>
<p>Джаз-клуб «Союз композиторов» любит удивлять московскую публику концертами джазовых звезд, которые не жаловали Россию своим появлением до открытия клуба. 
В джаз клубе выступали мировые звезды, выдающиеся музыканты, которым рукоплещут миллионы. 
Иногда по вечерам джазовый клуб «Союз композиторов» превращается в танцевальный клуб с музыкой в стиле латино, где проходят фестивали танца, вечеринки, где звучат зажигательные меренга, сальса и румба в исполнении Viva Cuba. 
Испанские танцы в стиле фламенко или танго, также не редкость в клубе. По понедельникам на сцене джаз клуба «Союз композиторов» свои пьесы ставит камерный театр и проходят творческие вечера актеров театра. П
о вторникам играет Олег Киреев, а в часы Jam Session импровизируют талантливые молодые музыканты. Традиционно, в субботнем расписании клуба Алексей Козлов и «Арсенал». 
Блюз представлен в джаз клубе «Союз композиторов» концертами и фестивалями, где участвуют любимые музыканты: Леван Ломидзе, Петр Подгородецкий, Вадим Иващенко, Михаил Соколов «Петрович», Алексей Аграновский и другие. 
Среди посетителей клуба: любители джазовой музыки, интеллектуалы и творческая интеллигенция, а также деловые люди, политики, дипломаты, экспаты, не чуждые миру искусства. 
Джаз клубу «Союз композиторов» удается гармонично сочетать в себе как клуб, на сцене которого выступают мировые джазовые звезды, так иресторан, где представлена европейская кухня в самом широком разнообразии блюд. 
Сочетание джаза, хорошего вина и изысканной кухни особенно ценится гостями и, по общему мнению, делает это место редким и ценным уголком в центре столицы.</p>",
"Брюсов пер., д. 8/10, стр. 2","500-5000 р.","Ежедн. с 13:00 до последнего клиента",
"станция метро Охотный ряд, Пушкинская, Чеховская","+7 (495) 629-65-63","http://www.ucclub.ru",null,null,null,null,null,null);

INSERT INTO `smolensk`.`actions_genres` (`action_id`, `genre_id`) VALUES ('4', '31');

INSERT INTO `smolensk`.`actions_photos` (`thumbnail`, `action_id`, `is_main`) VALUES ('s42.jpg', '4', 1);
INSERT INTO `smolensk`.`actions_photos` (`thumbnail`, `action_id`, `is_main`) VALUES ('s32.jpg', '3', 1);