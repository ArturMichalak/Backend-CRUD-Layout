using backend.Entities;
using backend.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace backend.Web.Controllers
{
    public class WorkingTimeLogController : ApiController
    {
        [HttpGet, Route("wtls")]
        public async Task<IHttpActionResult> Get() => Json(await _rep.Get());

        [HttpGet, Route("wtl/{id}")]
        public async Task<IHttpActionResult> Get(int id) => Json(await _rep.Get(id));

        [HttpGet, Route("wtl/{count}/{skip}")]
        public async Task<IHttpActionResult> Get(int count, int skip) => Json(await _rep.Get(count, skip));

        [HttpPost, Route("wtl")]
        public async Task<IHttpActionResult> Insert([FromBody] WorkingTimeLog body)
        {
            await _rep.Insert(body);
            return Ok();
        }

        [HttpPut, Route("wtl")]
        public async Task<IHttpActionResult> Update([FromBody] WorkingTimeLog body)
        {
            await _rep.Update(body, body.LogId);
            return Ok();
        }

        [HttpDelete, Route("wtl/{id}")]
        public async Task<IHttpActionResult> Remove(int id)
        {
            await _rep.Delete(id);
            return Ok();
        }

        public WorkingTimeLogController(IRepository<WorkingTimeLog> rep) => _rep = rep;
        private readonly IRepository<WorkingTimeLog> _rep;
    }
}
