using System;

namespace GreenByte.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public int GreenhouseId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime AddedDate { get; set; }
    }
}