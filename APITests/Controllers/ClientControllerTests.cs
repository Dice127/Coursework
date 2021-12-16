using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.Tests
{
    [TestClass()]
    public class ClientControllerTests
    {
        [TestMethod()]
        public void GetClientInfoTest()
        {
            //Arrange
            ClientController clientController = new ClientController();
            string id = "777";

            //Act
            string actual = clientController.GetClientInfo(id);

            //Assert
            Assert.AreNotEqual("", actual);
        }
    }
}