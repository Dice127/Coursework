using System;
using System.Collections.Generic;
using System.IO;
using Data.Repositories.Abstract;
using Entities;
using Newtonsoft.Json;

namespace Data.Repositories
{
    public class RealtyRepository : IRealtiesRepository
    {
        private static readonly string path = @"C:\Users\admin\source\repos\Coursework\Data\DataBases\realties.json";
        private static string json = File.ReadAllText(path);
        private static List<RealtyEntity> _realties;

        public void AddRealty(RealtyEntity realty)
        {
            json = File.ReadAllText(path);
            _realties = JsonConvert.DeserializeObject<List<RealtyEntity>>(json);

            if (_realties == null)
            {
                _realties = new List<RealtyEntity>();
                realty.ID = 0;
            }
            else
            {
                realty.ID = _realties.Count;
            }

            realty.dateTime = DateTime.Now.Date;

            _realties.Add(realty);

            File.WriteAllText(path, JsonConvert.SerializeObject(_realties, Formatting.Indented));
        }

        public void DeleteRealty(RealtyEntity realty)
        {
            json = File.ReadAllText(path);
            _realties = JsonConvert.DeserializeObject<List<RealtyEntity>>(json);

            _realties.RemoveAt(realty.ID);

            for (int i = 0; i < _realties.Count; i++)
            {
                if (_realties[i].ID > realty.ID)
                {
                    _realties[i].ID--;
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(_realties, Formatting.Indented));
        }

        public List<RealtyEntity> GetRealties()
        {
            json = File.ReadAllText(path);
            _realties = JsonConvert.DeserializeObject<List<RealtyEntity>>(json);

            return _realties;
        }

        public void UpdateRealty(RealtyEntity realty)
        {
            json = File.ReadAllText(path);
            _realties = JsonConvert.DeserializeObject<List<RealtyEntity>>(json);

            _realties[realty.ID] = realty;
            File.WriteAllText(path, JsonConvert.SerializeObject(_realties, Formatting.Indented));
        }
    }
}
