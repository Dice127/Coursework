using System;
using System.Collections.Generic;
using Entities.Abstract;

namespace Entities
{
    public class OffersEntity : BaseEntity
    {
        public ClientEntity Client { get; set; }
        public List<RealtyEntity> Offers { get; set; }
    }
}
