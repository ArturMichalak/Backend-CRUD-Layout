using backend.Entities;
using backend.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace backend.Web.Controllers
{
    public class RouteController : ApiController
    {
        [HttpGet, Route("routes")]
        public async Task<IHttpActionResult> Get() => Json(await _rep.Get());

        [HttpGet, Route("route/{id}")]
        public async Task<IHttpActionResult> Get(int id) => Json(await _rep.Get(id));

        [HttpGet, Route("route/{count}/{skip}")]
        public async Task<IHttpActionResult> Get(int count, int skip) => Json(await _rep.Get(count, skip));

        [HttpPost, Route("route")]
        public async Task<IHttpActionResult> Insert([FromBody] Route body)
        {
            await _rep.Insert(body);
            return Ok();
        }

        [HttpPut, Route("route")]
        public async Task<IHttpActionResult> Update([FromBody] Route body)
        {
            await _rep.Update(body, body.RouteId);
            return Ok();
        }

        [HttpDelete, Route("route/{id}")]
        public async Task<IHttpActionResult> Remove(int id)
        {
            await _rep.Delete(id);
            return Ok();
        }

        public RouteController(IRepository<Route> rep) => _rep = rep;
        private readonly IRepository<Route> _rep;
    }
}
