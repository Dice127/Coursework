using System;
using System.Collections.Generic;
using Services;
using Mappers;
using Models;

namespace API.Controllers
{
    public class OffersController
    {
        private OffersService offersService = new OffersService();

        public string GetOffersInfo(ClientModel client)
        {
            List<RealtyModel> offersRealties = new List<RealtyModel>();

            offersRealties = offersService.GetOffers(client.ToDomain()).ToModelList();

            string res = "";

            for(int i = 0; i < offersRealties.Count; i++)
            {
                var offer = offersRealties[i];

                if (res != "")
                    res += $"\n---------------------------- \n\n";

                res += $"Пропозиція №{i + 1}\n" +
                       $"Ідентифікаційний код нерухомості: {offer.RealtyID}\n" +
                       $"Розміщення: {offer.City}\n" +
                       $"Тип нерухомості: {offer.RealtyType}\n" +
                       $"Кількість або номер поверху: {offer.RoomsNumber}\n" +
                       $"Площа(квдратні метри): {offer.Area}\n" +
                       $"Ціна: {offer.Price}\n";
            }

            return res;
        }

        public string UpdateAndGetOffersInfo(ClientModel client)
        {
            List<RealtyModel> offersRealties = new List<RealtyModel>();

            offersService.InitOffers(client.ToDomain());

            offersRealties = offersService.GetOffers(client.ToDomain()).ToModelList();

            string res = "";

            for (int i = 0; i < offersRealties.Count; i++)
            {
                var offer = offersRealties[i];

                if (res != "")
                    res += $"\n---------------------------- \n\n";

                res += $"Пропозиція №{i + 1}\n" +
                       $"Ідентифікаційний код нерухомості: {offer.RealtyID}\n" +
                       $"Розміщення: {offer.City}\n" +
                       $"Тип нерухомості: {offer.RealtyType}\n" +
                       $"Кількість або номер поверху: {offer.RoomsNumber}\n" +
                       $"Площа(квдратні метри): {offer.Area}\n" +
                       $"Ціна: {offer.Price}\n";
            }

            return res;
        }

        public bool CheckDesirableRealty(ClientModel client)
        {
            return offersService.CheckDesirableRealty(client.ToDomain());
        }

        public bool RejectOffer(ClientModel client, int number)
        {
            return offersService.DeleteOffer(client.ToDomain(), number - 1);
        }
    }
}
