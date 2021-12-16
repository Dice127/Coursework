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
    public class OffersRepositoryTests
    {
        [TestMethod()]
        public void GetOffersTest()
        {
            //Arrange
            OffersRepository offersRepository = new OffersRepository();
            List<OffersEntity> offersEntities = new List<OffersEntity>();

            //Act
            offersEntities = offersRepository.GetOffers();

            //Assert
            Assert.IsNotNull(offersEntities);
        }
    }
}