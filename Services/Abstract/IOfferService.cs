using Domain;
using System.Collections.Generic;

namespace Services.Abstract
{
    interface IOfferService
    {
        List<Realty> GetOffers(Client client);
        bool CheckDesirableRealty(Client client);
        bool DeleteOffer(Client client, int id);
    }
}
