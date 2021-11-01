namespace FluentScheduler
{
    using System;

    /// <summary>
    /// Unit of time in days.
    /// </summary>
    public sealed class DayUnit : IDayRestrictableUnit
    {

        internal DayUnit(Schedule schedule, int duration)
        {
            Duration = duration < 1 ? 1 : duration;
            Schedule = schedule;
            Schedule.CalculateNextRun = x =>
            {
                var nextRun = x.Date.AddDays(Duration);
                return x > nextRun ? ((IDayRestrictableUnit)this).DayIncrement(nextRun) : nextRun;
            };
        }

        internal int Duration { get; private set; }
        int ITimeRestrictableUnit.Duration { get { return Duration; } }

        internal Schedule Schedule { get; private set; }
        Schedule IUnit.Schedule { get { return this.Schedule; } }

        /// <summary>
        /// Runs the job at the given time of day.
        /// </summary>
        /// <param name="hours">The hours (0 through 23).</param>
        /// <param name="minutes">The minutes (0 through 59).</param>
        public IDayRestrictableUnit At(int hours, int minutes)
        {
            Schedule.CalculateNextRun = x =>
            {
                var nextRun = x.Date.AddHours(hours).AddMinutes(minutes);
                return x > nextRun ? ((IDayRestrictableUnit)this).DayIncrement(nextRun) : nextRun;
            };
            return this;
        }

        DateTime IDayRestrictableUnit.DayIncrement(DateTime increment)
        {
            return increment.AddDays(Duration);
        }
    }
}
