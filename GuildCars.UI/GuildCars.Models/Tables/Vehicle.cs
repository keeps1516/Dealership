using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models.Tables
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public int MakeId { get; set; }
        public string ModelName { get; set; }
        public int ModelId { get; set; }
        public string InteriorColor { get; set; }
        public int InteriorColorId { get; set; }
        public string VehicleColor { get; set; }
        public int VehicleColorId { get; set; }
        public decimal Mileage { get; set; }
        public string Vin { get; set; }
        public decimal MinumSalePrice { get; set; }
        public decimal ActualListedPrice { get; set; }
        public decimal MSRP { get; set; }
        public bool IsNew { get; set; }
        public bool IsInstock { get; set; }
        public bool IsFeatured { get; set; }
        public int Year {get;set;}
        public string ImagePath { get; set; }
        public string BodyStyleName { get; set; }
        public int BodystyleId { get; set; }
        public string TransmissionName { get; set; }
        public int TransmissionId { get; set; }
        public string Description { get; set; }
    }
}