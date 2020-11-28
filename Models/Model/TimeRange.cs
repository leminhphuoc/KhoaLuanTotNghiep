namespace Models.Model
{
    public class TimeRange
    {
        public TimeRange(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public int Hour { get; set; }
        public int Minute { get; set; }
    }
}
