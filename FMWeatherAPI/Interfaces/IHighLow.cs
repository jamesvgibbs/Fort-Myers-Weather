using System;

namespace FMWeatherAPI.Interfaces
{
    public interface IHighLow
    {
        string Day { get; set; }
        string High { get; set; }
        string Low { get; set; }
        string Month { get; set; }
        string Station { get; set; }
        string Year { get; set; }
        DateTime Date { get; set; }
        long DateEpoch { get; set; }
    }
}