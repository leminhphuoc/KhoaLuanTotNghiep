namespace Models.Model
{
    public class PeriodTime
    {
        public PeriodTime(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public int Hour { get; set; }
        public int Minute { get; set; }
    }
}
