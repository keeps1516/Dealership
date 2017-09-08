using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models.Tables
{
    public class Model
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int MakeId { get; set; }
        public string MakeName { get; set; }
    }
}