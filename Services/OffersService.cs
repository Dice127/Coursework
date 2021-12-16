using System;
using System.Collections.Generic;
using Domain;
using Services.Abstract;
using Data.Repositories;
using Mappers;

namespace Services
{
    public class OffersService : IOfferService
    {
        private static RealtyRepository realtyRepository = new RealtyRepository();
        private static OffersRepository offersRepository = new OffersRepository();

        private List<Realty> realties = realtyRepository.GetRealties().ToDomainList();
        private List<Offers> offers = offersRepository.GetOffers().ToDomainList();

        public bool CheckDesirableRealty(Client client)
        {
            foreach (var realty in realties)
            {
                if (client.RealtyType == realty.RealtyType && client.Budget > realty.Price)
                {
                    return true;
                }
            }

            return false;
        }

        public bool DeleteOffer(Client client, int id)
        {
            try
            {
                offers = offersRepository.GetOffers().ToDomainList();

                for (int i = 0; i < offers.Count; i++)
                {
                    if (offers[i].Client.IdentificationCode == client.IdentificationCode)
                    {
                        offers[i].ClientOffers.RemoveAt(id);
                        offersRepository.UpdateOffers(offers[i].ToEntity());
                        return true;
                    }                    
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void InitOffers(Client client)
        {
            realties = realtyRepository.GetRealties().ToDomainList();
            offers = offersRepository.GetOffers().ToDomainList();

            List<Realty> allOffers = new List<Realty>();
            List<Realty> clientOffers = new List<Realty>();
            int counter = 0;

            foreach (var realty in realties)
            {
                if (client.City == realty.City)
                {
                    counter++;
                }
                
                if (client.RealtyType == realty.RealtyType)
                {
                    counter++;
                }
                
                if (client.RoomsNumber == realty.RoomsNumber)
                {
                    counter++;
                }
                
                if (EqualsArea(client.Area, realty.Area))
                {
                    counter++;
                }
                
                if (client.Budget > realty.Price)
                {
                    counter++;
                }

                realty.DesirableCount = counter;

                allOffers.Add(realty);

                counter = 0;
            }

            allOffers.Sort((second, first) => first.DesirableCount.CompareTo(second.DesirableCount));

            for (int i = 0; i < allOffers.Count; i++)
            {
                if (allOffers[i].DesirableCount > 3)
                {
                    clientOffers.Add(allOffers[i]);
                }

                if(clientOffers.Count == 5)
                {
                    break;
                }
            }

            Offers resOffers = new Offers
            {
                Client = client,
                ClientOffers = clientOffers
            };

            bool toUpdate = false;
            foreach (Offers offer in offers)
            {
                if (offer.Client.IdentificationCode == client.IdentificationCode || offer.Client.BankAccountNumber == client.BankAccountNumber)
                {
                    toUpdate = true;
                }
            }

            if(toUpdate)
                offersRepository.UpdateOffers(resOffers.ToEntity());
            else
                offersRepository.InitOffers(resOffers.ToEntity());
        }

        public List<Realty> GetOffers(Client client)
        {
            offers = offersRepository.GetOffers().ToDomainList();

            foreach (var offer in offers)
            {
                if (offer.Client.IdentificationCode == client.IdentificationCode || offer.Client.BankAccountNumber == client.BankAccountNumber)
                {
                    return offer.ClientOffers;
                }
            }

            offers = offersRepository.GetOffers().ToDomainList();

            return offers[offers.Count - 1].ClientOffers;
        }

        private bool EqualsArea(double a, double b)
        {
            double aProccent = (a * 10) / 100;

            bool equal;

            if (a - aProccent < b && a + aProccent > b)
            {
                equal = true;
            }
            else
            {
                equal = false;
            }

            return equal;
        }
    }
}
