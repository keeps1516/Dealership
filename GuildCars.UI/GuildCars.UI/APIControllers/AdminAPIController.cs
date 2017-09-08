using GuildCars.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.APIControllers
{
    public class AdminAPIController : ApiController
    {

        [Route ("api/admin/getmodels")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModels(int id)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                 var models= repo.GetMakeModel(id);

                return Ok(models);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
