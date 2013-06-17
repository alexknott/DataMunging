using System;
using CommonLibrary;

namespace WeatherData
{
    public class Day : IDifferenceCalculator
    {
        public Day(int dayNumber, int mxt, int mnt)
        {
            ValidateParameters(dayNumber, mxt, mnt);
            DayNumber = dayNumber;
            Mxt = mxt;
            Mnt = mnt;
        }

        private void ValidateParameters(int dayNumber, int mxt, int mnt)
        {
            if (dayNumber < 1)
                throw new ArgumentOutOfRangeException("dayNumber", "Day number must be greater than zero");
                
            if (mxt < 0)
                throw new ArgumentOutOfRangeException("mxt", "Max temperature must be greater than zero");
                
            if (mnt < 0)
                throw new ArgumentOutOfRangeException("mnt", "Min temperature must be greater than zero");
                
            if (mxt < mnt)
                throw new ArgumentOutOfRangeException("mxt", "Max temperature can not be less than the Min temperature");
        }

        //Dy MxT   MnT   AvT   HDDay  AvDP 1HrP TPcpn WxType PDir AvSp Dir MxS SkyC MxR MnR AvSLP
        public int DayNumber { get; private set; }
        public int Mxt { get; private set; }
        public int Mnt { get; private set; }

        private int TemperatureSpread
        {
            get { return Mxt - Mnt; }
        }

        public string Id { get { return DayNumber.ToString(); } }

        public int CalculateDifference()
        {
            return TemperatureSpread;
        }
    }

    /*
    public struct Day : IDifferenceCalculator
    {
        public Day(int dayNumber, int mxt, int mnt)
        {
            DayNumber = dayNumber;
            Mxt = mxt;
            Mnt = mnt;
            ValidateParameters(dayNumber, mxt, mnt);
        }

        private void ValidateParameters(int dayNumber, int mxt, int mnt)
        {
            if (dayNumber < 1)
                throw new DayInvalidStateException("Day number must be greater than zero");

            if (mxt < 0)
                throw new DayInvalidStateException("Max temperature must be greater than zero");

            if (mnt < 0)
                throw new DayInvalidStateException("Min temperature must be greater than zero");

            if (mxt < mnt)
                throw new DayInvalidStateException("Max temperature can not be less than the Min temperature");
        }

        //Dy MxT   MnT   AvT   HDDay  AvDP 1HrP TPcpn WxType PDir AvSp Dir MxS SkyC MxR MnR AvSLP
        public int DayNumber;
        public int Mxt;
        public int Mnt;

        private int TemperatureSpread
        {
            get { return Mxt - Mnt; }
        }

        public string Id { get { return DayNumber.ToString(); } }

        public int CalculateDifference()
        {
            return TemperatureSpread;
        }
    }
    */
}