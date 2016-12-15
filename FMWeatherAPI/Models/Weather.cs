using FMWeatherAPI.Interfaces;
using System;
using System.Diagnostics;

namespace FMWeatherAPI.Models
{
    [DebuggerDisplay("Station = {Station}, Date = {Date}, Temp = {TemperatureMean}")]
    public class Weather : IWeather
    {
        //STATION_NAME
        public string Station { get; set; }

        //DATE
        public DateTime Date { get; set; }

        //LATITUDE
        public string Latitude { get; set; }

        //LONGITUDE
        public string Longitude { get; set; }

        //hly-cldh-normal
        public string CoolingDegreeHours { get; set; }

        //hly-clod-pctbkn
        public string CloudsBrokenPercentage { get; set; }

        //hly-clod-pctclr
        public string CloudsClearPercentage { get; set; }

        //hly-clod-pctfew
        public string CloudsFewPercentage { get; set; }

        //[hly-clod-pctovc],-- as [clouds overcast percentage],
        //[hly-clod-pctsct],-- as [clouds scattered percentage],
        //[hly-dewp-10pctl],-- as [dew postring 10th percentile],
        //[hly-dewp-90pctl],-- as [dew postring 90th percentile],
        //[hly-dewp-normal],-- as [dew postring mean],

        //hly-hidx-normal
        public string HeatIndexMean { get; set; }

        //[hly-htdh-normal],-- as [heating degree hours],
        //[hly-temp-10pctl],-- as [temperature 10th percentile],
        //[hly-temp-90pctl],-- as [temperature 90th percentile],

        //hly-temp-normal        
        public string TemperatureMean { get; set; }

        //[hly-wchl-normal],-- as [wind chill mean],
        //[hly-wind-1stdir],-- as [prevailing wind direction(1 - 8)],
        //[hly-wind-1stpct],-- as [prevailing wind percentage],
        //[hly-wind-2nddir],-- as [secondary wind direction(1 - 8)],
        //[hly-wind-2ndpct],-- as [secondary wind percentage],

        //hly-wind-avgspd
        public string AverageWindSpeed { get; set; }

        //[hly-wind-pctclm],-- as [percentage calm],

        //hly-wind-vctdir
        public string MeanWindVectorDirection { get; set; }

        //hly-wind-vctspd        
        public string MeanWindVectorMagnitude { get; set; }
    }
}