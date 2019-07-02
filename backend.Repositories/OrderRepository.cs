using backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(Context db) : base(db) { }
    }
}
