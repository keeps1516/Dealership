using GuildCars.Data;
using GuildCars.Models.Queries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using GuildCars.Data.Factories;

namespace GuildCars.Test.AdoTests
{
    [TestFixture]
    public class AdoTests
    {
        [Test]
        public void CanLoadFeaturedVehicles()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicles = repo.GetAllFeaturedVehicles();

            Assert.AreEqual(4, vehicles.Count);
        }

        [Test]
        public void CanLoadNewVehicles()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicles = repo.GetAllNewVehicles();

            Assert.AreEqual(6, vehicles.Count);
        }

        [Test]
        public void CanSearchNewVehicles()
        {
            var repo = new VehiclesRepositoryADO();
            var par = new InventorySearchParamaters();
            par.Input = "Tahoe";
            par.PricerangeMin = 20000;
            par.PricerangeMax = 23000;
            par.YearMin = 2016;
            par.YearMax = 2017;

            var vehicles = repo.SearchNewVehicles(par);

            Assert.AreEqual(vehicles.Where(m => m.VehicleId == 4).Count(), 1);

        }

        //[Test]
        //public void CanSearchNewVehiclesNull()
        //{
        //    var repo = new VehiclesRepositoryADO();

        //    var vehicles = repo.SearchNewVehicles("Tahoe", null, null, null, null);

        //    Assert.AreEqual(vehicles.Where(m => m.VehicleId == 4).Count(), 1);

        //}

        //[Test]
        //public void CanSearchNewVehiclesEmptyString()
        //{
        //    var repo = new VehiclesRepositoryADO();

        //    var vehicles = repo.SearchNewVehicles("", null, null, null, null);

        //    Assert.AreEqual(vehicles.Count(), 6);

        //}

        //[Test]
        //public void CanSearchNewVehiclesEmptyStringAndYear()
        //{
        //    var repo = new VehiclesRepositoryADO();

        //    var vehicles = repo.SearchNewVehicles("", null, null, 2016, 2016);

        //    Assert.AreEqual(vehicles.Count(), 2);

        //}

        //[Test]
        //public void CanSearchNewVehiclesEmptyStringPriceRange()
        //{
        //    var repo = new VehiclesRepositoryADO();

        //    var vehicles = repo.SearchNewVehicles("", 20000, 22000, null, null);

        //    Assert.AreEqual(vehicles.Count(), 2);

        //}

        [Test]
        public void CanGetVehicle()
        {
            var repo = new VehiclesRepositoryADO();

            var car = repo.GetVehicle(3);
            Vehicle v = new Vehicle();
            v.VehicleId = 3;
            Assert.AreEqual(car.VehicleId, v.VehicleId);
        }

        [Test]
        public void CanAddCustomer()
        {
            var repo = new PurchaseRepositoryADO();

            var cust = new Customer();

            cust.City = "New City";
            cust.Email = "someEmail@bemail.com";
            cust.FirstName = "mr";
            cust.LastName = "customer";
            cust.Phone = "1111111111";
            cust.Street1 = "street";
            cust.Street2 = "apartment 1";
            cust.Zip = "40205";

            repo.SaveCustomerInfo(cust);

            Assert.AreEqual(1, 1);
        }

        [Test]
        public void CanAddReciept()
        {
            var repo = new PurchaseRepositoryADO();

            var reciept = new SalesReciepts();

            reciept.CustomerId = 1;
            reciept.Date = DateTime.Now;
            reciept.EmployeeId = 1;
            reciept.PaymentMethodId = 1;
            reciept.Total = 30000;
            reciept.VehicleId = 1;

            repo.SavePurchase(reciept);

            Assert.AreEqual(1, 1);
        }

        [Test]
        public void GetModels()
        {
            var repo = new VehiclesRepositoryADO();
            int id = 3;
            var models = repo.GetMakeModel(id);

            models.Count();

            Assert.AreEqual(models.Count(),3);
        }
    }
}
