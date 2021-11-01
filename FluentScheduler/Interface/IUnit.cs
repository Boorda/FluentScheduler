namespace FluentScheduler
{
    /// <summary>
    /// Interface for all unit types needing access to the scheduler.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// The schedule being affected.
        /// </summary>
        Schedule Schedule { get; }
    }
}
