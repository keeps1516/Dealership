using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models.Queries
{
    public class FeaturedVehicleItem
    {
        public int VehicleId { get; set; }
        public int ModelId { get; set; }
        public decimal ActualListedPrice { get; set; }
        public bool IsFeatured { get; set; }
    }
}