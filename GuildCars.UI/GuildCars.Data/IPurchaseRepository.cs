using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data
{
    public interface IPurchaseRepository
    {
         void SaveCustomerInfo(Customer customerinfo);
         void SavePurchase(SalesReciepts sale);
         void PurchaseVehicle(int id);
         List<PaymentMethod> GetAllPaymentTypes();
    }
}
