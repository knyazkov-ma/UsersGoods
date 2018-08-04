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

insert into Goods(Id, Name, Amount) values (1, 'Пианино', 450004.51);
insert into Goods(Id, Name, Amount) values (2, 'Телевизор', 120000);
insert into Goods(Id, Name, Amount) values (3, 'Стол', 20000.49);

insert into TopGoods(GoodId, PurchaseCount) values (2, 22);

insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (1, 1, 456.45, '12.12.2018 12:15');
insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (2, 1, 456.45, '13.12.2018 13:15');
insert into Purchases(Id, UserId, TotalAmount, CreatedAt) values (3, 1, 456.45, '14.12.2018 12:15');

insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (1, 1, 1, 452122, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (2, 2, 1, 452122, 1);
insert into PurchaseItems(Id, PurchaseId, GoodId, Amount, Count) values (3, 3, 1, 452122, 2);