namespace FluentScheduler
{
    /// <summary>
    /// Unit of time in weekdays.
    /// </summary>
    public sealed class WeekdayUnit : ITimeRestrictableUnit
    {

        internal WeekdayUnit(Schedule schedule, int duration)
        {
            Duration = duration < 1 ? 1 : duration;
            Schedule = schedule;
            Schedule.CalculateNextRun = x =>
            {
                var nextRun = x.Date.NextNWeekday(Duration);
                return x > nextRun || !nextRun.Date.IsWeekday() ? nextRun.NextNWeekday(Duration) : nextRun;
            };
        }

        internal int Duration { get; private set; }
        int ITimeRestrictableUnit.Duration { get { return Duration; } }

        internal Schedule Schedule { get; private set; }
        Schedule IUnit.Schedule { get { return Schedule; } }

        /// <summary>
        /// Runs the job at the given time of day.
        /// </summary>
        /// <param name="hours">The hours (0 through 23).</param>
        /// <param name="minutes">The minutes (0 through 59).</param>
        public void At(int hours, int minutes)
        {
            Schedule.CalculateNextRun = x =>
            {
                var nextRun = x.Date.AddHours(hours).AddMinutes(minutes);
                return x > nextRun || !nextRun.Date.IsWeekday() ? nextRun.NextNWeekday(Duration) : nextRun;
            };
        }
    }
}