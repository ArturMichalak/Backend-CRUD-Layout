using backend.Entities;

namespace backend.Repositories
{
    public class DriverRepository : Repository<Driver>
    {
        public DriverRepository(Context db) : base(db) { }
    }
}
