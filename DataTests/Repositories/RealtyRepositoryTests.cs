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
    public class RealtyRepositoryTests
    {
        [TestMethod()]
        public void GetRealtiesTest()
        {
            //Arrange
            RealtyRepository realtyReository = new RealtyRepository();
            List<RealtyEntity> realtiesEntities = new List<RealtyEntity>();

            //Act
            realtiesEntities = realtyReository.GetRealties();

            //Assert
            Assert.IsNotNull(realtiesEntities);
        }
    }
}