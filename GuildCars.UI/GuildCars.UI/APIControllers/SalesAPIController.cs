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
    public class SalesAPIController : ApiController
    {
            [Route("api/sales/all/search")]
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

                    var result = repo.SearchAllVehicles(param);
                    return Ok(result);
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
    }
}
