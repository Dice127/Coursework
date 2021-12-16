using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Offers
    {
        public int ID { get; set; }
        public DateTime dateTime { get; set; }
        public Client Client { get; set; }
        public List<Realty> ClientOffers { get; set; }
    }
}
