using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace GuildCars.UI.Models
{
    public class PurchaseViewModel
    {
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
        public PaymentMethod Payment { get; set; }
        public SalesReciepts Reciept { get; set; }
        public IEnumerable <SelectListItem> PaymentMethods { get; set; }

    }
}