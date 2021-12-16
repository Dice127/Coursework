using System;
using System.Collections.Generic;
using Domain;
using Entities;

namespace Mappers
{
    public static class OffersMapper
    {
        public static List<Offers> ToDomainList(this List<OffersEntity> offers)
        {
            List<Offers> domainOffers = new List<Offers>();

            if (offers == null)
            {
                return domainOffers;
            }

            foreach (var offer in offers)
            {
                domainOffers.Add(new Offers()
                {
                    ID = offer.ID,
                    dateTime = offer.dateTime,
                    Client = offer.Client.ToDomain(),
                    ClientOffers = offer.Offers.ToDomainList()
                });
            }

            return domainOffers;
        }

        public static OffersEntity ToEntity(this Offers offers)
        {
            return new OffersEntity()
            {
                ID = offers.ID,
                dateTime = offers.dateTime,
                Client = offers.Client.ToEntity(),
               Offers = offers.ClientOffers.ToEntityList()
            };
        }
    }
}
