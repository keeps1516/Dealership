if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DbReset')
		drop procedure DbReset
go

create procedure DbReset as
begin
	delete from SalesReceipts;
	delete from Vehicle;

	dbcc checkident ('Vehicle', reseed,0)
	insert into Vehicle(BodyStyleId,TransmissionId, ModelId, InteriorColorId, ColorId,IsNew,Mileage, Vin, MinumSalePrice, ActualListedPrice, MSRP, IsInstock, IsFeatured, [Year], ImagePath, [Description])
	values(1,1,2,1,1,0,11000,1234567901234567,18000.00,23000,25000,1,0,2015, '\Images\fordsuv.jpg', 'This car is da best.'),
	(1,1,1,3,1,0,13000,1234567901234567,18000.00,21000,25000,1,0, 2016, '\Images\fordF150Truck.jpg', 'This car is da best.'), 
	(2,1,4,1,1,1,5000,1234567901234567,18000.00,23000,25000,1,1, 2017,'\Images\cheverletSuburban2016.png', 'This car is da best.'),
	(3,1,5,1,1,1,5000,1234567901234567,18000.00,22000,25000,1,1, 2017, '\Images\2017_chevrolet_tahoe.jpg', 'This car is da best.'),
	(4,1,9,1,1,1,6000,1234567901234567,18000.00,20000,25000,1,1, 2017, '\Images\cheverletSuburban2016.png', 'This car is da best.'),
	(2,1,11,1,1,1,8000,1234567901234567,18000.00,23000,25000,1,1, 2017, '\Images\chrysler.jpg', 'This car is da best.'),
	 (3,1,7,1,1,1,9000,1234567901234567,18000.00,23000,25000,1,0, 2016, '\Images\2016_chevrolet_impala.jpg', 'This car is da best.'),
	 (2,1,6,1,1,1,5000,1234567901234567,18000.00,23000,25000,1,0, 2016, '\Images\2016-Chevrolet-Malibu.jpg', 'This car is da best.');
end