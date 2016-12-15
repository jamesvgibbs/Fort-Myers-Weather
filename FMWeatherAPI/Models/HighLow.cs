using FMWeatherAPI.Interfaces;
using System;
using System.Diagnostics;

namespace FMWeatherAPI.Models
{
    [DebuggerDisplay("Station = {Station}, Date = {Date}, High = {High}")]
    public class HighLow : IHighLow
    {
        //STATION_NAME
        public string Station { get; set; }

        public DateTime Date { get; set; }

        public long DateEpoch { get; set; }

        //Day
        public string Day { get; set; }

        //Month
        public string Month { get; set; }

        //Year
        public string Year { get; set; }

        //Low
        public string Low { get; set; }

        //High
        public string High { get; set; }
    }
}