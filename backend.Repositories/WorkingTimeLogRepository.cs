using backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class WorkingTimeLogRepository : Repository<WorkingTimeLog>
    {
        public WorkingTimeLogRepository(Context db) :base(db) { }
    }
}
