using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class RoutePoint
    {
        [Key] public int RoutePointId { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public bool IsLoading { get; set; }
    }
}
