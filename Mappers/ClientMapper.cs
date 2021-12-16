using System;
using System.Collections.Generic;
using Domain;
using Entities;
using Models;

namespace Mappers
{
    public static class ClientMapper
    {
        public static ClientEntity ToEntity(this Client client)
        {
            return new ClientEntity
            {
                ID = client.ID,
                dateTime = client.dateTime, 
                Name = client.Name,
                LastName = client.LastName,
                Age = client.Age,
                IdentificationCode = client.IdentificationCode,
                BankAccountNumber = client.BankAccountNumber,
                Email = client.Email,               
                City = client.City,
                RealtyType = client.RealtyType,
                RoomsNumber = client.RoomsNumber,
                Area = client.Area,
                Budget = client.Budget
            };
        }

        public static Client ToDomain(this ClientEntity client)
        {
            return new Client
            {
                ID = client.ID,
                dateTime = client.dateTime,
                Name = client.Name,
                LastName = client.LastName,
                Age = client.Age,
                IdentificationCode = client.IdentificationCode,
                BankAccountNumber = client.BankAccountNumber,
                Email = client.Email,
                City = client.City,
                RealtyType = client.RealtyType,
                RoomsNumber = client.RoomsNumber,
                Area = client.Area,
                Budget = client.Budget
            };
        }

        public static Client ToDomain(this ClientModel client)
        {
            return new Client
            {
                Name = client.Name,
                LastName = client.LastName,
                Age = client.Age,
                IdentificationCode = client.IdentificationCode,
                BankAccountNumber = client.BankAccountNumber,
                Email = client.Email,
                City = client.City,
                RealtyType = client.RealtyType,
                RoomsNumber = client.RoomsNumber,
                Area = client.Area,
                Budget = client.Budget
            };
        }

        public static List<Client> ToDomainList(this List<ClientEntity> clients)
        {
            List<Client> domainClients = new List<Client>();

            if (clients == null)
            {
                return domainClients;
            }

            foreach(var client in clients)
            {
                domainClients.Add(new Client()
                {
                    ID = client.ID,
                    dateTime = client.dateTime,
                    Name = client.Name,
                    LastName = client.LastName,
                    Age = client.Age,
                    IdentificationCode = client.IdentificationCode,
                    BankAccountNumber = client.BankAccountNumber,
                    Email = client.Email,
                    City = client.City,
                    RealtyType = client.RealtyType,
                    RoomsNumber = client.RoomsNumber,
                    Area = client.Area,
                    Budget = client.Budget
                });
            }

            return domainClients;
        }

        public static List<ClientModel> ToModelList(this List<Client> clients)
        {
            List<ClientModel> modelsClients = new List<ClientModel>();

            if (clients == null)
            {
                return modelsClients;
            }

            foreach (var client in clients)
            {
                modelsClients.Add(new ClientModel()
                {
                    Name = client.Name,
                    LastName = client.LastName,
                    Age = client.Age,
                    IdentificationCode = client.IdentificationCode,
                    BankAccountNumber = client.BankAccountNumber,
                    Email = client.Email,
                    City = client.City,
                    RealtyType = client.RealtyType,
                    RoomsNumber = client.RoomsNumber,
                    Area = client.Area,
                    Budget = client.Budget
                });
            }

            return modelsClients;
        }

        public static ClientModel ToModel(this Client client)
        {
            return new ClientModel
            {
                Name = client.Name,
                LastName = client.LastName,
                Age = client.Age,
                IdentificationCode = client.IdentificationCode,
                BankAccountNumber = client.BankAccountNumber,
                Email = client.Email,
                City = client.City,
                RealtyType = client.RealtyType,
                RoomsNumber = client.RoomsNumber,
                Area = client.Area,
                Budget = client.Budget
            };
        }
    }
}
