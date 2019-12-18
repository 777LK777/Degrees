using System;
using GeometryLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class AngleTest
    {
        [TestMethod]
        public void DeegresPropertyTest()
        {
            //arrange
            Angle a = new Angle(500);
            int expected = 140;

            //act
            int actual = a.Degrees;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeegresNegativePropertyTest()
        {
            //arrange
            Angle a = new Angle(-200, 0, 0);
            double expected = 160;

            //act
            int actual = a.Degrees;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinutesPropertyTest()
        {
            //arrange
            Angle a = new Angle(500, 313);
            int expected = 13;

            //act
            int actual = a.Minutes;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
