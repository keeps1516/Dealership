﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
   public static class VehicleRepositoryFactory
    {
        public static IVehiclesRepository GetRepository()
        {
            switch(Settings.GetRepositoryType())
            {
                case "ADO":
                    return new VehiclesRepositoryADO();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value");
            }
        }
    }
}