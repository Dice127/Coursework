using System;
using Services.Abstract;
using Services;
using Models;
using Mappers;
using System.Collections.Generic;

namespace API.Controllers
{
    public class RealtyController
    {
        private RealtiesService realtiesService = new RealtiesService();

        public RealtyController()
        {

        }

        public void AddOrUpdateRealty(string RealtyID, string City, string RealtyType, int RoomsNumber, double Area, double Price)
        {
            RealtyModel realty = new RealtyModel
            {
                RealtyID = RealtyID,
                City = City,
                RealtyType = RealtyType,
                RoomsNumber = RoomsNumber,
                Area = Area,
                Price = Price
            };

            realtiesService.AddOrUpdateRealty(realty.ToDomain());
        }

        public bool DeleteRealty(string id)
        {
            return realtiesService.DeleteRealty(id);
        }

        public RealtyModel GetRealty(string id)
        {
            if (realtiesService.GetRealty(id) == null)
            {
                return null;
            }

            return realtiesService.GetRealty(id).ToModel();
        }

        public string GetRealtyInfo(string id)
        {
            RealtyModel realty = GetRealty(id);

            if (realty == null)
            {
                return "Нерухомості з такими даними не існує";
            }

            return $"Ідентифікаційний код нерухомості: {realty.RealtyID}\n" +
                   $"Розміщення: {realty.City}\n" +
                   $"Тип нерухомості: {realty.RealtyType}\n" +
                   $"Кількість кімнат: {realty.RoomsNumber}\n" +
                   $"Площа(квдратні метри): {realty.Area}\n" +
                   $"Ціна: {realty.Price}\n";
        }

        public List<RealtyModel> GetRealtiesListSortedByType()
        {
            return realtiesService.GetRealtiesListSortedByType().ToModelList();
        }

        public List<RealtyModel> GetRealtiesListSortedByPrice()
        {
            return realtiesService.GetRealtiesListSortedByPrice().ToModelList();
        }
    }
}
