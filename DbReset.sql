if exists(
	select *
	from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'DbReset')
begin
	drop procedure DbReset
	end
	go
create procedure DbReset as
begin
	delete from Vehicle;
	dbcc checkident ('Vehicle', reseed,0)
	insert into Vehicle(BodyStyleId,TransmissionId, ModelId, InteriorColorId, ColorId,IsNew,Mileage, Vin, MinumSalePrice, ActualListedPrice, MSRP, IsInstock, IsFeatured, [Year], ImagePath, [Description])
	values(1,1,2,1,1,0,11000,1234567901234567,18000.00,23000,25000,1,0,2015, 'https://www.cstatic-images.com/stock/900x600/1416251164931.jpg', 'This car is da best.'),
	(1,1,1,3,1,0,13000,1234567901234567,18000.00,21000,25000,1,0, 2016, 'https://images.autotrader.com/scaler/620/420/cms/images/cars/ford/f-150/2016/2016fordf150/250206.jpg', 'This car is da best.'), 
	(2,1,4,1,1,1,5000,1234567901234567,18000.00,23000,25000,1,1, 2017,'http://s3.amazonaws.com/fzautomotive/common/mfg/Chevrolet/2016-chevrolet-suburban.png', 'This car is da best.'),
	(3,1,5,1,1,1,5000,1234567901234567,18000.00,22000,25000,1,1, 2017, 'https://file.kbb.com/kbb/vehicleimage/evoxseo/cp/m/11542/2017-chevrolet-tahoe-front_11542_032_480x240_gba.png', 'This car is da best.'),
	(4,1,9,1,1,1,6000,1234567901234567,18000.00,20000,25000,1,1, 2017, 'http://www.suttons.com.au/Content/images/cars/26A2202-1.jpg', 'This car is da best.'),
	(2,1,11,1,1,1,8000,1234567901234567,18000.00,23000,25000,1,1, 2017, 'http://pictures.dealer.com/a/asheborocdjramcllc/0074/2546c9b073f393ee09ae89bb249e50c5x.jpg', 'This car is da best.'),
	 (3,1,7,1,1,1,9000,1234567901234567,18000.00,23000,25000,1,0, 2016, 'https://media.ed.edmunds-media.com/chevrolet/impala/2016/oem/2016_chevrolet_impala_sedan_ltz-w2lz_fq_oem_1_1280.jpg', 'This car is da best.'),
	 (2,1,6,1,1,1,5000,1234567901234567,18000.00,23000,25000,1,0, 2016, 'http://blog.caranddriver.com/wp-content/uploads/2015/12/2016-Chevrolet-Malibu-1LT-01-626x382.jpg', 'This car is da best.');
end