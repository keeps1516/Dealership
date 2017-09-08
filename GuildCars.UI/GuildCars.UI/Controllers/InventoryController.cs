using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuildCars.Data.Factories;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        // GET: InventoryNew
        [HttpGet]
        public ActionResult New()
        {
            var newVehiclesList = VehicleRepositoryFactory.GetRepository().GetAllNewVehicles();
            return View(newVehiclesList);
        }

        [HttpGet]
        public ActionResult Used()
        {
            var usedVehiclesLIst = VehicleRepositoryFactory.GetRepository().GetAllUsedVehicles();
            return View(usedVehiclesLIst);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var vehicle = VehicleRepositoryFactory.GetRepository().GetVehicle(id);
            return View(vehicle);
        }
    }
}