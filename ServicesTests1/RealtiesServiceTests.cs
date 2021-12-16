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
    public class RealtiesServiceTests
    {
        [TestMethod()]
        public void GetRealtiesListSortedByTypeTest()
        {
            //Arrange
            RealtiesService realtiesService = new RealtiesService();

            //Act
            List<Realty> actual = realtiesService.GetRealtiesListSortedByType();

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetRealtiesListSortedByPriceTest()
        {
            //Arrange
            RealtiesService realtiesService = new RealtiesService();

            //Act
            List<Realty> actual = realtiesService.GetRealtiesListSortedByPrice();

            //Assert
            Assert.IsNotNull(actual);
        }
    }
}