using System;


namespace GreenByte.Models
{
    public class GreenHouseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime CreationDate { get; set; } // oluşturma tarihi
        public DateTime EstablishmentDate { get; set; } // kurulus tarihi
    }

    public static class CurrentGreenhouse
    {
        public static GreenHouseModel Selected { get; set; }
    }

}