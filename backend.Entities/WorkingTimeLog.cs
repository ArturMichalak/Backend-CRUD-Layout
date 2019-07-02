using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class WorkingTimeLog
    {
        [Key] public int LogId { get; set; }
        [Required] public Driver Driver { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
