using FMWeatherAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FMWeatherAPI.Controllers
{
    public class WeatherController : ApiControllerBase
    {
        [HttpGet]
        public IEnumerable<Weather> Get()
        {
            IEnumerable<Weather> weather;
            using (SqlDataContext sdc = new SqlDataContext())
            {
                var results = sdc.ExecuteReader("getAllWeather", null);
                weather = GetWeatherList(results);
            }
            return weather;
        }

        // GET api/weather/forday/1323915176
        [HttpGet]
        [Route("api/weather/forday/{epochDateString}")]
        public IEnumerable<Weather> GetWeatherForDay(string epochDateString)
        {
            using (SqlDataContext sdc = new SqlDataContext())
            {
                List<SqlParameter> sp = new List<SqlParameter>()
                {
                    new SqlParameter("@Date", epochDateString)
                };
                var results = sdc.ExecuteReader("getWeatherForDay", sp);
                return GetWeatherList(results);
            }
        }

        // GET api/weather/formonth/1323915176
        [HttpGet]
        [Route("api/weather/formonth/{epochDateString}")]
        public IEnumerable<HighLow> GetWeatherForMonth(string epochDateString)
        {
            using (SqlDataContext sdc = new SqlDataContext())
            {
                List<SqlParameter> sp = new List<SqlParameter>()
                {
                    new SqlParameter("@Date", epochDateString)
                };
                var results = sdc.ExecuteReader("getWeatherForMonth", sp);
                return GetHighLowList(results);
            }
        }

        // GET api/weather/forweek/1323915176
        [HttpGet]
        [Route("api/weather/forweek/{epochDateString}")]
        public IEnumerable<HighLow> GetWeatherForWeek(string epochDateString)
        {
            using (SqlDataContext sdc = new SqlDataContext())
            {
                List<SqlParameter> sp = new List<SqlParameter>()
                {
                    new SqlParameter("@Date", epochDateString)
                };
                var results = sdc.ExecuteReader("getWeatherForWeek", sp);
                return GetHighLowList(results);
            }
        }

        private static IList<HighLow> GetHighLowList(IDataReader reader)
        {
            var highLows = new List<HighLow>();

            while (reader.Read())
            {
                var test = reader.ToString();
                HighLow hl = new HighLow();
                hl.Station = (string)reader["Station_Name"];
                hl.Date = new DateTime((int)reader["year"], (int)reader["month"], (int)reader["day"]);
                hl.DateEpoch = EpochToDateTime.ToEpoch(hl.Date);
                hl.Low = (string)reader["Low"];
                hl.High = (string)reader["High"];

                highLows.Add(hl);
            }

            return highLows;
        }

        private static IList<Weather> GetWeatherList(IDataReader reader)
        {
            var weathers = new List<Weather>();

            while (reader.Read())
            {
                Weather weather = new Weather();
                weather.Station = (string)reader["Station_Name"];
                weather.Date = (DateTime)reader["Date"];
                weather.Latitude = (string)reader["LATITUDE"];
                weather.Longitude = (string)reader["LONGITUDE"];
                weather.CoolingDegreeHours = (string)reader["hly-cldh-normal"];
                weather.CloudsBrokenPercentage = (string)reader["hly-clod-pctbkn"];
                weather.CloudsClearPercentage = (string)reader["hly-clod-pctclr"];
                weather.CloudsFewPercentage = (string)reader["hly-clod-pctfew"];
                weather.HeatIndexMean = (string)reader["hly-hidx-normal"];
                weather.TemperatureMean = (string)reader["hly-temp-normal"];
                weather.AverageWindSpeed = (string)reader["hly-wind-avgspd"];
                weather.MeanWindVectorDirection = (string)reader["hly-wind-vctdir"];
                weather.MeanWindVectorMagnitude = (string)reader["hly-wind-vctspd"];

                weathers.Add(weather);
            }

            return weathers;
        }
    }
}
