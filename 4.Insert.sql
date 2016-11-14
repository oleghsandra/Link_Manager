USE [LinkManagerDB];
GO

--Adding test user.
EXEC spUsers_Add 'Oleg', 'test@gmail.com', '1234';

--Adding link types.
EXEC spLinkType_Add 'Work'; --1
EXEC spLinkType_Add 'Study'; --2
EXEC spLinkType_Add 'Entertainment'; --3
EXEC spLinkType_Add 'Cooking'; --4
EXEC spLinkType_Add 'Sport'; --5
EXEC spLinkType_Add 'Other'; --6
EXEC spLinkType_Add 'News'; --7

EXEC spLink_AddNew 'EPAM.ITLAB.NET-2016-1-Schedule', 2, 'https://docs.google.com/spreadsheets/d/11f5PjBfcH4aHdgsZVx7ZpA-umXPh5GWiEO2x4kVr_xo/edit#gid=0', 1, '2016-10-02';
EXEC spLink_AddNew 'Facebook', 3, 'https://www.facebook.com/', 1, '2016-10-05';
EXEC spLink_AddNew 'Чоткий Паца - YouTube', 3, 'https://www.youtube.com/channel/UCpgNxHZ3TCbB3_Xczm9TIDg', 1, '2016-10-19';
EXEC spLink_AddNew 'SQL Tutorial', 2, 'http://www.w3schools.com/sql/default.asp', 1, '2016-10-19';
EXEC spLink_AddNew 'Instagram', 3, 'https://www.instagram.com/', 1, '2016-10-20';
EXEC spLink_AddNew 'Перекладач Google', 2, 'https://translate.google.com.ua', 1, '2016-10-22';
EXEC spLink_AddNew 'Speedtest.net by Ookla', 6, 'http://www.speedtest.net', 1, '2016-10-25';
EXEC spLink_AddNew 'Cloudinary Management', 6, 'https://cloudinary.com/console/welcome', 1, '2016-10-30';
EXEC spLink_AddNew 'Розклад для студентів «Львівська політехніка»', 2, 'http://www.lp.edu.ua/rozklad-dlya-studentiv', 1, '2016-10-30';
EXEC spLink_AddNew 'Онлайн-книга Изучаем ASP.NET MVC 4', 2, 'http://metanit.com/sharp/mvc/', 1, '2016-11-3';
EXEC spLink_AddNew 'Supernatural', 3, 'http://sverhestestvenoe.com', 1, '2016-11-07';
EXEC spLink_AddNew 'Мой диск – Google Диск', 2, 'https://drive.google.com/drive/u/0/my-drive', 1, '2016-11-09';
EXEC spLink_AddNew 'Protein Shake Recipes', 4, 'http://dailyburn.com/life/recipes/quick-easy-protein-shake-recipes/', 1, '2016-11-09';
EXEC spLink_AddNew 'Drones Garage | Channel 9', 3, 'https://channel9.msdn.com/Shows/Drones-Garage', 1;
EXEC spLink_AddNew 'Sport Life | Расписание занятий', 5, 'http://www.sportlife.ua/uk/services/schedule/14895', 1;
EXEC spLink_AddNew 'ТСН.ua', 7, 'http://tsn.ua/', 1;

EXEC spLink_SetFavorite 4, 'TRUE';
EXEC spLink_SetFavorite 7, 'TRUE';
EXEC spLink_SetFavorite 11, 'TRUE';
EXEC spLink_SetFavorite 14, 'TRUE';
EXEC spLink_SetFavorite 15, 'TRUE';

