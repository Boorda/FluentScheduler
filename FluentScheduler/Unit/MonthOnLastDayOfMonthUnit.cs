namespace FluentScheduler
{
    /// <summary>
    /// Unit of time that represents last day of the month.
    /// </summary>
    public sealed class MonthOnLastDayOfMonthUnit : ITimeRestrictableUnit
    {

        internal MonthOnLastDayOfMonthUnit(Schedule schedule, int duration)
        {
            Duration = duration;
            Schedule = schedule;
            Schedule.CalculateNextRun = x =>
            {
                var nextRun = x.Date.Last();
                return x > nextRun ? x.Date.First().AddMonths(Duration).Last() : x.Date.Last();
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
                var nextRun = x.Date.Last().AddHours(hours).AddMinutes(minutes);
                return x > nextRun ? x.Date.First().AddMonths(Duration).Last().AddHours(hours).AddMinutes(minutes) : nextRun;
            };
        }
    }
}
