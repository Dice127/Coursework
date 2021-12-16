using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Repositories.Tests
{
    [TestClass()]
    public class ClientRepositoryTests
    {
        [TestMethod()]
        public void GetClientsTest()
        {
            //Arrange
            ClientRepository clientRepository = new ClientRepository();
            List<ClientEntity> clientEntities = new List<ClientEntity>();

            //Act
            clientEntities = clientRepository.GetClients();

            //Assert
            Assert.IsNotNull(clientEntities);
        }
    }
}