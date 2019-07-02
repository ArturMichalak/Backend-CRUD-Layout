using backend.Entities;
using backend.Repositories;
using backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace backend.Web.Controllers
{
    public class DriverController : ApiController
    {
        /*[HttpGet, Route("drivers")]
        public async Task<IHttpActionResult> Get() => Json(await _drivers.Get());

        
        [HttpPost, Route("driver")]
        public async Task<IHttpActionResult> Insert([FromBody] Driver driverContext)
        {
            await _drivers.Insert(driverContext);
            return Ok();
        }*/

        [HttpGet, Route("dTest")]
        public IHttpActionResult Test() => Ok();
        
        public DriverController(IRepository<Driver> drivers)
        {
            //_drivers = drivers;
        }

        //private readonly IRepository<Driver> _drivers;
    }
}
