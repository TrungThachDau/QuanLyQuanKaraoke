insert into Room(Name, status)
values
(N'', N''),
(N'phòng A101', N'trống'),
(N'phòng A102', N'trống'),
(N'phòng A103', N'trống'),
(N'phòng A104', N'trống'),
(N'phòng A105', N'trống'),
(N'phòng A106', N'trống'),
(N'phòng B101', N'trống'),
(N'phòng B101', N'trống'),
(N'phòng B101', N'trống'),
(N'phòng B101', N'trống'),
(N'phòng B101', N'trống'),
(N'phòng B101', N'trống'),
(N'phòng B101', N'trống')


insert into account(displayName, userName, password, type)
values
(N'admin', N'admin', N'admin', 1),
(N'Trần Hữu Hoàng', N'HoangTran', N'12345', 1),
(N'khách', N'Khach', N'12345', 0)


insert into foodCategory(Name)
values
(N'Hải sản'),
(N'Nông sản'),
(N'Khai vị'),
(N'Tráng miện')

insert into food(name, idCategory, price)
values 
(N'Miến hấp hải sản',		1, 200000),
(N'Cua hấp',				1, 300000),
(N'Mực lá hấp gừng',		1, 250000),
(N'Ghẹ hấp',				1, 150000),

(N'Sốt cà chua',			2, 50000),
(N'Tương cà chua',			2, 50000),
(N'Cà rốt luộc',			2, 50000),
(N'Cà rốt ngâm chua ngọt',	2, 55000),
(N'Bắp cải cuốn thịt',		2, 60000),
(N'Nộm gà bắp cải',			2, 65000),
(N'Bắp cải trộn thập cẩm',	2, 100000),

(N'Tôm chiên xù',			3, 100000),
(N'Bánh xếp nhân thịt heo chiên giòn',	3, 120000),
(N'Bánh KOROKKE nhân thịt bò',	3, 140000),
(N'Mực hấp rim mắm tỏi',	3, 110000),
(N'Salad hải sản chua cay',	3, 120000),

(N'Chè đậu đỏ',				4, 10000),
(N'Chè vải hạt sen',		4, 20000),
(N'Bánh chuối nướng',		4, 40000),
(N'Bánh da lợn',			4, 50000),
(N'Sương sáo nước cốt dừa',	4, 50000),
(N'Chè dừa dầm',			4, 20000),
(N'Bánh chuối hấp nước cốt dừa',	4, 30000),
(N'Chè ba màu',				4, 15000)



insert into bill (idRoom, status)
values
(2, 1),
(3, 0),
(2, 0),
(4, 0)


