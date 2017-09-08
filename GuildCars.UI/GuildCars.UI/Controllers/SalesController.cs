using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuildCars.Data;
using GuildCars.Data.Factories;
using GuildCars.UI.Models;
using System.IO;

namespace GuildCars.UI.Controllers
{
    [Authorize(Roles = "sales")]
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult Purchase(int id)
        {
            var carRepo = VehicleRepositoryFactory.GetRepository();
            var purchaseRepo = PurchaseRepositoryFactory.GetRepository();
            var vehicle = carRepo.GetVehicle(id);
            var model = new PurchaseViewModel();
            model.Vehicle = vehicle;
            model.PaymentMethods = new SelectList(purchaseRepo.GetAllPaymentTypes(), "PaymentMethodId", "PaymentName");
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult Purchased (PurchaseViewModel model)
        {
            var repo = PurchaseRepositoryFactory.GetRepository();
            repo.SaveCustomerInfo(model.Customer);
            model.Reciept.CustomerId = model.Customer.CustomerId;
            model.Reciept.VehicleId = model.Vehicle.VehicleId;
            model.Reciept.EmployeeId = 1;
            model.Reciept.PaymentMethodId = model.Payment.PaymentMethodId;
            model.Reciept.Date = DateTime.Now;
            repo.SavePurchase(model.Reciept);

            repo.PurchaseVehicle(model.Vehicle.VehicleId);

            return RedirectToAction("Index");
        }
    }
}