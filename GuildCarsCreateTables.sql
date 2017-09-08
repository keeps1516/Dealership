use GuildCars
go

if EXISTS(select * from sys.tables where name='SalesReceipts')
	drop table  SalesReceipts
go

if EXISTS(select * from sys.tables where name='Customer')
	drop table  Customer
go

if EXISTS(select * from sys.tables where name='Specials')
	drop table  Specials
go

if EXISTS(select * from sys.tables where name='ContactUs')
	drop table  ContactUs
go

if EXISTS(select * from sys.tables where name='Employee')
	drop table Employee
go

if EXISTS(select * from sys.tables where name='PaymentMethod')
	drop table PaymentMethod
go

if EXISTS(select * from sys.tables where name='Vehicle')
	drop table Vehicle
go

if EXISTS(select * from sys.tables where name='Transmission')
	drop table Transmission
go

if EXISTS(select * from sys.tables where name='BodyStyle')
	drop table BodyStyle
go

if EXISTS(select * from sys.tables where name='Color')
	drop table Color
go

if EXISTS(select * from sys.tables where name='Model')
	drop table Model
go

if EXISTS(select * from sys.tables where name='Make')
	drop table Make
go

create table Make(
MakeId int identity (1,1) primary key,
MakeName varchar(30) not null,
)

create table Model(
ModelId int identity(1,1) primary key,
ModelName varchar(30) not null,
MakeId int foreign key references Make(MakeId) not null,
)


create table Color(
ColorId int identity (1,1) primary key,
ColorName varchar (15) not null,
)

create table BodyStyle(
BodyStyleId int identity (1,1) primary key,
BodyStyleName varchar (20) not null,
)

create table Transmission(
TransmissionId int identity(1,1) primary key,
TransmissionName varchar (10) not null,
)
--IsNew=0 is an old Vehicle, IsNew=1 is a new vehicle
create table Vehicle(
VehicleId int identity(1,1) primary key,
ModelId int foreign key references Model(ModelId) not null,
TransmissionId int foreign key references Transmission (TransmissionId) not null,
BodyStyleId int foreign key references BodyStyle (BodyStyleId) not null,
InteriorColorId int not null,
ColorId int not null,
Mileage decimal(7,2) not null,
Vin varchar(17) not null,
MinumSalePrice decimal(9,2) not null,
ActualListedPrice decimal(9,2) not null,
MSRP decimal (9,2) not null,
IsNew bit not null,
IsInstock bit not null,
IsFeatured bit null,
[Year] int not null,
ImagePath varchar(150) null,
[Description] varchar(250) null,
)

create table PaymentMethod(
PaymentMethodId int identity (1,1) primary key,
PaymentName varchar(20) not null,
)

create table Employee(
EmployeeId int identity (1,1) primary key,
FirstName nvarchar(30) not null,
LastName nvarchar(30) not null,
Position nvarchar(30) not null,
)

create table ContactUs(
ContactId int identity (1,1) primary key,
FirstName nvarchar(30) not null,
LastName nvarchar(30) not null,
Email nvarchar(50) not null,
Phone nvarchar(15) not null,
Correspondance nvarchar(250) not null,
VehicleId int null,
)

create table Specials(
SpecialId int  identity (1,1) primary key,
SpecialName nvarchar(30) not null,
SpecialDescription nvarchar(250) not null,
)

create table Customer(
CustomerId int identity(1,1)primary key,
FirstName nvarchar(30) not null,
LastName nvarchar(30) not null,
City nvarchar(30) not null,
Email nvarchar(50) not null,
Phone nvarchar(10) not null,
Zip int not null,
Street1 nvarchar(30) not null,
Street2 nvarchar(30) null,
)

create table SalesReceipts(
SalesReceiptId int identity (1,1) primary key,
VehicleId int not null,
CustomerId int not null,
EmployeeId int not null,
PaymentMethodId int not null,
Total decimal (9,2) not null,
[Date] datetime not null,
constraint FK_VehicleId_SalesBridgeTable foreign key (VehicleId) references Vehicle(VehicleId),
constraint FK_CustomerId_SalesBridgeTable foreign key (CustomerId) references Customer(CustomerId),
constraint FK_EmployeeId_SalesBridgeTable foreign key (EmployeeId) references Employee(EmployeeId),
constraint FK_PaymentMethodId_SalesRecipts foreign key (PaymentMethodId) references PaymentMethod(PaymentMethodId),
)
