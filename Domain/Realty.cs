using System;

namespace Domain
{
    public class Realty
    {
        public int ID { get; set; }
        public DateTime dateTime { get; set; }
        public string RealtyID { get; set; }
        public string City { get; set; }
        public string RealtyType { get; set; }
        public int RoomsNumber { get; set; }
        public double Area { get; set; }
        public double Price { get; set; }
        public double DesirableCount { get; set; }
    }
}
