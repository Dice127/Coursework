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
    public class RealtyControllerTests
    {
        [TestMethod()]
        public void GetRealtyInfoTest()
        {
            //Arrange
            RealtyController realtyController = new RealtyController();
            string id = "777";

            //Act
            string actual = realtyController.GetRealtyInfo(id);

            //Assert
            Assert.AreNotEqual("", actual);
        }
    }
}