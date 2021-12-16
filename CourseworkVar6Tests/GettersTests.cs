using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseworkVar6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkVar6.Tests
{
    [TestClass()]
    public class GettersTests
    {
        [TestMethod()]
        public void UppercaseFirstLetterTest()
        {
            //Arrange
            string value = "exemple";
            string expectedValue = "Exemple";

            //Act
            string actualValue = Getters.UppercaseFirstLetter(value);

            //Assert
            Assert.AreEqual(actualValue, expectedValue);
        }
    }
}