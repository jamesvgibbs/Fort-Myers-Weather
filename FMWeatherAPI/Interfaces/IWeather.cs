using System;

namespace FMWeatherAPI.Interfaces
{
    public interface IWeather
    {
        string AverageWindSpeed { get; set; }
        string CloudsBrokenPercentage { get; set; }
        string CloudsClearPercentage { get; set; }
        string CloudsFewPercentage { get; set; }
        string CoolingDegreeHours { get; set; }
        DateTime Date { get; set; }
        string HeatIndexMean { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
        string MeanWindVectorDirection { get; set; }
        string MeanWindVectorMagnitude { get; set; }
        string Station { get; set; }
        string TemperatureMean { get; set; }
    }
}