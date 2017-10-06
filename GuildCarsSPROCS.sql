use GuildCars
go

if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetNewVehicles')
begin
	drop procedure GetNewVehicles
	end
	go
create procedure GetNewVehicles
as
select VehicleId, Make.MakeName, Model.ModelName as ModelName, vc.ColorName as VehicleColor, ic.ColorName as InteriorColor, 
Vehicle.Mileage,IsNew, Vehicle.Vin, Vehicle.MinumSalePrice,Vehicle.MSRP,Vehicle.ActualListedPrice, 
Vehicle.IsInstock, Vehicle.IsFeatured, Vehicle.[Year], Vehicle.ImagePath, BodyStyle.BodyStyleName, Transmission.TransmissionName
from Vehicle
inner join Model
on Vehicle.ModelId = Model.ModelId
inner join Make
on Model.MakeId = Make.MakeId
inner join Color vc
on Vehicle.ColorId = vc.ColorId
inner join Color ic
on Vehicle.InteriorColorId = ic.ColorId
inner join BodyStyle
on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
inner join Transmission
on Vehicle.TransmissionId = Transmission.TransmissionId
where (IsInstock=1 and IsNew=1) 
go

if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetUsedVehicles')
begin
	drop procedure GetUsedVehicles
	end
	go
create procedure GetUsedVehicles
as
select VehicleId, Make.MakeName, Model.ModelName, vc.ColorName as VehicleColor, ic.ColorName as InteriorColor, 
Vehicle.Mileage,IsNew, Vehicle.Vin, Vehicle.MinumSalePrice,Vehicle.MSRP,Vehicle.ActualListedPrice, 
Vehicle.IsInstock, Vehicle.IsFeatured, Vehicle.[Year], Vehicle.ImagePath,BodyStyle.BodyStyleName, Transmission.TransmissionName
from Vehicle
inner join Model
on Vehicle.ModelId = Model.ModelId
inner join Make
on Model.MakeId = Make.MakeId
inner join Color vc
on Vehicle.ColorId = vc.ColorId
inner join Color ic
on Vehicle.InteriorColorId = ic.ColorId
inner join BodyStyle
on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
inner join Transmission
on Vehicle.TransmissionId = Transmission.TransmissionId
where (IsInstock=1 and IsNew=0) 
go

if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetFeaturedVehicles')
begin
	drop procedure GetFeaturedVehicles
	end
	go
create procedure GetFeaturedVehicles
as

select VehicleId, Make.MakeName, Model.ModelName, vc.ColorName as VehicleColor, ic.ColorName as InteriorColor, 
Vehicle.Mileage,IsNew, Vehicle.Vin, Vehicle.MinumSalePrice,Vehicle.MSRP,Vehicle.ActualListedPrice, 
Vehicle.IsInstock, Vehicle.IsFeatured, Vehicle.[Year], Vehicle.ImagePath, BodyStyle.BodyStyleName, Transmission.TransmissionName
from Vehicle
inner join Model
on Vehicle.ModelId = Model.ModelId
inner join Make
on Model.MakeId = Make.MakeId
inner join Color vc
on Vehicle.ColorId = vc.ColorId
inner join Color ic
on Vehicle.InteriorColorId = ic.ColorId
inner join BodyStyle
on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
inner join Transmission
on Vehicle.TransmissionId = Transmission.TransmissionId
where IsFeatured=1 and IsInstock = 1;
go


if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SearchNewVehicles')
begin
	drop procedure SearchNewVehicles
	end
	go
create procedure SearchNewVehicles(
@input varchar(30), @PricerangeMin decimal(9,2), @PricerangeMax decimal(9,2), @YearMin int, @YearMax int
)
as

if @PricerangeMin is null
	set @PricerangeMin = 0;
if @PricerangeMax is null
	set @PricerangeMax = 9999999;
if @YearMin is null
	set @YearMin = 0;
if @YearMax is null
	set @YearMax = 9999;

select VehicleId, Make.MakeName, Model.ModelName, vc.ColorName as VehicleColor, ic.ColorName as InteriorColor, 
Vehicle.Mileage,IsNew, Vehicle.Vin, Vehicle.MinumSalePrice,Vehicle.MSRP,Vehicle.ActualListedPrice,
 Vehicle.IsInstock, Vehicle.IsFeatured, Vehicle.[Year], Vehicle.ImagePath,BodyStyle.BodyStyleName, Transmission.TransmissionName
from Vehicle
inner join Model
on Vehicle.ModelId = Model.ModelId
inner join Make
on Model.MakeId = Make.MakeId
inner join Color vc
on Vehicle.ColorId = vc.ColorId
inner join Color ic
on Vehicle.InteriorColorId = ic.ColorId
inner join BodyStyle
on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
inner join Transmission
on Vehicle.TransmissionId = Transmission.TransmissionId
where (IsInstock=1 and IsNew=1) 
and (Make.MakeName like '%'+ @input + '%'
 or Model.ModelName like '%'+ @input + '%' 
 or Vehicle.[Year] like '%'+ @input + '%')
 and (Vehicle.ActualListedPrice >= @PricerangeMin and Vehicle.ActualListedPrice <= @PricerangeMax)
 and (Vehicle.[Year] >= @YearMin and Vehicle.[Year] <= @YearMax)
go

if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SearchUsedVehicles')
begin
	drop procedure SearchUsedVehicles
	end
	go
create procedure SearchUsedVehicles(
@input varchar(30), @PricerangeMin decimal(9,2), @PricerangeMax decimal(9,2), @YearMin int, @YearMax int
)
as

if @PricerangeMin is null
	set @PricerangeMin = 0.00;
if @PricerangeMax is null
	set @PricerangeMax = 9999999;
if @YearMin is null
	set @YearMin = 0;
if @YearMax is null
	set @YearMax = 9999;

select VehicleId, Make.MakeName, Model.ModelName, vc.ColorName as VehicleColor, ic.ColorName as InteriorColor, 
Vehicle.Mileage,IsNew, Vehicle.Vin, Vehicle.MinumSalePrice,Vehicle.MSRP,Vehicle.ActualListedPrice, 
Vehicle.IsInstock, Vehicle.IsFeatured, Vehicle.[Year], Vehicle.ImagePath,BodyStyle.BodyStyleName, Transmission.TransmissionName
from Vehicle
inner join Model
on Vehicle.ModelId = Model.ModelId
inner join Make
on Model.MakeId = Make.MakeId
inner join Color vc
on Vehicle.ColorId = vc.ColorId
inner join Color ic
on Vehicle.InteriorColorId = ic.ColorId
inner join BodyStyle
on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
inner join Transmission
on Vehicle.TransmissionId = Transmission.TransmissionId
where (IsInstock=1 and IsNew=0) 
and (Make.MakeName like '%'+ @input + '%'
 or Model.ModelName like '%'+ @input + '%' 
 or Vehicle.[Year] like '%'+ @input + '%')
 and (Vehicle.ActualListedPrice >= @PricerangeMin and Vehicle.ActualListedPrice <= @PricerangeMax)
 and(Vehicle.[Year] >= @YearMin and Vehicle.[Year] <= @YearMax)
go


if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SearchAllVehicles')
begin
	drop procedure SearchAllVehicles
	end
	go
create procedure SearchAllVehicles(
@input varchar(30), @PricerangeMin decimal(9,2), @PricerangeMax decimal(9,2), @YearMin int, @YearMax int
)
as

if @PricerangeMin is null
	set @PricerangeMin = 0;
if @PricerangeMax is null
	set @PricerangeMax = 9999999;
if @YearMin is null
	set @YearMin = 0;
if @YearMax is null
	set @YearMax = 9999;

select VehicleId, Make.MakeName, Model.ModelName, vc.ColorName as VehicleColor, ic.ColorName as InteriorColor, 
Vehicle.Mileage,IsNew, Vehicle.Vin, Vehicle.MinumSalePrice,Vehicle.MSRP,Vehicle.ActualListedPrice,
 Vehicle.IsInstock, Vehicle.IsFeatured, Vehicle.[Year], Vehicle.ImagePath,BodyStyle.BodyStyleName, Transmission.TransmissionName
from Vehicle
inner join Model
on Vehicle.ModelId = Model.ModelId
inner join Make
on Model.MakeId = Make.MakeId
inner join Color vc
on Vehicle.ColorId = vc.ColorId
inner join Color ic
on Vehicle.InteriorColorId = ic.ColorId
inner join BodyStyle
on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
inner join Transmission
on Vehicle.TransmissionId = Transmission.TransmissionId
where (Make.MakeName like '%'+ @input + '%'
 or Model.ModelName like '%'+ @input + '%' 
 or Vehicle.[Year] like '%'+ @input + '%')
 and (Vehicle.ActualListedPrice >= @PricerangeMin and Vehicle.ActualListedPrice <= @PricerangeMax)
 and (Vehicle.[Year] >= @YearMin and Vehicle.[Year] <= @YearMax)
 and (Vehicle.IsInstock = 1)
go


if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetVehicle')
begin
	drop procedure GetVehicle
	end
	go
create procedure GetVehicle(
@VehcileId int
)
as
select VehicleId, Make.MakeName, Model.ModelName, vc.ColorName as VehicleColor, ic.ColorName as InteriorColor, 
Vehicle.Mileage,IsNew, Vehicle.Vin, Vehicle.MinumSalePrice,Vehicle.MSRP,Vehicle.ActualListedPrice, 
Vehicle.IsInstock, Vehicle.IsFeatured, Vehicle.[Year], Vehicle.ImagePath,BodyStyle.BodyStyleName, Transmission.TransmissionName, Vehicle.Description
from Vehicle
inner join Model
on Vehicle.ModelId = Model.ModelId
inner join Make
on Model.MakeId = Make.MakeId
inner join Color vc
on Vehicle.ColorId = vc.ColorId
inner join Color ic
on Vehicle.InteriorColorId = ic.ColorId
inner join BodyStyle
on Vehicle.BodyStyleId = BodyStyle.BodyStyleId
inner join Transmission
on Vehicle.TransmissionId = Transmission.TransmissionId
where (Vehicle.VehicleId = @VehcileId) 
go

if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SaveCustomerInfo')
begin
	drop procedure SaveCustomerInfo
	end
	go
create procedure SaveCustomerInfo(
 @CustomerId int output, @FirstName nvarchar(30), @LastName nvarchar(30), @City nvarchar(30) , @Email nvarchar(50), @Phone nvarchar(10),
@Zip int, @Street1 nvarchar(30), @Street2 nvarchar(30)
)
as
begin
insert into Customer
Values(@FirstName, @LastName,@City, @Email, @Phone, @Zip,@Street1, @Street2)
set @CustomerId = SCOPE_IDENTITY();
end
go


if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'SavePurchase')
begin
	drop procedure SavePurchase
	end
	go
create procedure SavePurchase(
@SalesReceiptId int output, @VehicleId int, @CustomerId int, @EmployeeId int, @PaymentMethodId int, @Total decimal(9,2), @Date datetime
)
as
begin
insert into SalesReceipts
Values(@VehicleId, @CustomerId, @EmployeeId, @PaymentMethodId, @Total, @Date)
set @SalesReceiptId = SCOPE_IDENTITY();
end
go




if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'PurchaseVehicle')
begin
	drop procedure PurchaseVehicle
	end
	go
create procedure PurchaseVehicle(
@VehicleId int
)
	as
	declare @IsInstock bit
		set @IsInstock = 0
	update Vehicle
	set IsInstock = @IsInstock
	where Vehicle.VehicleId = @VehicleId
	go

	
if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllPaymentTypes')
begin
	drop procedure GetAllPaymentTypes
	end
	go
create procedure GetAllPaymentTypes
as
begin
select*
from PaymentMethod
end
go

if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetModels')
begin
	drop procedure GetModels
	end
	go
create procedure GetModels (
@MakeId int
)
as
select ModelId, Model.ModelName, Model.MakeId, Make.MakeName
from Model
inner join Make on Model.MakeId = Make.MakeId
where Model.MakeId =@MakeId;
go

if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetMakes')
begin
	drop procedure GetMakes
	end
	go
create procedure GetMakes
as
begin
select *
from Make
end
go



if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'AddVehicle')
begin
	drop procedure AddVehicle
	end
	go
create procedure AddVehicle(
@ModelId int,
@TransmissionId int, 
@BodyStyleId int,
@InteriorColorId int,
@ColorId int,
@Mileage decimal(7,2), 
@Vin varchar(17), 
@MinumSalePrice decimal(9,2), 
@ActualListedPrice decimal (9,2), 
@MSRP decimal (9,2), 
@IsNew bit, 
@IsFeatured bit, 
@Year int, 
@ImagePath varchar(150), 
@Description varchar(250)
)
as

declare @IsInstock bit
set @IsInstock = 1
begin
insert into Vehicle(ModelId,TransmissionId, BodyStyleId,
InteriorColorId, ColorId,Mileage, Vin, MinumSalePrice, 
ActualListedPrice, MSRP, IsNew,IsInstock, IsFeatured, [Year], 
ImagePath, [Description])
values(@ModelId,@TransmissionId,@BodyStyleId,@InteriorColorId,
@ColorId,@Mileage,@Vin,@MinumSalePrice,@ActualListedPrice,@MSRP,
@IsNew,@IsInstock,@IsFeatured,@Year,@ImagePath, @Description)
end
go



if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllColors')
begin
	drop procedure GetAllColors
	end
	go
create procedure GetAllColors
as
select *
from Color
go

if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllBodyStyles')
begin
	drop procedure GetAllBodyStyles
	end
	go
create procedure GetAllBodyStyles
as
select *
from BodyStyle
go

if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetAllTransmissionTypes')
begin
	drop procedure GetAllTransmissionTypes
	end
	go
create procedure GetAllTransmissionTypes
as
select *
from Transmission
go

if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'UpdateVehicle')
begin
	drop procedure UpdateVehicle
	end
	go

create procedure UpdateVehicle(
@VehicleId int,
@ModelId int,
@TransmissionId int, 
@BodyStyleId int,
@InteriorColorId int, 
@ColorId int,
@Mileage decimal(7,2), 
@Vin varchar(17), 
@MinumSalePrice decimal(9,2), 
@ActualListedPrice decimal (9,2), 
@MSRP decimal (9,2), 
@IsNew bit, 
@IsFeatured bit, 
@Year int, 
@ImagePath varchar(150), 
@Description varchar(250)
)
as
begin
	update Vehicle set
		ModelId = @ModelId,
		TransmissionId = @TransmissionId,
		BodyStyleId = @BodyStyleId,
		InteriorColorId = @InteriorColorId,
		ColorId = @ColorId,
		Vin = @Vin,
		MinumSalePrice = @MinumSalePrice,
		ActualListedPrice = @ActualListedPrice,
		MSRP = @MSRP,
		IsNew = @IsNew,
		IsFeatured = @IsFeatured,
		[Year] = @Year,
		ImagePath = @ImagePath,
		[Description] = @Description
		where VehicleId = @VehicleId
end
go

if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DeleteVehicle')
begin
	drop procedure DeleteVehicle
	end
	go

create procedure DeleteVehicle(
@VehicleId int
)
as
begin
	delete Vehicle
	where Vehicle.VehicleId = @VehicleId
end
go