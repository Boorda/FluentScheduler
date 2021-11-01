namespace FluentScheduler
{
    /// <summary>
    /// Unit of time in seconds.
    /// </summary>
    public sealed class SecondUnit : ITimeRestrictableUnit
    {

        internal SecondUnit(Schedule schedule, int duration)
        {
            Duration = duration;
            Schedule = schedule;
            Schedule.CalculateNextRun = x => x.AddSeconds(Duration);
        }

        internal int Duration { get; private set; }
        int ITimeRestrictableUnit.Duration { get { return Duration; } }

        internal Schedule Schedule { get; private set; }
        Schedule IUnit.Schedule { get { return Schedule; } }
    }
}
