using System;

namespace GreenByte.Models
{
    public class DeviceEvent
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public DeviceAction Action { get; set; }
        public TriggerType Trigger { get; set; }
        public DateTime Time { get; set; }
    }

    public enum DeviceAction
    {
        On,
        Off
    }

    public enum TriggerType
    {
        Manual,
        Automatic
    }
}