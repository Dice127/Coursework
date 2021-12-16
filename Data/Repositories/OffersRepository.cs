using System;
using System.Collections.Generic;
using System.IO;
using Entities;
using Newtonsoft.Json;

namespace Data.Repositories
{
    public class OffersRepository
    {
        private static readonly string path = @"C:\Users\admin\source\repos\Coursework\Data\DataBases\offers.json";
        private static string json = File.ReadAllText(path);
        private List<OffersEntity> _offers = JsonConvert.DeserializeObject<List<OffersEntity>>(json);

        public void InitOffers(OffersEntity offers)
        {
            if (_offers == null)
            {
                _offers = new List<OffersEntity>();
                offers.ID = 0;
            }
            else
            {
                offers.ID = _offers.Count;
            }

            offers.dateTime = DateTime.Now.Date;

            _offers.Add(offers);

            File.WriteAllText(path, JsonConvert.SerializeObject(_offers, Formatting.Indented));
        }

        public void UpdateOffers(OffersEntity offers)
        {
            json = File.ReadAllText(path);
            _offers = JsonConvert.DeserializeObject<List<OffersEntity>>(json);

            _offers[offers.ID] = offers;
            File.WriteAllText(path, JsonConvert.SerializeObject(_offers, Formatting.Indented));
        }

        public List<OffersEntity> GetOffers()
        {
            json = File.ReadAllText(path);
            _offers = JsonConvert.DeserializeObject<List<OffersEntity>>(json);
            return _offers;
        }
    }
}
