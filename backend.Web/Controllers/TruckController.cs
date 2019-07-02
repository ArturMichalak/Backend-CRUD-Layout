using backend.Entities;
using backend.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace backend.Web.Controllers
{
    public class TruckController : ApiController
    {
        [HttpGet, Route("trucks")]
        public async Task<IHttpActionResult> Get() => Json(await _rep.Get());

        [HttpGet, Route("truck/{id}")]
        public async Task<IHttpActionResult> Get(int id) => Json(await _rep.Get(id));

        [HttpGet, Route("truck/{count}/{skip}")]
        public async Task<IHttpActionResult> Get(int count, int skip) => Json(await _rep.Get(count, skip));

        [HttpPost, Route("truck")]
        public async Task<IHttpActionResult> Insert([FromBody] Truck body)
        {
            await _rep.Insert(body);
            return Ok();
        }

        [HttpPut, Route("truck")]
        public async Task<IHttpActionResult> Update([FromBody] Truck body)
        {
            await _rep.Update(body, body.Id);
            return Ok();
        }

        [HttpDelete, Route("truck/{id}")]
        public async Task<IHttpActionResult> Remove(int id)
        {
            await _rep.Delete(id);
            return Ok();
        }

        public TruckController(IRepository<Truck> rep) => _rep = rep;
        private readonly IRepository<Truck> _rep;
    }
}
