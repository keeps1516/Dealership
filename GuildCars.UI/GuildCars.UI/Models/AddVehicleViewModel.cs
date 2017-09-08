using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuildCars.Models.Tables;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class AddVehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> InteriorColors { get; set; }
        public IEnumerable<SelectListItem> BodyStyles { get; set; }
        public IEnumerable<SelectListItem> ExteriorColors { get; set; }
        public IEnumerable<SelectListItem> Transmissions { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

    }
}