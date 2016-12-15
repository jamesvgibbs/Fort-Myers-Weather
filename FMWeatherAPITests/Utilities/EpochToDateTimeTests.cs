using Microsoft.VisualStudio.TestTools.UnitTesting;
using FMWeatherAPI;
using System;

namespace FMWeatherAPI.Tests
{
    [TestClass()]
    public class EpochToDateTimeTests
    {
        [TestMethod()]
        public void DateTimeFromEpochStringTest()
        {
            DateTime expected = new DateTime(2011, 7, 19);
            var results = EpochToDateTime.FromEpochString("1311033600");
            Assert.AreEqual(expected, results);
        }

        [TestMethod()]
        public void DateTimeFromEpochStringNullTest()
        {
            var results = EpochToDateTime.FromEpochString(null);
            Assert.AreEqual(null, results);
        }

        [TestMethod()]
        public void DateTimeFromEpochStringEmptyTest()
        {
            var results = EpochToDateTime.FromEpochString(string.Empty);
            Assert.AreEqual(null, results);
        }

        [TestMethod()]
        public void DateTimeFromEpochTest()
        {
            DateTime expected = new DateTime(2011, 7, 19);
            var results = EpochToDateTime.FromEpoch(1311033600);
            Assert.AreEqual(expected, results);
        }
    }
}