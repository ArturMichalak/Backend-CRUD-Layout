using backend.Entities;
using backend.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace backend.Web.Controllers
{
    public class RoutePointController : ApiController
    {
        [HttpGet, Route("rps")]
        public async Task<IHttpActionResult> Get() => Json(await _rep.Get());

        [HttpGet, Route("rp/{id}")]
        public async Task<IHttpActionResult> Get(int id) => Json(await _rep.Get(id));

        [HttpGet, Route("rp/{count}/{skip}")]
        public async Task<IHttpActionResult> Get(int count, int skip) => Json(await _rep.Get(count, skip));

        [HttpPost, Route("rp")]
        public async Task<IHttpActionResult> Insert([FromBody] RoutePoint body)
        {
            await _rep.Insert(body);
            return Ok();
        }

        [HttpPut, Route("rp")]
        public async Task<IHttpActionResult> Update([FromBody] RoutePoint body)
        {
            await _rep.Update(body, body.RoutePointId);
            return Ok();
        }

        [HttpDelete, Route("rp/{id}")]
        public async Task<IHttpActionResult> Remove(int id)
        {
            await _rep.Delete(id);
            return Ok();
        }

        public RoutePointController(IRepository<RoutePoint> rep) => _rep = rep;
        private readonly IRepository<RoutePoint> _rep;
    }
}
