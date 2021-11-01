namespace FluentScheduler
{
    using System;

    /// <summary>
    /// Unit of time that represents day of the week.
    /// </summary>
    public sealed class WeeklyDayOfWeekUnit : ITimeRestrictableUnit
    {

        private readonly DayOfWeek _day;

        internal WeeklyDayOfWeekUnit(Schedule schedule, int duration, DayOfWeek day)
        {
            Duration = duration;
            _day = day;
            Schedule = schedule;

            if (Duration > 0)
            {
                Schedule.CalculateNextRun = x =>
                {
                    var nextRun = x.Date.AddDays(Duration * 7).ThisOrNext(day);
                    return x > nextRun ? nextRun.AddDays(Duration * 7) : nextRun;
                };
            }
            else
            {
                Schedule.CalculateNextRun = x =>
                {
                    var nextRun = x.Date.Next(day);
                    return x > nextRun ? nextRun.AddDays(7) : nextRun;
                };
            }
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
                var nextRun = x.Date.AddDays(Duration * 7).ThisOrNext(_day).AddHours(hours).AddMinutes(minutes);
                return x > nextRun ? nextRun.AddDays(Math.Max(Duration, 1) * 7) : nextRun;
            };
        }
    }
}
