using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.APIControllers
{
    public class VehicleAPIController : ApiController
    {
        [Route("api/home")]
        [AcceptVerbs("GET")]
        public IHttpActionResult FeaturedVehicles()
        {
            var model = VehicleRepositoryFactory.GetRepository().GetAllFeaturedVehicles();
            return Ok(model);
        }

        [Route("api/inventory/new/search")]
        [AcceptVerbs("POST")]
        public IHttpActionResult NewVehicles(InventorySearchParamaters param)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                if (param.PricerangeMin == 0)
                {
                       param.PricerangeMin = null;
                }
                if (param.PricerangeMax == 0)
                {
                    param.PricerangeMax = null;
                }
                if (param.YearMin == 0)
                {
                    param.YearMin = null;
                }
                if (param.YearMax == 0)
                {
                    param.YearMax = null;
                }

                var result = repo.SearchNewVehicles(param);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/inventory/used/search")]
        [AcceptVerbs("POST")]
        public IHttpActionResult UsedVehicles(InventorySearchParamaters param)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                if (param.PricerangeMin == 0)
                {
                    param.PricerangeMin = null;
                }
                if (param.PricerangeMax == 0)
                {
                    param.PricerangeMax = null;
                }
                if (param.YearMin == 0)
                {
                    param.YearMin = null;
                }
                if (param.YearMax == 0)
                {
                    param.YearMax = null;
                }

                var result = repo.SearchUsedVehicles(param);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
