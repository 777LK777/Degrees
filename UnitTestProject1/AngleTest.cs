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

        [TestMethod]
        public void MinutesNegativePropertyTest()
        {
            //arrange
            Angle a = new Angle(0, -36, 0);
            int expected = 24;

            //act
            int actual = a.Minutes;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SecondsPropertyTest()
        {
            //arrange
            Angle a = new Angle(0, 0, 590.71);
            double expected = 50.71;

            //act
            double actual = a.Seconds;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SecondsNegativePropertyTest()
        {
            //arrange
            Angle a = new Angle(0, 0, -590.71);
            double expected = 9.29;

            //act
            double actual = a.Seconds;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ComplexPropertiesTest()
        {
            //arrange
            Angle a = new Angle(0, 64, 3725.59);
            int expectedDeg = 2;
            int expectedMin = 6;
            double expectedSec = 5.59;

            //act
            int actualDeg = a.Degrees;
            int actualMin = a.Minutes;
            double actualSec = a.Seconds;

            //assert
            Assert.AreEqual(expectedDeg, actualDeg);
            Assert.AreEqual(expectedMin, actualMin);
            Assert.AreEqual(expectedSec, actualSec);
        }

        [TestMethod]
        public void ComplexNegativePropertiesTest()
        {
            //arrange
            Angle a = new Angle(0, -64, -3725.59);
            int expectedDeg = 357;
            int expextedMin = 53;
            double expextedSec = 54.41;

            //act
            int actualDeg = a.Degrees;
            int actualMin = a.Minutes;
            double actualSec = a.Seconds;

            //assert
            Assert.AreEqual(expectedDeg, actualDeg);
            Assert.AreEqual(expextedMin, actualMin);
            Assert.AreEqual(expextedSec, actualSec);
        }

        [TestMethod]
        public void PlusOperatorTest()
        {
            //arrange
            Angle expectedA = new Angle(239);

            //act
            Angle actualA = new Angle(new Angle(359) + new Angle(600));

            //assert
            Assert.AreEqual(expectedA, actualA);
        }

        [TestMethod]
        public void MinusOperatorTest()
        {
            //arrange
            Angle expectedA = new Angle(195);

            //act
            Angle actualA = new Angle(new Angle(195) - new Angle(360));

            //assert
            Assert.AreEqual(expectedA, actualA);
        }
    }
}
