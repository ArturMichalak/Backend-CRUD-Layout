using backend.Entities;
using backend.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace backend.Web.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet, Route("orders")]
        public async Task<IHttpActionResult> Get() => Json(await _rep.Get());

        [HttpGet, Route("order/{id}")]
        public async Task<IHttpActionResult> Get(int id) => Json(await _rep.Get(id));

        [HttpGet, Route("order/{count}/{skip}")]
        public async Task<IHttpActionResult> Get(int count, int skip) => Json(await _rep.Get(count, skip));

        [HttpPost, Route("order")]
        public async Task<IHttpActionResult> Insert([FromBody] Order body)
        {
            await _rep.Insert(body);
            return Ok();
        }

        [HttpPut, Route("order")]
        public async Task<IHttpActionResult> Update([FromBody] Order body)
        {
            await _rep.Update(body, body.OrderId);
            return Ok();
        }

        [HttpDelete, Route("order/{id}")]
        public async Task<IHttpActionResult> Remove(int id)
        {
            await _rep.Delete(id);
            return Ok();
        }

        public OrderController(IRepository<Order> rep) => _rep = rep;
        private readonly IRepository<Order> _rep;
    }
}
