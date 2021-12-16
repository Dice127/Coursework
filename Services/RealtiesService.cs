using System;
using System.Collections.Generic;
using Domain;
using Services.Abstract;
using Data.Repositories;
using Mappers;

namespace Services
{
    public class RealtiesService : IRealtiesService
    {
        private static RealtyRepository realtyRepository = new RealtyRepository();
        private List<Realty> _realties = realtyRepository.GetRealties().ToDomainList();
        public void AddOrUpdateRealty(Realty realty)
        {
            bool toUpdate = false;

            foreach (var DBRealty in _realties)
            {
                if (DBRealty.RealtyID == realty.RealtyID)
                {
                    toUpdate = true;
                }
            }

            if (toUpdate == true)
                realtyRepository.UpdateRealty(realty.ToEntity());
            else
                realtyRepository.AddRealty(realty.ToEntity());
        }

        public bool DeleteRealty(string id)
        {
            try
            {
                _realties = realtyRepository.GetRealties().ToDomainList();
                Realty realtyToDelete = _realties.Find(realty => realty.RealtyID == id || realty.RealtyID == id);

                if (realtyToDelete == null)
                {
                    throw new Exception("Об'єкта не існує");
                }
                else
                {
                    realtyRepository.DeleteRealty(realtyToDelete.ToEntity());
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Realty GetRealty(string id)
        {
            try
            {
                _realties = realtyRepository.GetRealties().ToDomainList();
                Realty findedRealty = _realties.Find(realty => realty.RealtyID == id || realty.RealtyID == id);

                if (findedRealty == null)
                    throw new Exception("Об'єкта не існує");
                else
                    return _realties.Find(realty => realty.RealtyID == id || realty.RealtyID == id);
            }
            catch (Exception)
            {
                return null;
            }    

                
        }

        public List<Realty> GetRealtiesListSortedByType()
        {
            _realties = realtyRepository.GetRealties().ToDomainList();

            List<Realty> flats = new List<Realty>();
            List<Realty> privateHouse = new List<Realty>();

            foreach(var flat in _realties){
                if (flat.RealtyType == "Квартира")
                {
                    flats.Add(flat);    
                }
            }

            foreach(var house in _realties)
            {
                if (house.RealtyType == "Приватний будинок")
                {
                    flats.Add(house);
                }
            }
            
            flats.Sort((first, second) => first.RoomsNumber.CompareTo(second.RoomsNumber));
            privateHouse.Sort((first, second) => first.RoomsNumber.CompareTo(second.RoomsNumber));

            foreach (var house in privateHouse)
            {
                flats.Add(house);
            }

            return flats;
        }

        public List<Realty> GetRealtiesListSortedByPrice()
        {
            _realties = realtyRepository.GetRealties().ToDomainList();
            _realties.Sort((first, second) => first.Price.CompareTo(second.Price));

            return _realties;
        }
    }
}
