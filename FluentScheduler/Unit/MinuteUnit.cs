namespace FluentScheduler
{
    /// <summary>
    /// Unit of time in minutes.
    /// </summary>
    public sealed class MinuteUnit : IUnit, ITimeRestrictableUnit
    {

        internal MinuteUnit(Schedule schedule, int duration)
        {
            Duration = duration;
            Schedule = schedule;
            Schedule.CalculateNextRun = x => x.AddMinutes(Duration);
        }

        internal int Duration { get; private set; }
        int ITimeRestrictableUnit.Duration { get { return Duration; } }

        internal Schedule Schedule { get; private set; }
        Schedule IUnit.Schedule { get { return this.Schedule; } }
    }
}
