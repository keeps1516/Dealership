using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data
{
    public interface IVehiclesRepository
    {
        List<Vehicle> GetAllNewVehicles();
        List<Vehicle> GetAllFeaturedVehicles();
        List<Vehicle> SearchNewVehicles(InventorySearchParamaters param);
        List<Vehicle> GetAllUsedVehicles();
        List<Vehicle> SearchUsedVehicles(InventorySearchParamaters param);
        List<Vehicle> SearchAllVehicles(InventorySearchParamaters param);
        Vehicle GetVehicle(int id);
        List<Make> GetAllMakes();
        List<Model> GetMakeModel(int makeId);
        List<Color> GetAllColors();
        void AddVehicle(Vehicle param);
        List<Transmission> GetAllTransmissionTypes();
        List<BodyStyle> GetAllBodyStyles();
    }
}
