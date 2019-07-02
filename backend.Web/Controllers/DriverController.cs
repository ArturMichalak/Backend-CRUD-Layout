using backend.Entities;
using backend.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace backend.Web.Controllers
{
    public class DriverController : ApiController
    {
        [HttpGet, Route("drivers")]
        public async Task<IHttpActionResult> Get() => Json(await _rep.Get());

        [HttpGet, Route("driver/{id}")]
        public async Task<IHttpActionResult> Get(int id) => Json(await _rep.Get(id));

        [HttpGet, Route("driver/{count}/{skip}")]
        public async Task<IHttpActionResult> Get(int count, int skip) => Json(await _rep.Get(count, skip));

        [HttpPost, Route("driver")]
        public async Task<IHttpActionResult> Insert([FromBody] Driver body)
        {
            await _rep.Insert(body);
            return Ok();
        }

        [HttpPut, Route("driver")]
        public async Task<IHttpActionResult> Update([FromBody] Driver body)
        {
            await _rep.Update(body, body.DriverId);
            return Ok();
        }

        [HttpDelete, Route("driver/{id}")]
        public async Task<IHttpActionResult> Remove(int id)
        {
            await _rep.Delete(id);
            return Ok();
        }

        public DriverController(IRepository<Driver> rep) => _rep = rep;
        private readonly IRepository<Driver> _rep;
    }
}
