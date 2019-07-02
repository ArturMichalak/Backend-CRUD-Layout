using backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class RoutePointRepository : Repository<RoutePoint>
    {
        public RoutePointRepository(Context db) : base(db) { }
    }
}
