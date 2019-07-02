using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Driver
    {
        [Key] public int DriverId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Pesel { get; set; }
        public string Hiredate { get; set; }
        public string AccountNo { get; set; }
        public string Address { get; set; }
    }
}
