using Entities.Abstract;
using System;

namespace Entities
{
    [Serializable]
    public class RealtyEntity : BaseEntity
    {
        public string RealtyID { get; set; }
        public string City { get; set; }
        public string RealtyType { get; set; }
        public int RoomsNumber { get; set; }
        public double Area { get; set; }
        public double Price { get; set; }
    }
}
