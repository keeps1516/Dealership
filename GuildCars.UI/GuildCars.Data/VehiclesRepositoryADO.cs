using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using System.Data.SqlClient;
using GuildCars.Models.Queries;
using System.Data;

namespace GuildCars.Data
{
    public class VehiclesRepositoryADO : IVehiclesRepository
    {
        public List<Vehicle> GetAllFeaturedVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetFeaturedVehicles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.ActualListedPrice = (decimal)dr["ActualListedPrice"];
                        currentRow.VehicleColor = dr["VehicleColor"].ToString();
                        currentRow.ImagePath = dr["ImagePath"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsInstock = (bool)dr["IsInstock"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.Mileage = (decimal)dr["Mileage"];
                        currentRow.MinumSalePrice = (decimal)dr["MinumSalePrice"];
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.TransmissionName = dr["TransmissionName"].ToString();

                        vehicles.Add(currentRow);
                    }

                }

            }

            return vehicles;
        }

        public List<Vehicle> GetAllNewVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetNewVehicles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.ActualListedPrice = (decimal)dr["ActualListedPrice"];
                        currentRow.VehicleColor = dr["VehicleColor"].ToString();
                        currentRow.ImagePath = dr["ImagePath"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsInstock = (bool)dr["IsInstock"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.Mileage = (decimal)dr["Mileage"];
                        currentRow.MinumSalePrice = (decimal)dr["MinumSalePrice"];
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.TransmissionName = dr["TransmissionName"].ToString();

                        vehicles.Add(currentRow);
                    }

                }

            }

            return vehicles;
        }

        public List<Vehicle> SearchNewVehicles(InventorySearchParamaters param)
        {

            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SearchNewVehicles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@input", param.Input);


                if (param.PricerangeMin == null)
                {
                    cmd.Parameters.AddWithValue("@PricerangeMin", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@PricerangeMin", param.PricerangeMin);

                if (param.PricerangeMax == null)
                {
                    cmd.Parameters.AddWithValue("@PricerangeMax", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@PricerangeMax", param.PricerangeMax);

                if (param.YearMin == null)
                {
                    cmd.Parameters.AddWithValue("@YearMin", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@YearMin", param.YearMin);

                if (param.YearMax == null)
                {
                    cmd.Parameters.AddWithValue("@YearMax", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@YearMax", param.YearMax);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.ActualListedPrice = (decimal)dr["ActualListedPrice"];
                        currentRow.VehicleColor = dr["VehicleColor"].ToString();
                        currentRow.ImagePath = dr["ImagePath"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsInstock = (bool)dr["IsInstock"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.Mileage = (decimal)dr["Mileage"];
                        currentRow.MinumSalePrice = (decimal)dr["MinumSalePrice"];
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.TransmissionName = dr["TransmissionName"].ToString();

                        vehicles.Add(currentRow);
                    }

                }

            }

            return vehicles;
        }

        public List<Vehicle> GetAllUsedVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetUsedVehicles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.ActualListedPrice = (decimal)dr["ActualListedPrice"];
                        currentRow.VehicleColor = dr["VehicleColor"].ToString();
                        currentRow.ImagePath = dr["ImagePath"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsInstock = (bool)dr["IsInstock"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.Mileage = (decimal)dr["Mileage"];
                        currentRow.MinumSalePrice = (decimal)dr["MinumSalePrice"];
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.TransmissionName = dr["TransmissionName"].ToString();

                        vehicles.Add(currentRow);
                    }

                }

            }

            return vehicles;
        }


        public List<Vehicle> SearchUsedVehicles(InventorySearchParamaters param)
        {

            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SearchUsedVehicles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@input", param.Input);


                if (param.PricerangeMin == null)
                {
                    cmd.Parameters.AddWithValue("@PricerangeMin", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@PricerangeMin", param.PricerangeMin);

                if (param.PricerangeMax == null)
                {
                    cmd.Parameters.AddWithValue("@PricerangeMax", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@PricerangeMax", param.PricerangeMax);

                if (param.YearMin == null)
                {
                    cmd.Parameters.AddWithValue("@YearMin", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@YearMin", param.YearMin);

                if (param.YearMax == null)
                {
                    cmd.Parameters.AddWithValue("@YearMax", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@YearMax", param.YearMax);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.ActualListedPrice = (decimal)dr["ActualListedPrice"];
                        currentRow.VehicleColor = dr["VehicleColor"].ToString();
                        currentRow.ImagePath = dr["ImagePath"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsInstock = (bool)dr["IsInstock"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.Mileage = (decimal)dr["Mileage"];
                        currentRow.MinumSalePrice = (decimal)dr["MinumSalePrice"];
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.TransmissionName = dr["TransmissionName"].ToString();

                        vehicles.Add(currentRow);
                    }

                }

            }

            return vehicles;
        }

        public List<Vehicle> SearchAllVehicles(InventorySearchParamaters param)
        {

            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SearchAllVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@input", param.Input);


                if (param.PricerangeMin == null)
                {
                    cmd.Parameters.AddWithValue("@PricerangeMin", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@PricerangeMin", param.PricerangeMin);

                if (param.PricerangeMax == null)
                {
                    cmd.Parameters.AddWithValue("@PricerangeMax", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@PricerangeMax", param.PricerangeMax);

                if (param.YearMin == null)
                {
                    cmd.Parameters.AddWithValue("@YearMin", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@YearMin", param.YearMin);

                if (param.YearMax == null)
                {
                    cmd.Parameters.AddWithValue("@YearMax", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@YearMax", param.YearMax);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.ActualListedPrice = (decimal)dr["ActualListedPrice"];
                        currentRow.VehicleColor = dr["VehicleColor"].ToString();
                        currentRow.ImagePath = dr["ImagePath"].ToString();
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsInstock = (bool)dr["IsInstock"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.Mileage = (decimal)dr["Mileage"];
                        currentRow.MinumSalePrice = (decimal)dr["MinumSalePrice"];
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.TransmissionName = dr["TransmissionName"].ToString();

                        vehicles.Add(currentRow);
                    }

                }

            }

            return vehicles;
        }

        public Vehicle GetVehicle(int id)
        {
            Vehicle vehicle = new Vehicle();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetVehicle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehcileId", id);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {

                        vehicle.ActualListedPrice = (decimal)dr["ActualListedPrice"];
                        vehicle.VehicleColor = dr["VehicleColor"].ToString();
                        vehicle.InteriorColor = dr["InteriorColor"].ToString();
                        vehicle.IsFeatured = (bool)dr["IsFeatured"];
                        vehicle.IsInstock = (bool)dr["IsInstock"];
                        vehicle.IsNew = (bool)dr["IsNew"];
                        vehicle.Mileage = (decimal)dr["Mileage"];
                        vehicle.MinumSalePrice = (decimal)dr["MinumSalePrice"];
                        vehicle.Make = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.Vin = dr["Vin"].ToString();
                        vehicle.Year = (int)dr["Year"];
                        vehicle.BodyStyleName = dr["BodyStyleName"].ToString();
                        vehicle.TransmissionName = dr["TransmissionName"].ToString();

                        if (dr["Description"] != DBNull.Value)
                            vehicle.Description = dr["Description"].ToString();
                        if (dr["ImagePath"] != DBNull.Value)
                            vehicle.ImagePath = dr["ImagePath"].ToString();

                    }

                }

            }

            return vehicle;
        }


        public List<Make> GetAllMakes()
        {
            List<Make> makeList = new List<Make>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetMakes", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make make = new Make();

                        make.MakeId = (int)dr["MakeId"];
                        make.MakeName = dr["MakeName"].ToString();

                        makeList.Add(make);
                    }
                }

            }

            return makeList;
        }


        public List<Model> GetMakeModel(int makeId)
        {
            List<Model> modelList = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetModels", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeId", makeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model model = new Model();

                        model.ModelId = (int)dr["ModelId"];
                        model.ModelName = dr["ModelName"].ToString();
                        model.MakeId = (int)dr["MakeId"];
                        model.MakeName = dr["MakeName"].ToString();

                        modelList.Add(model);
                    }
                }

            }

            return modelList;
        }


        //@ModelId int,@TransmissionId int, @BodyStyleId int,
        //@InteriorColorId int, @ColorId int,@Mileage decimal (7,2), @Vin varchar(17), @MinumSalePrice decimal (9,2), 
        //@ActualListedPrice decimal (9,2), @MSRP decimal (9,2), @IsNew bit, @IsFeatured bit, @Year int, @ImagePath varchar(150), 
        //@Description varchar(250)

        public void AddVehicle(Vehicle param)
        {

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddVehicle", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ModelId", param.ModelId);
                cmd.Parameters.AddWithValue("@TransmissionId", param.TransmissionId);
                cmd.Parameters.AddWithValue("@BodyStyleId", param.BodystyleId);
                cmd.Parameters.AddWithValue("@InteriorColorId", param.InteriorColorId);
                cmd.Parameters.AddWithValue("@ColorId", param.VehicleColorId);
                cmd.Parameters.AddWithValue("@Mileage", param.Mileage);
                cmd.Parameters.AddWithValue("@Vin", param.Vin);
                cmd.Parameters.AddWithValue("@MinumSalePrice", param.MinumSalePrice);
                cmd.Parameters.AddWithValue("@ActualListedPrice", param.ActualListedPrice);
                cmd.Parameters.AddWithValue("@MSRP", param.MSRP);
                cmd.Parameters.AddWithValue("@IsNew", param.IsNew);
                cmd.Parameters.AddWithValue("@IsFeatured", param.IsFeatured);
                cmd.Parameters.AddWithValue("@Year", param.Year);
                cmd.Parameters.AddWithValue("@ImagePath", param.ImagePath);
                cmd.Parameters.AddWithValue("@Description", param.Description);
                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }


        public List<Color> GetAllColors()
        {
            List<Color> colorList = new List<Color>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllColors", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Color color = new Color();

                        color.ColorId = (int)dr["ColorId"];
                        color.ColorName = dr["ColorName"].ToString();

                        colorList.Add(color);
                    }
                }

                return colorList;
            }

        }

        public List<BodyStyle> GetAllBodyStyles()
        {
            List<BodyStyle> bodyList = new List<BodyStyle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllBodyStyles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle body = new  BodyStyle();

                        body.BodyStyleId = (int)dr["BodyStyleId"];
                        body.BodyStyleName = dr["BodyStyleName"].ToString();

                        bodyList.Add(body);
                    }
                }

                return bodyList;
            }

        }

        public List<Transmission> GetAllTransmissionTypes()
        {
            List<Transmission> TransList = new List<Transmission>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllTransmissionTypes", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission trans = new Transmission();

                        trans.TransmissionId = (int)dr["TransmissionId"];
                        trans.TransmissionName = dr["TransmissionName"].ToString();

                        TransList.Add(trans);
                    }
                }

                return TransList;
            }

        }

        public void UpdateVehicle (Vehicle v)
        {
            using (SqlConnection cnn = new SqlConnection(Settings.GetConnectionString()))
            {
                cnn.ConnectionString = Settings.GetConnectionString();
                
                SqlCommand cmd = new SqlCommand("UpdateVehicle", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", v.VehicleId);
                cmd.Parameters.AddWithValue("@ModelId", v.ModelId);
                cmd.Parameters.AddWithValue("@TransmissionId", v.TransmissionId);
                cmd.Parameters.AddWithValue("@BodyStyleId", v.BodystyleId);
                cmd.Parameters.AddWithValue("@InteriorColorId", v.InteriorColorId);
                cmd.Parameters.AddWithValue("@ColorId", v.VehicleColorId);
                cmd.Parameters.AddWithValue("@Mileage", v.Mileage);
                cmd.Parameters.AddWithValue("@Vin",v.Vin);
                cmd.Parameters.AddWithValue("@MinumSalePrice", v.MinumSalePrice);
                cmd.Parameters.AddWithValue("@ActualListedPrice", v.ActualListedPrice);
                cmd.Parameters.AddWithValue("@MSRP", v.MSRP);
                cmd.Parameters.AddWithValue("@IsNew", v.IsNew);
                cmd.Parameters.AddWithValue("@IsFeatured", v.IsFeatured);
                cmd.Parameters.AddWithValue("@Year", v.Year);
                cmd.Parameters.AddWithValue("@ImagePath", v.ImagePath);
                cmd.Parameters.AddWithValue("@Description", v.Description);

                cnn.Open();
                cmd.ExecuteNonQuery();
                

            }
        }

        public void DeleteVehicle(int VehicleId)
        {
            using (var cnn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("DeleteVehicle", cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleId", VehicleId);
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Need SQL Sprocs for the last 2
        /// </summary>
        public void AddMake (string makeName)
        {
            using (var cnn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("AddMake",cnn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeName", makeName);
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void AddModel(Model model)
        {
            using (var cnn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("AddModel", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeId", model.MakeId);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);

                cnn.Open();
                cmd.ExecuteNonQuery();
            
            }
        }
    }
}
