using System;
using System.Collections.Generic;
using Domain;
using Services.Abstract;
using Mappers;
using Data.Repositories;

namespace Services
{
    public class ClientsService : IClientsService
    {
        private static ClientRepository clientRepository = new ClientRepository();
        private List<Client> _clients = clientRepository.GetClients().ToDomainList();

        public void AddOrUpdateClient(Client client)
        {
            bool toUpdate = false;

            foreach(var DBClient in _clients)
            {
                if (DBClient.IdentificationCode == client.IdentificationCode || DBClient.BankAccountNumber == client.BankAccountNumber)
                {
                    toUpdate = true;
                }
            }

            if (toUpdate == true)
                clientRepository.UpdateClient(client.ToEntity());
            else
                clientRepository.AddClient(client.ToEntity());
        }

        public bool DeleteClient(string id)
        {
            try
            {
                _clients = clientRepository.GetClients().ToDomainList();
                Client clientToDelete = _clients.Find(client => client.IdentificationCode == id || client.BankAccountNumber == id);

                if(clientToDelete == null)
                {
                    throw new Exception("Об'єкта не існує");
                }
                else
                {
                    clientRepository.DeleteClient(clientToDelete.ToEntity());
                    return true;
                } 
            }
            catch(Exception)
            {
                return false;
            }                       
        }

        public Client GetClient(string id)
        {
            try
            {
                _clients = clientRepository.GetClients().ToDomainList();
                Client findedClient = _clients.Find(client => client.IdentificationCode == id || client.BankAccountNumber == id);

                if (findedClient == null)
                    throw new Exception("Об'єкта не існує");
                else
                 return _clients.Find(client => client.IdentificationCode == id || client.BankAccountNumber == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Client> GetClientsListSortedByName()
        {
            _clients = clientRepository.GetClients().ToDomainList();
            _clients.Sort((first, second) => first.Name.CompareTo(second.Name));

            return _clients;
        }

        public List<Client> GetClientsListSortedByLastName()
        {
            _clients = clientRepository.GetClients().ToDomainList();
            _clients.Sort((first, second) => first.LastName.CompareTo(second.LastName));

            return _clients;
        }

        public List<Client> GetClientsListSortedByBankAccountNumber()
        {
            _clients = clientRepository.GetClients().ToDomainList();
            _clients.Sort((first, second) => first.BankAccountNumber.CompareTo(second.BankAccountNumber));

            return _clients;
        }
    }
}
