namespace FluentScheduler
{
    using System;

    /// <summary>
    /// Unit of time that represents week and day of week of the month (wow that's confusing).
    /// </summary>
    public sealed class MonthOnDayOfWeekUnit : ITimeRestrictableUnit
    {

        private readonly Week _week;

        private readonly DayOfWeek _dayOfWeek;

        internal MonthOnDayOfWeekUnit(Schedule schedule, int duration, Week week, DayOfWeek dayOfWeek)
        {
            Duration = duration;
            _week = week;
            _dayOfWeek = dayOfWeek;
            Schedule = schedule;
            At(0, 0);
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
            if (_week == Week.Last)
            {
                Schedule.CalculateNextRun = x =>
                {
                    var nextRun = x.Date.First().Last(_dayOfWeek).AddHours(hours).AddMinutes(minutes);
                    return x > nextRun ? x.Date.First().AddMonths(Duration).Last(_dayOfWeek).AddHours(hours).AddMinutes(minutes) : nextRun;
                };
            }
            else
            {
                Schedule.CalculateNextRun = x =>
                {
                    var nextRun = x.Date.First().ToWeek(_week).ThisOrNext(_dayOfWeek).AddHours(hours).AddMinutes(minutes);
                    return x > nextRun ? x.Date.First().AddMonths(Duration).ToWeek(_week).ThisOrNext(_dayOfWeek).AddHours(hours).AddMinutes(minutes) : nextRun;
                };
            }
        }
    }
}
