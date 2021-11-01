namespace FluentScheduler
{
    /// <summary>
    /// Unit of time.
    /// </summary>
    public sealed class TimeUnit : ITimeRestrictableUnit
    {

        internal TimeUnit(Schedule schedule, int duration)
        {
            Schedule = schedule;
            Duration = duration;
        }

        internal int Duration { get; private set; }
        int ITimeRestrictableUnit.Duration { get { return Duration; } }

        internal Schedule Schedule { get; private set; }
        Schedule IUnit.Schedule { get { return Schedule; } }

        /// <summary>
        /// Sets the interval to milliseconds.
        /// The timing may not be accurate when used with very low intervals.
        /// </summary>
        public MillisecondUnit Milliseconds()
        {
            return new MillisecondUnit(Schedule, Duration);
        }

        /// <summary>
        /// Sets the interval to seconds.
        /// </summary>
        public SecondUnit Seconds()
        {
            return new SecondUnit(Schedule, Duration);
        }

        /// <summary>
        /// Sets the interval to minutes.
        /// </summary>
        public MinuteUnit Minutes()
        {
            return new MinuteUnit(Schedule, Duration);
        }

        /// <summary>
        /// Sets the interval to hours.
        /// </summary>
        public HourUnit Hours()
        {
            return new HourUnit(Schedule, Duration);
        }

        /// <summary>
        /// Sets the interval to days.
        /// </summary>
        public DayUnit Days()
        {
            return new DayUnit(Schedule, Duration);
        }

        /// <summary>
        /// Sets the interval to weekdays.
        /// </summary>
        public WeekdayUnit Weekdays()
        {
            return new WeekdayUnit(Schedule, Duration);
        }

        /// <summary>
        /// Sets the interval to weeks.
        /// </summary>
        public WeekUnit Weeks()
        {
            return new WeekUnit(Schedule, Duration);
        }

        /// <summary>
        /// Sets the interval to months.
        /// </summary>
        public MonthUnit Months()
        {
            return new MonthUnit(Schedule, Duration);
        }
    }
}
