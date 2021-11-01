namespace FluentScheduler
{
    using System;

    /// <summary>
    /// Unit used to represent delay.
    /// </summary>
    public sealed class DelayTimeUnit: ITimeRestrictableUnit
    {

        internal DelayTimeUnit(Schedule schedule, int duration)
        {
            Duration = duration;
            Schedule = schedule;
        }

        internal int Duration { get; private set; }
        int ITimeRestrictableUnit.Duration { get { return Duration; } }

        internal Schedule Schedule { get; private set; }
        Schedule IUnit.Schedule { get { return Schedule; } }

        /// <summary>
        /// Sets the interval to milliseconds.
        /// The timing may not be accurate when used with very low intervals.
        /// </summary>
        public void Milliseconds()
        {
            Schedule.DelayRunFor = TimeSpan.FromMilliseconds(Duration);
        }

        /// <summary>
        /// Sets the interval to seconds.
        /// </summary>
        public void Seconds()
        {
            Schedule.DelayRunFor = TimeSpan.FromSeconds(Duration);
        }

        /// <summary>
        /// Sets the interval to minutes.
        /// </summary>
        public void Minutes()
        {
            Schedule.DelayRunFor = TimeSpan.FromMinutes(Duration);
        }

        /// <summary>
        /// Sets the interval to hours.
        /// </summary>
        public void Hours()
        {
            Schedule.DelayRunFor = TimeSpan.FromHours(Duration);
        }

        /// <summary>
        /// Sets the interval to days.
        /// </summary>
        public void Days()
        {
            Schedule.DelayRunFor = TimeSpan.FromDays(Duration);
        }

        /// <summary>
        /// Sets the interval to weeks.
        /// </summary>
        public void Weeks()
        {
            Schedule.DelayRunFor = TimeSpan.FromDays(Duration * 7);
        }

        /// <summary>
        /// Sets the interval to months.
        /// </summary>
        public void Months()
        {
            var today = DateTime.Today;
            Schedule.DelayRunFor = today.AddMonths(Duration).Subtract(today);
        }

        /// <summary>
        /// Sets the interval to years.
        /// </summary>
        public void Years()
        {
            var today = DateTime.Today;
            Schedule.DelayRunFor = today.AddYears(Duration).Subtract(today);
        }
    }
}
