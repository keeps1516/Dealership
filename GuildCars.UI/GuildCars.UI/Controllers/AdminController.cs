using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AddVehicles()
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            var model = new AddVehicleViewModel();
            model.Makes = new SelectList(repo.GetAllMakes(), "MakeId", "MakeName");
            model.InteriorColors = new SelectList(repo.GetAllColors(), "ColorId", "ColorName");
            model.ExteriorColors = new SelectList(repo.GetAllColors(), "ColorId", "ColorName");
            model.Transmissions = new SelectList(repo.GetAllTransmissionTypes(), "TransmissionId", "TransmissionName");
            model.BodyStyles = new SelectList(repo.GetAllBodyStyles(), "BodyStyleId", "BodyStyleName");
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddedVehicles(AddVehicleViewModel model)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            Vehicle vehicle = new Vehicle();
            vehicle = model.Vehicle;
            vehicle.IsInstock = true;
            if (model.ImageUpload != null)
            {
                var savepath = Server.MapPath("~/Images");

                string fileName = Path.GetFileName(model.ImageUpload.FileName);

                var filepath = Path.Combine(savepath, fileName);

                int counter = 1;

                while (System.IO.File.Exists(filepath))
                {
                    filepath = Path.Combine(savepath, filepath + counter.ToString());
                    counter++;
                }

                model.ImageUpload.SaveAs(filepath);
                vehicle.ImagePath = "/Images/" + fileName;
            }

            repo.AddVehicle(vehicle);
            return RedirectToAction("AddVehicles");
        }
    }
}