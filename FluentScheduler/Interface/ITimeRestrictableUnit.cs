namespace FluentScheduler
{
    /// <summary>
    /// Common interface of units that can be restricted by time.
    /// </summary>
    public interface ITimeRestrictableUnit : IUnit
    {
        /// <summary>
        /// Specified unit duration.
        /// </summary>
        int Duration { get; }
    }
}