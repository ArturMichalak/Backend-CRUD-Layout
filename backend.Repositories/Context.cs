using backend.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public partial class Context
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RoutePoint> RoutePoints { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<WorkingTimeLog> WorkingTimeLogs { get; set; }
    }

    public partial class Context : IdentityDbContext<ApplicationUser>
    {
        public Context() : base("DefaultConnection", throwIfV1Schema: false) { }
    }

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
