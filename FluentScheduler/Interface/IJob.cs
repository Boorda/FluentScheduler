namespace FluentScheduler
{

    /// <summary>
    /// Some work to be done.
    /// Make sure there's a parameterless constructor (avoid System.MissingMethodException).
    /// </summary>
    public interface IJob
    {
        /// <summary>
        /// Name of the job.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Number of time the Job has run.
        /// </summary>
        int RunCount { get; }

        /// <summary>
        /// Executes the job.
        /// </summary>
        void Execute();
    }
}
