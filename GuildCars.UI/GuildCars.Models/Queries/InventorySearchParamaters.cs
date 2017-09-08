using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class InventorySearchParamaters
    {
        public string Input { get; set; }
        public decimal? PricerangeMin { get; set; }
        public decimal? PricerangeMax { get; set; }
        public int? YearMin { get; set; }
        public int? YearMax { get; set; }

    }
}
