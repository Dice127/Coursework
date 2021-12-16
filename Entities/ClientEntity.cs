using Entities.Abstract;
using System;

namespace Entities
{
    [Serializable]
    public class ClientEntity : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string IdentificationCode { get; set; }
        public string BankAccountNumber { get; set; }
        public string Email { get; set; }        
        public string City { get; set; }
        public string RealtyType { get; set; }
        public int RoomsNumber { get; set; }
        public double Area { get; set; }
        public double Budget { get; set; }
    }
}
