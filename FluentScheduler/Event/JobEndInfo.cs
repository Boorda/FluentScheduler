namespace FluentScheduler
{
    using System;

    /// <summary>
    /// Information of a job end.
    /// </summary>
    public class JobEndInfo
    {
        /// <summary>
        /// Name of the job.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date and time of the start.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The elapsed time of the job.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Date and time of next run.
        /// </summary>
        public DateTime? NextRun { get; set; }

        /// <summary>
        /// Number of times the job was run.
        /// </summary>
        public int RunCount { get; set; }

        /// <summary>
        /// Cancel state of the job.
        /// </summary>
        public CancelType CancelType { get; set; }
    }
}
