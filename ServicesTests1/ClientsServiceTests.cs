using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestClass()]
    public class ClientsServiceTests
    {
        [TestMethod()]
        public void GetClientsListSortedByNameTest()
        {
            //Arrange
            ClientsService clientsService = new ClientsService();

            //Act
            List<Client> actual = clientsService.GetClientsListSortedByName();

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetClientsListSortedByLastNameTest()
        {
            //Arrange
            ClientsService clientsService = new ClientsService();

            //Act
            List<Client> actual = clientsService.GetClientsListSortedByLastName();

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetClientsListSortedByBankAccountNumberTest()
        {
            //Arrange
            ClientsService clientsService = new ClientsService();

            //Act
            List<Client> actual = clientsService.GetClientsListSortedByBankAccountNumber();

            //Assert
            Assert.IsNotNull(actual);
        }
    }
}