create database ABCApplication;
go
use ABCApplication;
go
create table Category(
ID int primary key identity(1,1),
CatName varchar(100) not null,
CatDescription varchar(200)
);
go
create table Product(
ID int primary key identity(1,1),
Name varchar(100) not null,
Make varchar(100) not null,
Price money not null,
CategoryId int,
foreign key (CategoryId) references Category(ID)
);
go
create table [Order](
ID int primary key identity(1,1),
CusName varchar(200) not null,
CusPhone varchar(15),
CusEmail varchar(200),
CusAddress varchar(200),
OrderDate date not null
);
go
create table OrderDetail(
ProductID int,
OrderID int,
primary key (ProductID, OrderID),
foreign key (ProductID) references Product(ID),
foreign key (OrderID) references [Order](ID),
Quantity int 
);
go
create table Query(
ID int primary key identity(1,1),
Name varchar(100),
Email varchar(200),
Question varchar(500),
Status bit not null default 1
);

insert into Category values ('Laptop','Sell laptops'),
							('Accessories', 'Accessories for your laptop');

select * from Category;
							  
insert into Product values ('MSI CX62 6QD-257XVN', 'MSI', 700, 1),
							('DELL Vostro 5468', 'DELL', 550, 1),
							('Seagate 500GB Sata', 'SEAGATE', 50, 2),
							('Cooler Master Notepal Ergo 360', 'Cooler Master', 25, 2);	

select * from Product;

insert into [Order] values ('Nguyen Manh Tuan', '0910802019', 'tuantienti@gmail.com', 'Long Bien', '06/24/2017');
insert into [Order] values ('Hoang Khuong Duy', '0918854397', 'duydamdang@gmail.com', 'Chua Boc', '06/22/2017');
select * from [Order]

insert into OrderDetail(ProductID, OrderID, Quantity) values (1, 1, 1),
															 (3, 1, 3),
															 (4, 2, 2);			
select * from OrderDetail;

insert into Query(Name, Email, Question) values ('Giang', 'giangdz@gmail.com', 'How can I track my orders ?'),
										  ('Sang', 'sangle@yahoo.com', 'Hi! I am Sang Le'); 
select * from Query;


create table SystemConfig(
ID varchar(50) primary key not null,
Name nvarchar(50),
Type varchar(50),
Value nvarchar(250),
Status bit 
);

create table [User](
ID int primary key identity(1,1),
UserName varchar(50),
Password varchar(32),
Name nvarchar(50),
Email nvarchar(50)
);
