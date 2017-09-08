using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models.Tables
{
    public class ContactUs
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Correspondance { get; set; }
        public int VehicleId { get; set; }
    }
}