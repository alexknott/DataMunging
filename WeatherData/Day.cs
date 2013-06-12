namespace WeatherData
{
    public class Day
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
                throw new DayInvalidStateException("Day number must be greater than zero");

            if (mxt < 0)
                throw new DayInvalidStateException("Max temperature must be greater than zero");

            if (mnt < 0)
                throw new DayInvalidStateException("Min temperature must be greater than zero");

            if (Mxt < Mnt)
                throw new DayInvalidStateException("Max temperature can not be less than the Min temperature");
        }

        //Dy MxT   MnT   AvT   HDDay  AvDP 1HrP TPcpn WxType PDir AvSp Dir MxS SkyC MxR MnR AvSLP
        public int DayNumber { get; private set; }
        public int Mxt { get; private set; }
        public int Mnt { get; private set; }

        public int Spread
        {
            get { return Mxt - Mnt; }
        }
    }
}