using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data.Repositories.Abstract;
using Entities;
using Newtonsoft.Json;

namespace Data.Repositories
{
    public class ClientRepository : IClientsRepository
    {
        private static readonly string path = @"C:\Users\admin\source\repos\Coursework\Data\DataBases\clients.json";
        private static string json = File.ReadAllText(path);
        private List<ClientEntity> _clients = new List<ClientEntity>();

        public void AddClient(ClientEntity client)
        {
            json = File.ReadAllText(path);
            _clients = JsonConvert.DeserializeObject<List<ClientEntity>>(json);

            if (_clients == null)
            {
                _clients = new List<ClientEntity>();
                client.ID = 0;
            }
            else
            {
                client.ID = _clients.Count;
            }                

            client.dateTime = DateTime.Now.Date;

            _clients.Add(client);

            File.WriteAllText(path, JsonConvert.SerializeObject(_clients, Formatting.Indented));
        }

        public void DeleteClient(ClientEntity client)
        {
            json = File.ReadAllText(path);
            _clients = JsonConvert.DeserializeObject<List<ClientEntity>>(json);

            _clients.RemoveAt(client.ID);

            for (int i = 0; i < _clients.Count; i++)
            {
                if(_clients[i].ID > client.ID)
                {
                    _clients[i].ID--;
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(_clients, Formatting.Indented));
        }

        public List<ClientEntity> GetClients()
        {
            json = File.ReadAllText(path);
            _clients = JsonConvert.DeserializeObject<List<ClientEntity>>(json);

            if (_clients == null)
                _clients = new List<ClientEntity>();

            return _clients;
        }

        public void UpdateClient(ClientEntity client)
        {
            json = File.ReadAllText(path);
            _clients = JsonConvert.DeserializeObject<List<ClientEntity>>(json);

            _clients[client.ID] = client;

            File.WriteAllText(path, JsonConvert.SerializeObject(_clients, Formatting.Indented));
        }
    }
}
