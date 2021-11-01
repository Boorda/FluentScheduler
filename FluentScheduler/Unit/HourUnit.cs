namespace FluentScheduler
{
    /// <summary>
    /// Unit of time in hours.
    /// </summary>
    public sealed class HourUnit : ITimeRestrictableUnit
    {

        internal HourUnit(Schedule schedule, int duration)
        {
            Duration = duration < 1 ? 1 : duration;
            Schedule = schedule;
            Schedule.CalculateNextRun = x =>
            {
                var nextRun = x.AddHours(Duration);
                return x > nextRun ? nextRun.AddHours(Duration) : nextRun;
            };
        }

        internal int Duration { get; private set; }
        int ITimeRestrictableUnit.Duration { get { return Duration; } }

        internal Schedule Schedule { get; private set; }
        Schedule IUnit.Schedule { get { return this.Schedule; } }

        /// <summary>
        /// Runs the job at the given minute of the hour.
        /// </summary>
        /// <param name="minutes">The minutes (0 through 59).</param>
        public ITimeRestrictableUnit At(int minutes)
        {
            Schedule.CalculateNextRun = x =>
            {
                var nextRun = x.ClearMinutesAndSeconds().AddMinutes(minutes);
                return Duration == 1 && x < nextRun ? nextRun : nextRun.AddHours(Duration);
            };
            return this;
        }
    }
}
