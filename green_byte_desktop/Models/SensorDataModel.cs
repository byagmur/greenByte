using System;

namespace GreenByte.Models
{
    public class SensorData
    {
        public int Id { get; set; }
        public int SensorId { get; set; }
        public decimal Value { get; set; }
        public DateTime RecordTime { get; set; }
        
    }

}