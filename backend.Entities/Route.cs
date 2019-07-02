using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Route
    {
        [Key] public int RouteId { get; set; }
        public ICollection<RoutePoint> RoutePoints { get; set; }
    }
}
