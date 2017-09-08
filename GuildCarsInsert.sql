use GuildCars


insert into Make(MakeName)
values('Ford'), ('Chevrolet'), ('Jeep'), ('Chrysler')

insert into Model(ModelName, MakeId)
values('F-150',1),('Explorer', 1),('Taurus',1),('Suburban',2),('Tahoe',2),('Malibu',2),('Impala',2),('Patriot',3),('Grand Cherokee SRT',3),('Wrangler',3),('Chrysler 200',4),('Chrysler Pacifica',4),('Chrysler 300',4);

insert into Color (ColorName)
values('Black'),('Blue'),('Red'),('Orange'),('Yellow'),('Grey'),('Green'),('Purple');

insert into BodyStyle(BodyStyleName)
values ('Truck'),('SUV'),('Car'),('MiniVan');

insert into Transmission(TransmissionName)
values ('Automatic'),('Standard');

insert into ContactUs Values('Joe', 'Smith', 'noemail@aol.com', '405-485-5555', 'You are awesome!',4);

insert into Customer values ('Customer','Person','City','someemail@email.com','1111111111',40205,'some random street','another street');

insert into Employee Values ('Some', 'Employee', 'Sales');

insert into PaymentMethod (PaymentName) Values('Cash'), ('Visa'), ('Master Card'), ('Check');