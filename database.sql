create database QuanKaraoke3
go
use QuanKaraoke3
go

-- food
-- room
-- foodcategory
-- account
-- bill
-- billInfo

create table Room
(
	id int identity primary key,
	Name nvarchar(100) not null,
	status nvarchar(100) not null default N'trống' , -- trong : dc dat: co nguoi.
	isDelete int not null default 0 -- ko la chua xoa 1 la da xoa
)
go

create table account
(
	id int identity primary key,
	displayName nvarchar(100) not null,
	userName nvarchar(100) not null,
	password nvarchar(100) not null,
	type int not null --0 nhan vien --1 quan ly
)
go

create table foodCategory
(
	 id int identity primary key,
	 Name nvarchar(100),
	 isDelete int not null default 0 -- ko la chua xoa 1 la da xoa
)
go

create table food
(
	id int identity primary key,
	 Name nvarchar(100) not null default N'chưa đặt tên',
	 idCategory int not null,
	 price float not null,
	 isDelete int not null default 0, -- ko la chua xoa 1 la da xoa
	 foreign key (idCategory) references dbo.foodCategory(id)
	 
)
go


create table bill
(
	id int identity primary key,
	idRoom int not null,
	dateCheckIn datetime not null default getdate(),
	dateCheckOut datetime,
	totalPrice float,
	discount int not null default 0,
	status int not null default 0, -- 0 la chua thanh toan 1 la da thanh toan
	foreign key (idroom) references dbo.room(id)
)
go

create table billInfo
(
	id int identity primary key,
	idBill int not null,
	idFood int not null,
	count int not null default 0,
	foreign key (idBill) references dbo.Bill(id),
	foreign key (idFood) references dbo.Food(id)
)
go

----///// chinh sua 
--ALTER TABLE room
--ADD isDelete int default 0
--go 

--alter table foodCategory
--add isDelete int default 0
--go

--alter table food
--add isDelete int default 0
--go


