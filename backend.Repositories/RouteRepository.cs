using backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class RouteRepository : Repository<Route>
    {
        public RouteRepository(Context db) : base(db) { }
    }
}
