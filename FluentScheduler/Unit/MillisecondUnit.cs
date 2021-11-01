namespace FluentScheduler
{
    /// <summary>
    /// Unit of time in milliseconds.
    /// </summary>
    public sealed class MillisecondUnit : ITimeRestrictableUnit
    {

        internal MillisecondUnit(Schedule schedule, int duration)
        {
            Duration = duration;
            Schedule = schedule;
            Schedule.CalculateNextRun = x => x.AddMilliseconds(Duration);
        }

        internal int Duration { get; private set; }
        int ITimeRestrictableUnit.Duration { get { return Duration; } }

        internal Schedule Schedule { get; private set; }
        Schedule IUnit.Schedule { get { return Schedule; } }
    }
}
