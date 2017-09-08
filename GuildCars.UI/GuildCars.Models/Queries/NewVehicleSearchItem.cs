using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models.Queries
{
    public class NewVehicleSearchItem
    {
        public int VehicleId { get; set; }
        public string ModelName { get; set; }
        public int InteriorColorId { get; set; }
        public string VehicleColor { get; set; }
        public decimal Mileage { get; set; }
        public string Vin { get; set; }
        public decimal ActualListedPrice { get; set; }
        public decimal MSRP { get; set; }
        public bool IsNew { get; set; }
        public bool IsInstock { get; set; }
        public bool IsFeatured { get; set; }
        public int Year { get; set; }
        public string ImagePath { get; set; }
    }
}