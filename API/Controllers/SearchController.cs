
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Models;
using Mappers;
using Services;
using System.Linq;
using System;

namespace API.Controllers
{
    public class SearchController
    {
        private ClientController clientController = new ClientController();
        private RealtyController realtyController = new RealtyController();
        private ClientsService clientsService = new ClientsService();
        private RealtiesService realtiesService = new RealtiesService();

        public string FindClientByKeyWord(string key)
        {
            try
            {
                List<ClientModel> clientModels = clientsService.GetClientsListSortedByName().ToModelList();
                List<ClientModel> clients = clientModels.FindAll(client => Regex.IsMatch(client.Name, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(client.LastName, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(client.Age.ToString(), key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(client.IdentificationCode, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(client.BankAccountNumber, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(client.Email, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(client.City, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(client.RealtyType, key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(client.RoomsNumber.ToString(), key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(client.Area.ToString(), key, RegexOptions.IgnoreCase) ||
                                                                           Regex.IsMatch(client.Budget.ToString(), key, RegexOptions.IgnoreCase));

                string res = "";

                foreach (var client in clients)
                {
                    if (res != "")
                        res += "\n-----------------------\n\n";

                    res += clientController.GetClientInfo(client.IdentificationCode);
                }

                return res;
            }
            catch (Exception)
            {
                return "По даному ключу нічого не знайдено";
            }
        }

        public string FindRealtyByKeyWord(string key)
        {
            try
            {
                List<RealtyModel> realtyModels = realtiesService.GetRealtiesListSortedByPrice().ToModelList();
                List<RealtyModel> realties = realtyModels.FindAll(realty => Regex.IsMatch(realty.RealtyID, key, RegexOptions.IgnoreCase) ||
                                                                            Regex.IsMatch(realty.City, key, RegexOptions.IgnoreCase) ||
                                                                            Regex.IsMatch(realty.RealtyType, key, RegexOptions.IgnoreCase) ||
                                                                            Regex.IsMatch(realty.RoomsNumber.ToString(), key, RegexOptions.IgnoreCase) ||
                                                                            Regex.IsMatch(realty.Area.ToString(), key, RegexOptions.IgnoreCase) ||
                                                                            Regex.IsMatch(realty.Price.ToString(), key, RegexOptions.IgnoreCase));

                string res = "";
                foreach (var realty in realties)
                {
                    if (res != "")
                        res += "\n-----------------------\n\n";

                    res += realtyController.GetRealtyInfo(realty.RealtyID);
                }

                return res;
            }
            catch (Exception)
            {
                return "По даному ключу нічого не знайдено";
            }
        }

        public string FindAllByKeyWord(string key)
        {
            string res = "";

            res += FindClientByKeyWord(key);

            res += "\n-----------------\n\n";

            res += FindRealtyByKeyWord(key);

            return res;
        }

        public string FindByClientParameters(string Name, string LastName, int Age, string IdentificationCode, string BankAccountNumber, string Email, string City, string RealtyType, int RoomsNumber, double Area, int Budget)
        {
            try
            {
                List<ClientModel> clientModels = clientsService.GetClientsListSortedByName().ToModelList();
                int countParametrs = 0;
                int countOfCoincidence = 0;
                string res = "";

                if (Name != "")
                    countParametrs++;
                if (LastName != "")
                    countParametrs++;
                if (Age != 0)
                    countParametrs++;
                if (IdentificationCode != "")
                    countParametrs++;
                if (BankAccountNumber != "")
                    countParametrs++;
                if (Email != "")
                    countParametrs++;
                if (City != "")
                    countParametrs++;
                if (RealtyType != "")
                    countParametrs++;
                if (RoomsNumber != 0)
                    countParametrs++;
                if (Area != 0)
                    countParametrs++;
                if (Budget != 0)
                    countParametrs++;

                foreach (var client in clientModels)
                {
                    if (client.Name == Name)
                        countOfCoincidence++;
                    if (client.LastName == LastName)
                        countOfCoincidence++;
                    if (client.Age == Age)
                        countOfCoincidence++;
                    if (client.IdentificationCode == IdentificationCode)
                        countOfCoincidence++;
                    if (client.BankAccountNumber == BankAccountNumber)
                        countOfCoincidence++;
                    if (client.City == City)
                        countOfCoincidence++;
                    if (client.RealtyType == RealtyType)
                        countOfCoincidence++;
                    if (client.RoomsNumber == RoomsNumber)
                        countOfCoincidence++;
                    if (client.Area == Area)
                        countOfCoincidence++;
                    if (client.Budget == Budget)
                        countOfCoincidence++;

                    if (countOfCoincidence == countParametrs)
                    {
                        if (res != "")
                        {
                            res += "\n-----------------------\n\n";
                        }

                        res += clientController.GetClientInfo(client.IdentificationCode);
                    }

                    countOfCoincidence = 0;
                }

                return res;
            }
            catch (Exception)
            {
                return "По даному ключу нічого не знайдено";
            }
        }
    }
}
