using System;
using Services;
using Models;
using Mappers;
using System.Collections.Generic;

namespace API.Controllers
{
    public class ClientController
    {
        private ClientsService clientsService = new ClientsService();

        public ClientController()
        {

        }

        public void AddOrUpdateClient(string Name, string LastName, int Age, string IdentificationCode, string BankAccountNumber, string Email, string City, string RealtyType, int RoomsNumber, double Area, int Budget)
        {
            ClientModel client = new ClientModel
            {
                Name = Name,
                LastName = LastName,
                Age = Age,
                IdentificationCode = IdentificationCode,
                BankAccountNumber = BankAccountNumber,
                Email = Email,
                City = City,
                RealtyType = RealtyType,
                RoomsNumber = RoomsNumber,
                Area = Area,
                Budget = Budget
            };

            clientsService.AddOrUpdateClient(client.ToDomain());
        }

        public bool DeleteClient(string idOrBank)
        {
            return clientsService.DeleteClient(idOrBank);
        }

        public ClientModel GetClient(string idOrBank)
        {
            if (clientsService.GetClient(idOrBank) == null)
            {
                return null;
            }

            return clientsService.GetClient(idOrBank).ToModel();
        }

        public string GetClientInfo(string idOrBank)
        {
            ClientModel client = GetClient(idOrBank);

            if(client == null)
            {
                return "Клієнт з такими даними не існує";
            }

            return $"Ім'я: {client.Name}\n" +
                   $"Прізвище: {client.LastName}\n" +
                   $"Вік: {client.Age}\n" +
                   $"Ідентифікаційний код: {client.IdentificationCode}\n" +
                   $"Номер банківського рахунку: {client.BankAccountNumber}\n" +
                   $"Електронна пошта: {client.Email}\n" +
                   $"Бажанне місто проживання: {client.City}\n" +
                   $"Тип нерухомості: {client.RealtyType}\n" +
                   $"Кількість або номер поверху: {client.RoomsNumber}\n" +
                   $"Площа(квдратні метри): {client.Area}\n";
        }

        public List<ClientModel> GetClientsListSortedByName()
        {
            return clientsService.GetClientsListSortedByName().ToModelList();
        }

        public List<ClientModel> GetClientsListSortedByLastName()
        {
            return clientsService.GetClientsListSortedByLastName().ToModelList();
        }

        public List<ClientModel> GetClientsListSortedByBankAccountNumber()
        {
            return clientsService.GetClientsListSortedByBankAccountNumber().ToModelList();
        }
    }
}
