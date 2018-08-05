    create table Users (
        Id BIGINT not null,
       FirstName VARCHAR(100) not null,
       SecondName VARCHAR(100) not null,
       primary key (Id)
    );

    create table Goods (
        Id BIGINT not null,
       Amount MONEY not null DEFAULT 0,
       Name VARCHAR(1000) not null,
       primary key (Id)
    );

    create table TopGoods (
        GoodId BIGINT not null,
       PurchaseCount INT not null DEFAULT 0,
       primary key (GoodId)
    );

    create table Purchases (
        Id BIGINT not null,
       UserId BIGINT not null,
       TotalAmount MONEY not null DEFAULT 0,
	   CreatedAt TIMESTAMP not null,
       primary key (Id)
    );

    create table PurchaseItems (
        Id BIGINT not null,
       PurchaseId BIGINT not null,
	   GoodId BIGINT not null,
	   Amount MONEY not null DEFAULT 0,
	   Count INT not null DEFAULT 0,
       primary key (Id)
    );    

    alter table TopGoods 
        add constraint TopGoods_Goods_FK 
        foreign key (GoodId) 
        references Goods;


	alter table Purchases 
        add constraint Purchases_Users_FK 
        foreign key (UserId) 
        references Users;

	alter table PurchaseItems 
        add constraint PurchaseItems_Purchases_FK 
        foreign key (PurchaseId) 
        references Purchases;

	alter table PurchaseItems 
        add constraint PurchaseItems_Goods_FK 
        foreign key (GoodId) 
        references Goods;

    
insert into Users(Id, FirstName, SecondName) values(1, 'Иванов','Иван');
insert into Users(Id, FirstName, SecondName) values(2, 'Петров','Петр');
insert into Users(Id, FirstName, SecondName) values(3, 'Семёнов','Семён');
insert into Users(Id, FirstName, SecondName) values(4, 'Иванов','Петр');
insert into Users(Id, FirstName, SecondName) values(5, 'Петров','Семён');
insert into Users(Id, FirstName, SecondName) values(6, 'Семёнов','Иван');
insert into Users(Id, FirstName, SecondName) values(7, 'Иванов','Николай');
insert into Users(Id, FirstName, SecondName) values(8, 'Петров','Семён');
insert into Users(Id, FirstName, SecondName) values(9, 'Черепанова','Ольга');
insert into Users(Id, FirstName, SecondName) values(10, 'Кузнецова','Ольга');
insert into Users(Id, FirstName, SecondName) values(11, 'Миронов','Петр');
insert into Users(Id, FirstName, SecondName) values(12, 'Андреев','Евгений');
insert into Users(Id, FirstName, SecondName) values(13, 'Голь','Олеся');
insert into Users(Id, FirstName, SecondName) values(14, 'Оркестров','Эдуард');
insert into Users(Id, FirstName, SecondName) values(15, 'Оя','Ольга');
insert into Users(Id, FirstName, SecondName) values(16, 'Блюм','Анастасия');
insert into Users(Id, FirstName, SecondName) values(17, 'Куликов','Сергей');
insert into Users(Id, FirstName, SecondName) values(18, 'Сергеев','Артём');
insert into Users(Id, FirstName, SecondName) values(19, 'Иванов','Максим');
insert into Users(Id, FirstName, SecondName) values(20, 'Максимов','Иван');
insert into Users(Id, FirstName, SecondName) values(21, 'Горбачева','Екатерина');
insert into Users(Id, FirstName, SecondName) values(22, 'Ольшанский','Дмитрий');
insert into Users(Id, FirstName, SecondName) values(23, 'Рожин','Евгений');
insert into Users(Id, FirstName, SecondName) values(24, 'Кривошеев','Евгений');
insert into Users(Id, FirstName, SecondName) values(25, 'Рогозин','Иван');
insert into Users(Id, FirstName, SecondName) values(26, 'Мишин','Валентин');
insert into Users(Id, FirstName, SecondName) values(27, 'Егоров','Максим');

insert into Goods(Id, Name, Amount) values (1, 'СТОЛ-КНИЖКА СТК 2', 2663);
insert into Goods(Id, Name, Amount) values (2, 'СТОЛ-КНИЖКА СТК 1', 2231);
insert into Goods(Id, Name, Amount) values (3, 'ТАБУРЕТ Т 1', 304);
insert into Goods(Id, Name, Amount) values (4, 'СТОЛ ОБЕДЕННЫЙ № 1', 1195);
insert into Goods(Id, Name, Amount) values (5, 'ОБЕДЕННАЯ ГРУППА ОГ 1', 2188);
insert into Goods(Id, Name, Amount) values (6, 'КУХОННЫЙ ГАРНИТУР КАНТРИ 2,8 М', 28899);
insert into Goods(Id, Name, Amount) values (7, 'КУХОННЫЙ ГАРНИТУР СОФИЯ БЕЛЫЙ МЕТАЛЛИК', 9610);
insert into Goods(Id, Name, Amount) values (8, 'КУХОННЫЙ ГАРНИТУР ЛОФТ БЕЛЫЙ ГЛЯНЕЦ', 56990);
insert into Goods(Id, Name, Amount) values (9, 'ТАБУРЕТ СТ 08 (КОМПЛЕКТ 4 ШТУКИ)', 5480);
insert into Goods(Id, Name, Amount) values (10, 'ТАБУРЕТ СТ 04 (КОМПЛЕКТ 4 ШТУКИ)', 5320);
insert into Goods(Id, Name, Amount) values (11, 'СТУЛ ПОЛУМЯГКИЙ С-40А ВЕНГЕ/ФОРЕСТ', 5290);
insert into Goods(Id, Name, Amount) values (12, 'СТУЛ ПОЛУМЯГКИЙ С-40А', 2650);
insert into Goods(Id, Name, Amount) values (13, 'СТУЛ ПОЛУМЯГКИЙ С-39 А', 2660);
insert into Goods(Id, Name, Amount) values (14, 'СТУЛ МЯГКИЙ С-38 ЭТЮД', 4480);
insert into Goods(Id, Name, Amount) values (15, 'СТУЛ ПОЛУМЯГКИЙ С-36Б ПРЕСТИЖ', 5570);
insert into Goods(Id, Name, Amount) values (16, 'СТУЛ ЖЕСТКИЙ С-36А ПРЕСТИЖ', 5270);
insert into Goods(Id, Name, Amount) values (17, 'КУХНЯ УГЛОВАЯ ВИКТОРИЯ 18 (ШИРИНА 280X230 СМ)', 138072);
insert into Goods(Id, Name, Amount) values (18, 'КУХНЯ УГЛОВАЯ ВИКТОРИЯ 15 (ШИРИНА 150X200 СМ)', 74480);

insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (1, 1, 5198, '01.12.2018 12:15');
insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (2, 1, 3383, '02.12.2018 13:15');
insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (3, 2, 100819, '03.12.2018 12:15');
insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (4, 2, 66600, '04.12.2018 12:15');
insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (5, 3, 19220, '05.12.2018 13:15');
insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (6, 3, 31853, '06.12.2018 12:15');
insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (7, 4, 2663, '07.12.2018 12:15');
insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (8, 5, 2231, '08.12.2018 13:15');
insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (9, 6, 304, '09.12.2018 12:15');
insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (10, 6, 457895, '10.12.2018 12:15');

insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (1, 1, 1, 2663, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (2, 1, 2, 2231, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (3, 1, 3, 304, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (4, 2, 4, 1195, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (5, 2, 5, 2188, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (6, 3, 6, 28899, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (7, 3, 7, 9610, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (8, 3, 8, 56990, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (9, 3, 10, 5320, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (10, 4, 8, 56990, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (11, 4, 7, 9610, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (12, 5, 7, 19220, 2);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (13, 6, 6, 28899, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (14, 6, 3, 304, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (15, 6, 12, 2650, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (16, 7, 1, 2663, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (17, 8, 2, 2231, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (18, 9, 3, 304, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (19, 10, 4, 3585, 3);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (20, 10, 5, 2188, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (21, 10, 6, 452122, 1);

insert into TopGoods(GoodId, PurchaseCount) values (4, 4);