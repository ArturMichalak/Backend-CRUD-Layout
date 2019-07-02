using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Order
    {
        [Key] public int OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Customer { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerNIP { get; set; }
        public string CargoType { get; set; }
        public bool IsADR { get; set; }
        public int CargoSize { get; set; }
        public string CargoSizeUnit { get; set; }
        public int CargoValue { get; set; }
        public string Currency { get; set; }
        ICollection<Driver> DriversAssignee { get; set; }
        public Truck Truck { get; set; }
        public string TrailerRegistrationNumber { get; set; }
        public string TrailerType { get; set; }
        public int LoadingId { get; set; }
        public int UnloadingId { get; set; }
        public int FreightRateValue { get; set; }
        public string FreightRateCurrency { get; set; }
        public DateTime FreightRateDeadline { get; set; }
        public bool IsExecuted { get; set; }
    }
}
