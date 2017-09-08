using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models.Tables
{
    public class SalesReciepts
    {
        public int SalesRecieptsId { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
    }
}