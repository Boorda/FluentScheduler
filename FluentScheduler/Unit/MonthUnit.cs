namespace FluentScheduler
{
    using System;

    /// <summary>
    /// Unit of time in months.
    /// </summary>
    public sealed class MonthUnit : ITimeRestrictableUnit
    {

        internal MonthUnit(Schedule schedule, int duration)
        {
            Duration = duration;
            Schedule = schedule;
            Schedule.CalculateNextRun = x => x.Date.AddMonths(Duration);
        }

        internal int Duration { get; private set; }
        int ITimeRestrictableUnit.Duration { get { return Duration; } }

        internal Schedule Schedule { get; private set; }
        Schedule IUnit.Schedule { get { return Schedule; } }

        /// <summary>
        /// Runs the job on the given day of the month.
        /// </summary>
        /// <param name="day">The day (1 through the number of days in month).</param>
        public MonthOnDayOfMonthUnit On(int day)
        {
            return new MonthOnDayOfMonthUnit(Schedule, Duration, day);
        }

        /// <summary>
        /// Runs the job on the last day of the month.
        /// </summary>
        public MonthOnLastDayOfMonthUnit OnTheLastDay()
        {
            return new MonthOnLastDayOfMonthUnit(Schedule, Duration);
        }

        /// <summary>
        /// Runs the job on the given day of week on the first week of the month.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        public MonthOnDayOfWeekUnit OnTheFirst(DayOfWeek day)
        {
            return new MonthOnDayOfWeekUnit(Schedule, Duration, Week.First, day);
        }

        /// <summary>
        /// Runs the job on the given day of week on the second week of the month.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        public MonthOnDayOfWeekUnit OnTheSecond(DayOfWeek day)
        {
            return new MonthOnDayOfWeekUnit(Schedule, Duration, Week.Second, day);
        }

        /// <summary>
        /// Runs the job on the given day of week on the third week of the month.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        public MonthOnDayOfWeekUnit OnTheThird(DayOfWeek day)
        {
            return new MonthOnDayOfWeekUnit(Schedule, Duration, Week.Third, day);
        }

        /// <summary>
        /// Runs the job on the given day of week on the fourth week of the month.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        public MonthOnDayOfWeekUnit OnTheFourth(DayOfWeek day)
        {
            return new MonthOnDayOfWeekUnit(Schedule, Duration, Week.Fourth, day);
        }

        /// <summary>
        /// Runs the job on the given day of week on the last week of the month.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        public MonthOnDayOfWeekUnit OnTheLast(DayOfWeek day)
        {
            return new MonthOnDayOfWeekUnit(Schedule, Duration, Week.Last, day);
        }
    }
}
