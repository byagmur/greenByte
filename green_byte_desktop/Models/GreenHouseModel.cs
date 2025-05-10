using System;

namespace GreenByte.Models
{
    public class Greenhouse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime CreationDate { get; set; }
    }

  public static class CurrentGreenhouse
    {
        public static Greenhouse Selected { get; set; }
    }
    
}