using Microsoft.VisualStudio.TestTools.UnitTesting;
using FMWeatherAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMWeatherAPI.Controllers.Tests
{
    [TestClass()]
    public class WeatherControllerTests
    {
        [TestMethod()]
        public void GetWeatherForDayTest()
        {
            WeatherController controller = new WeatherController();
            var result = controller.GetWeatherForDay("1311033600"); //2011-07-19
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 24);
            Assert.AreEqual(result.ElementAt(0).Station, "FORT MYERS PAGE FIELD AIRPORT FL US");
        }

        [TestMethod()]
        public void GetWeatherForMonthTest()
        {
            WeatherController controller = new WeatherController();
            var result = controller.GetWeatherForMonth("1311033600"); //2011-07-19
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 31);
            Assert.AreEqual(result.ElementAt(0).Station, "FORT MYERS PAGE FIELD AIRPORT FL US");
        }

        [TestMethod()]
        public void GetWeatherForWeekTest()
        {
            WeatherController controller = new WeatherController();
            var result = controller.GetWeatherForWeek("1311033600"); //2011-07-19
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 7);
            Assert.AreEqual(result.ElementAt(0).Station, "FORT MYERS PAGE FIELD AIRPORT FL US");
        }

        [TestMethod()]
        public void GetWeatherTest()
        {
            WeatherController controller = new WeatherController();
            var result = controller.Get(new System.Net.Http.HttpRequestMessage()); 
            Assert.IsNotNull(result.Content);
            //Assert.AreEqual(result.Content.Count(), 175180);
            //Assert.AreEqual(result.ElementAt(0).Station, "FORT MYERS PAGE FIELD AIRPORT FL US");
        }
        
    }
}