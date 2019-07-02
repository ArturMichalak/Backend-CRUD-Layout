using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Truck
    {
        [Key] public int Id { get; set; }
        [Required] public string VIN { get; set; }
        [Required] public string RegistrationNumber { get; set; }
        public DateTime ServicingDate { get; set; }
        public DateTime ServicingEndDate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public string EmissionStandard { get; set; }
    }
}
